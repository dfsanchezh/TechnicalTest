using ApiAmarisCore.ICore;
using ApiAmarisDto.Dto;
using ApiAmarisService.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAmarisService.Service
{
    public class DataEmployeService : IDataEmployeService
    {
        private readonly IDataEmployeCore _dataEmployeCore;

        public DataEmployeService(IDataEmployeCore dataEmployeCore)
        {
            _dataEmployeCore = dataEmployeCore;
        }

        public async Task<EmployeListDto> DataEmploye(int IdEmploye)
        {
            return await _dataEmployeCore.DataEmploye(IdEmploye);
        }
    }
}
