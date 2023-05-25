using ApiAmarisDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAmarisRepository.IRepository
{
    public interface IApiRepository
    {
        Task<List<EmployeDto>> GetEmployeAll();
        Task<EmployeDto> GetEmployeId(int IdEmploye);
    }
}
