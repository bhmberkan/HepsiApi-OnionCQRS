using Hepsiapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.PresisTence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(p=>p.product)
                .WithMany(pc=>pc.ProductCategories)
                .HasForeignKey(pc=>pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            // ondelete kısmında entity silinirse bağlantılı olan entityler de silinecektir.


            builder.HasOne(c => c.category)
             .WithMany(pc => pc.ProductCategories)
             .HasForeignKey(pc => pc.CategoryId)
             .OnDelete(DeleteBehavior.Cascade);

           

        }
    }
}
