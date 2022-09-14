using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Domain.Dtos
{
    public class EmployeeTemperatureDto
    {
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Value { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
