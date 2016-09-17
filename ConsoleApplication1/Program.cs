using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestContext context = new TestContext())
            {
                Customer c = new Customer { Name = "C1" };
                context.Customers.Add(c);

                Order o1 = new Order { Name = "O1", Customer = c };
                context.Orders.Add(o1);

                Order o2 = new Order { Name = "O2", Customer = c };
                context.Orders.Add(o1);

                c.CurrentOrder = o2;

                //It will break here with the error: Unable to determine a valid ordering for dependent operations. Dependencies may exist due to foreign key constraints, model requirements, or store-generated values.
                context.SaveChanges();

                //FYI: The solution is to make a property IsCurrent on the Orders and use that instead. 
            }

        }
    }
}
