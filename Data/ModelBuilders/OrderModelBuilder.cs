using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Data.ModelBuilders
{
    public class OrderModelBuilder: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders","dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.CustomerID).HasColumnName("CustomerID");
            builder.Property(o => o.Freight).HasColumnName("Freight");
            builder.Property(o => o.ShipCountry).HasColumnName("ShipCountry");
        }
    }
}
