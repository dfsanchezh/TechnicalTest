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
    public class DataEmployeCore : IDataEmployeCore
    {
        private readonly IApiRepository _apiRepository;
        private EmployeDto DataEmployee = new EmployeDto();
        private EmployeListDto DataResponseEmploye = new EmployeListDto();

        public DataEmployeCore(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public async Task<EmployeListDto> DataEmploye(int IdEmploye)
        {

            DataEmployee = await _apiRepository.GetEmployeId(IdEmploye);

            EmployeListDto DataResponseEmploye = new EmployeListDto()
            {
                id = DataEmployee.id,
                employee_name = DataEmployee.employee_name,
                employee_salary = DataEmployee.employee_salary,
                employee_age = DataEmployee.employee_age,
                profile_image = DataEmployee.profile_image,
                EmployeeAnualSalary = DataEmployee.employee_salary * 12
            };

            return DataResponseEmploye;

        }

    }
}
