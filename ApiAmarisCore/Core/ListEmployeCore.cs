using ApiAmarisCore.ICore;
using ApiAmarisDto.Dto;
using ApiAmarisRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAmarisCore.Core
{
    public class ListEmployeCore : IListEmployeCore
    {
        private readonly IApiRepository _apiRepository;
        private List<EmployeDto> listEmploye = new List<EmployeDto>();
        private List<EmployeListDto> listResponseEmploye = new List<EmployeListDto>();


        public ListEmployeCore(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }


        public async Task<List<EmployeListDto>> ListEmploye()
        {

            listEmploye = await _apiRepository.GetEmployeAll();

            foreach (var item in listEmploye)
            {
                EmployeListDto DataListEmploye = new EmployeListDto(){
                    id = item.id,
                    employee_name = item.employee_name,
                    employee_salary = item.employee_salary,
                    employee_age = item.employee_age,
                    profile_image = item.profile_image,
                    EmployeeAnualSalary = item.employee_salary * 12
                };
               
                listResponseEmploye.Add(DataListEmploye);
            }

            return listResponseEmploye;

        }
    }
}
