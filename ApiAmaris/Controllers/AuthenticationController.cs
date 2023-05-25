using ApiAmarisService.IService;
using Microsoft.AspNetCore.Mvc;

namespace ApiAmaris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        private readonly ILogger _logger;
        public readonly IAuthenticationService _authenticationService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;

        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Authentication()
        {
            try
            {
                var user = _authenticationService.GetAuthentication();
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -- UserController -- Authentication() -- " + ex.Message.ToString());
                return NotFound();

            }
        }
    }
}
