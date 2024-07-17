using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DbConfiguration
{
    public class QuotationItemConfiguration : IEntityTypeConfiguration<QuotationItem>
    {
        public void Configure(EntityTypeBuilder<QuotationItem> builder)
        {
            builder.HasOne(x=>x.Product).WithMany(x=>x.QuotationItems)
                .HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.Quotation).WithMany(x=>x.QuotationItems)
                .HasForeignKey(x=>x.QuotationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
