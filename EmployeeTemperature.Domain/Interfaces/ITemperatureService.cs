using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTemperature.Domain.Dtos;
using EmployeeTemperature.Domain.Entitties;

namespace EmployeeTemperature.Domain.Interfaces
{
    public interface ITemperatureService
    {
        Task<IEnumerable<TemperatureDto>> GetAll();
        Task<TemperatureDto> Get(int id);
        Task<IEnumerable<TemperatureDto>> GetAllByEmployeeId(int employeeId);
        Task Update(TemperatureDto temperature);
        Task Add(TemperatureDto temperature);
        Task Delete(int id);
        Task<IEnumerable<EmployeeTemperatureDto>> Search(FilterInput input);
    }
}
