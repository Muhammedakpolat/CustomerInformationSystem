using CustomerInformationSystem.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerInformationSystem.Business.Services.CustomerPhoneNumbers
{
    public interface ICustomerPhoneNumberService : IService<CustomerPhoneNumber>
    {
        Task<IList<CustomerPhoneNumber>> GetListByCustomerId(int customerId);
    }
}
