using CustomerInformationSystem.DataAccess.Contexts;
using System.Threading.Tasks;

namespace CustomerInformationSystem.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext _context;

        public UnitOfWork(CustomerContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
