using CustomerInformationSystem.Core.Entities;

namespace CustomerInformationSystem.Entities.Concrete
{
    public class CustomerAddress : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AddressType { get; set; }
        public string Address { get; set; }
    }
}
