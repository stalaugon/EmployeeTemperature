using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeTemperature.Domain.Base.EntityBase;

namespace EmployeeTemperature.Domain.Entitties
{
    public partial class Temperature : EntityBase<int>
    {
        public decimal Value { get; set; }
        public DateTime RecordDate { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
