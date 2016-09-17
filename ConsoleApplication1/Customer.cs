using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Order CurrentOrder { get; set; }
        public int? CurrentOrderId { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    }
}
