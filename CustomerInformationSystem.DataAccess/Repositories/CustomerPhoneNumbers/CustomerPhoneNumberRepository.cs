using CustomerInformationSystem.DataAccess.Contexts;
using CustomerInformationSystem.Entities.Concrete;

namespace CustomerInformationSystem.DataAccess.Repositories.CustomerPhoneNumbers
{
    public class CustomerPhoneNumberRepository : Repository<CustomerPhoneNumber>, ICustomerPhoneNumberRepository
    {
        private readonly CustomerContext _context;

        public CustomerPhoneNumberRepository(CustomerContext context) : base(context)
        {
            _context = context;
        }
    }
}
