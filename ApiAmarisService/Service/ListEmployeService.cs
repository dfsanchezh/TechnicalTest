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
    public class ListEmployeService : IListEmployeService
    {
        private readonly IListEmployeCore _listEmployeCore;

        public ListEmployeService(IListEmployeCore listEmployeCore)
        {
            _listEmployeCore = listEmployeCore;
        }

        public async Task<List<EmployeListDto>> ListEmploye()
        {
            return await _listEmployeCore.ListEmploye();
        }
    }
}
