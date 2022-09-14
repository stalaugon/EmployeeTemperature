using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Domain.Dtos
{
    public class TemperatureDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Value { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
