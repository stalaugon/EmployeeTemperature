using EmployeeTemperature.Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        
    }
}
