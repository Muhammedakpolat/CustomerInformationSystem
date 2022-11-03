using CustomerInformationSystem.DataAccess.Contexts;
using CustomerInformationSystem.Entities.Concrete;

namespace CustomerInformationSystem.DataAccess.Repositories.CustomerAddresses
{
    public class CustomerAddressRepository : Repository<CustomerAddress>, ICustomerAddressRepository
    {
        private readonly CustomerContext _context;

        public CustomerAddressRepository(CustomerContext context) : base(context)
        {
            _context = context;
        }
    }
}
