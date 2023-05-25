using ApiAmarisDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAmarisService.IService
{
    public interface IDataEmployeService
    {
        Task<EmployeListDto> DataEmploye(int IdEmploye);
    }
}
