using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Order()
        {
        }
    }
}
