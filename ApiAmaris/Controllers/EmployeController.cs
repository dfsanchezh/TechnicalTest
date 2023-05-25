using ApiAmarisService.IService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiAmaris.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EmployeController : Controller
    {
    
        public readonly IListEmployeService _listEmployeService;
        public readonly IDataEmployeService _dataEmployeService;
        public readonly ILogger _logger;

        public EmployeController(ILogger<EmployeController> logger, IListEmployeService listEmployeService, IDataEmployeService dataEmployeService)
        {
            _logger = logger;
            _listEmployeService = listEmployeService;
            _dataEmployeService = dataEmployeService;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEmployeAll()
        {
            try
            {
                var listEmploye = await _listEmployeService.ListEmploye();
                if (listEmploye.Count() > 0)
                {
                    return Ok(listEmploye);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -- EmployeController -- GetEmployeAll() --"+ex.Message.ToString());
                return NotFound();
            }
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDataEmploye(int IdEmploye)
        {
            try
            {
                var DataEmploye = await _dataEmployeService.DataEmploye(IdEmploye);
                if (DataEmploye.id >= 1) {
                    return Ok(DataEmploye);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -- EmployeController -- GetDataEmploye() --", ex.Message.ToString());
                return NotFound();
            }
        }
    }
}
