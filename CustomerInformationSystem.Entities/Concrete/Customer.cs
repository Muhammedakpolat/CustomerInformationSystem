using CustomerInformationSystem.Core.Entities;
using System.Collections.Generic;

namespace CustomerInformationSystem.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int IdentityNumber { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public bool IsExtraordinaryName { get; set; }

        public ICollection<CustomerPhoneNumber> CustomerPhoneNumbers { get; set; } = new List<CustomerPhoneNumber>();
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
    }
}
