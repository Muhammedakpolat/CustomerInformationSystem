using CustomerInformationSystem.Entities.Concrete;
using System.Collections.Generic;

namespace CustomerInformationSystem.WebUI.Models
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
    }
}
