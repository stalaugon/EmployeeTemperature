using EmployeeTemperature.Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Domain.Interfaces
{
    public interface ITemperatureRepository : IGenericRepository<Temperature>
    {
        Task<IEnumerable<Temperature>> GetAllByEmployeeId(int employeeId);
        Task<IEnumerable<Temperature>> Search(string search, DateTime? recordFrom, DateTime? recordTo, decimal? tempFrom,
            decimal? tempTo);
    }
}
