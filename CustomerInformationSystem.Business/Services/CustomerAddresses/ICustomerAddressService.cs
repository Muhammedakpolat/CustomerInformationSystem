using CustomerInformationSystem.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerInformationSystem.Business.Services.CustomerAddresses
{
    public interface ICustomerAddressService : IService<CustomerAddress>
    {
        Task<IList<CustomerAddress>> GetListByCustomerId(int customerId);
    }
}
