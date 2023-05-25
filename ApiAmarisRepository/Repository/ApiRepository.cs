using ApiAmarisDto.Dto;
using ApiAmarisRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiAmarisRepository.Repository
{
    public class ApiRepository : IApiRepository
    {
        private readonly IHttpClientFactory _httpClienteFactory;
        private JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        private List<EmployeDto> listEmploye = new List<EmployeDto>();
        private EmployeDto DataEmploye = new EmployeDto();

        public ApiRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClienteFactory = httpClientFactory;
        }

        public async Task<List<EmployeDto>> GetEmployeAll()
        {
            var client = _httpClienteFactory.CreateClient("ApiAmaris");
            var response = await client.GetAsync("/api/v1/employees");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GenericResponse>(content, options);

                if (result.status == "success")
                {
                    listEmploye = JsonSerializer.Deserialize<List<EmployeDto>>(result.data.ToString(), options);
                }

            }
            return listEmploye;
        }

        public async Task<EmployeDto> GetEmployeId(int IdEmploye)
        {
            var client = _httpClienteFactory.CreateClient("ApiAmaris");
            var response = await client.GetAsync($"/api/v1/employee/{IdEmploye}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GenericResponse>(content, options);

                if (result.status == "success")
                {
                    DataEmploye = JsonSerializer.Deserialize<EmployeDto>(result.data.ToString(), options);
                }

            }
            return DataEmploye;
        }
    }
}
