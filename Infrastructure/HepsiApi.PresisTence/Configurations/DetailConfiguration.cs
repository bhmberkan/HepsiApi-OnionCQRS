using Bogus;
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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("tr");

            Detail detail1 = new()
            {

                Id = 1,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1, //elektirk kategorisi
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            };


            Detail detail2 = new()
            {

                Id = 2,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3, 
                CreatedDate = DateTime.Now,
                IsDeleted = true,

            };


            Detail detail3 = new()
            {

                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            };


            builder.HasData(detail1, detail2, detail3);
        }
    }
}
