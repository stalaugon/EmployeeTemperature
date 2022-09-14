using EmployeeTemperature.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EmployeeTemperature.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {

        private readonly EmployeeTemperatureContext _context;
        public IEmployeeRepository EmployeeRepository { get; set; }
        public ITemperatureRepository TemperatureRepository { get; set; }

        public UnitOfWork(EmployeeTemperatureContext context, IEmployeeRepository employeeRepository, ITemperatureRepository temperatureRepository)
        {
            _context = context;
            EmployeeRepository = employeeRepository;
            TemperatureRepository = temperatureRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }


    }
}
