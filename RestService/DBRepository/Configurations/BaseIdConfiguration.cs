using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.EntityModels;

namespace DBRepository.Configurations
{
    public class BaseIdConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseIdModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}