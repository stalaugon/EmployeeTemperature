using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTemperature.Domain.Dtos;
using EmployeeTemperature.Domain.Entitties;

namespace EmployeeTemperature.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeDto>> GetAll();
        Task<EmployeeDto> Get(int id);
        Task Update(EmployeeDto employee);
        Task Add(EmployeeDto employee);
        Task Delete(int id);    
    }
}
