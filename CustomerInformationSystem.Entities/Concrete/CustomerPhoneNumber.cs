using CustomerInformationSystem.Core.Entities;

namespace CustomerInformationSystem.Entities.Concrete
{
    public class CustomerPhoneNumber : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NumberType { get; set; }
        public string PhoneNumber { get; set; }

        public Customer Customer { get; set; }
    }
}
