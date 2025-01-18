using Hepsiapi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Domain.Entities
{
    public class ProductCategory : IEntityBase
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product product { get; set; }

        public Category category { get; set; }

    }
}
