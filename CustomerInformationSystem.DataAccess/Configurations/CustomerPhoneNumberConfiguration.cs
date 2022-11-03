using CustomerInformationSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerInformationSystem.DataAccess.Configurations
{
    public class CustomerPhoneNumberConfiguration : IEntityTypeConfiguration<CustomerPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<CustomerPhoneNumber> builder)
        {
            builder.HasIndex(x => x.CustomerId).IsUnique(false);
        }
    }
}
