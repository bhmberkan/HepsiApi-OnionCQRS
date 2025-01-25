using Hepsiapi.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.PresisTence.Context
{
    public class AppDbContext :  /* DbContext */ IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Brand> brands { get; set; }
        public DbSet<Detail> details { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyConfiguration  // tek tek tanımlama yapmamı sağlar
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());   
                // ilgili katmanda yani persistence geçerli olur
                // tüm confugiration dosyalarını buldu

        }


       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }*/


    }
}
