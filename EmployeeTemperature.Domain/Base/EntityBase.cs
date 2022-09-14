using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Domain.Base
{
    public interface EntityBase
    {
        public interface IEntityBase<TKey>
        {
            TKey Id { get; set; }
        }

        public abstract class EntityBase<TKey> : IEntityBase<TKey>
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public virtual TKey Id { get; set; }
        }
    }
}
