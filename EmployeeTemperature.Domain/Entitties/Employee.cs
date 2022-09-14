using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeTemperature.Domain.Base.EntityBase;

namespace EmployeeTemperature.Domain.Entitties
{
    public partial class Employee : EntityBase<int>
    {
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Temperature> Temperatures { get; set; }

    }
}
