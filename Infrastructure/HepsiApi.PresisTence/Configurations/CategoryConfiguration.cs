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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category categort1 = new()
            {
                Id = 1,
                Name = "Elektrik",
                Priorty = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };



            Category categort2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };

            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentId = 1, // elektriğin ıd sını atadım parent olduğu için
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };


            Category parent2 = new()
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentId = 2, // moda ıd sını atadım
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };

            builder.HasData(categort1,categort2,parent1,parent2);
        }
    }
}
