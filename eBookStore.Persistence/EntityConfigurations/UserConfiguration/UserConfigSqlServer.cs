using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Persistence.EntityConfigurations.UserConfiguration
{
    public class UserConfigSqlServer : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region Configurations
            builder.ToTable("User", DbObject.SchemaNameUsers).HasKey(k => k.Id);

            builder.
                Property(x => x.Id).
                HasColumnName("Id").
                HasColumnType("int").
                HasMaxLength(35).IsRequired();

            builder.
                Property(x => x.Orders).
                HasColumnName("Orders").
                HasColumnType("nvarchar(max)").
                IsRequired();

            #endregion

        }
    }
}
