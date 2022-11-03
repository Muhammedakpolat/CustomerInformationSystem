using CustomerInformationSystem.DataAccess.Contexts;
using CustomerInformationSystem.Entities.Concrete;

namespace CustomerInformationSystem.DataAccess.Repositories.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context) : base(context)
        {
            _context = context;
        }
    }
}
