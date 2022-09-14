using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Domain.Dtos
{
    public class FilterInput
    {
        public string? Search { get; set; }
        public DateTime? RecordFrom { get; set; }
        public DateTime? RecordTo { get; set; }
        public decimal? TempFrom { get; set; }
        public decimal? TempTo { get; set; }
    }
}
