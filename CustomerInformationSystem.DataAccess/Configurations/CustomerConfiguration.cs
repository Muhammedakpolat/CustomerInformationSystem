using CustomerInformationSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerInformationSystem.DataAccess.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(x => x.CustomerPhoneNumbers).
                WithOne(z => z.Customer);

            builder.HasMany(x => x.CustomerAddresses).
                WithOne(z => z.Customer);
        }
    }
}
