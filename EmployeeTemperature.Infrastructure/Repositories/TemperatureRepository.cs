using EmployeeTemperature.Domain.Entitties;
using EmployeeTemperature.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Infrastructure.Repositories
{
    public class TemperatureRepository : GenericRepository<Temperature>, ITemperatureRepository
    {
        public TemperatureRepository(EmployeeTemperatureContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Temperature>> GetAllByEmployeeId(int employeeId)
        {
            return await _context.Temperatures.Where(f => f.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<IEnumerable<Temperature>> Search(string search, DateTime? recordFrom , DateTime? recordTo, decimal? tempFrom,
            decimal? tempTo)
        {
            var query = _context.Temperatures.Include(i => i.Employee).AsQueryable();

            if(!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(f => f.Employee.EmployeeNumber.Contains(search)
                                    || f.Employee.FirstName.Contains(search)
                                    || f.Employee.LastName.Contains(search));
            }

            if(recordFrom != null && recordTo != null)
            {
                query = query.Where(f => f.RecordDate >= recordFrom && f.RecordDate <= recordTo);
            }

            if (tempFrom != null && tempTo != null)
            {
                query = query.Where(f => f.Value >= tempFrom && f.Value <= tempTo);
            }

            var result = await query.ToListAsync();
            return result;
        }


    }
}
