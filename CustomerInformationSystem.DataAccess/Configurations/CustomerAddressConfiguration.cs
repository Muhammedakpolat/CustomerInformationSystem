using CustomerInformationSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerInformationSystem.DataAccess.Configurations
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasIndex(x => x.CustomerId).IsUnique(false);
        }
    }
}
