using System;
using System.Threading.Tasks;

namespace CustomerInformationSystem.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
