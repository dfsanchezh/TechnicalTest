using ApiAmaris.Modules.Injection;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);



        // Add services to the container.
        builder.Services.AddControllers();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        string[] cors = builder.Configuration.GetSection("AmarisSettings:Cors").Get<string[]>();

        builder.Host.ConfigureLogging(builder =>
        {
            builder.AddLog4Net("log4net.config");
        });
        builder.Services.AddInjection(builder.Configuration);
        builder.Services.AddHttpClient("ApiAmaris", client =>
        {
            client.BaseAddress = new Uri(builder.Configuration.GetSection("AmarisSettings:ApiUrl").Get<string>());
        });


        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
         options =>
         {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AmarisSettings:Jwt:Secret").Value)),
                 ValidateIssuer = false,
                 ValidateAudience = false
             };
         });
        builder.Services.AddAuthorization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseCors(builder => builder.WithOrigins(cors).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
        app.MapControllers();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("v1/swagger.json", "Amaris API");
            c.RoutePrefix = "swagger";
            c.DisplayRequestDuration();
        });


        app.Run();
    }
}