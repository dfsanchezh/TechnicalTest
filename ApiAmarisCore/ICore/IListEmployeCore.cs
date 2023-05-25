using ApiAmarisDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAmarisCore.ICore
{
    public interface IListEmployeCore
    {
        Task<List<EmployeListDto>> ListEmploye();
    }
}
