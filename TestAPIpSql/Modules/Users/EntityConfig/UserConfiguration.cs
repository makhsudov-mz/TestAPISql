using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TestAPISql.Modules.Users.Entity;

namespace TestAPISql.Modules.Users.EntityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);
            builder.HasIndex(u => u.Id).IsUnique();
            builder.Property(u => u.Name).HasMaxLength(128);
            builder.Property(u => u.Login).HasMaxLength(128);
            builder.Property(u => u.Email).HasMaxLength(128);
            builder.Property(u => u.Password).HasMaxLength(128);
            builder.Property(u => u.Token).HasMaxLength(128);
            builder.Property(u => u._paramJsons).HasColumnName("param_jsons");
        }
    }
}
