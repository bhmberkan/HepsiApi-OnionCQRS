using Hepsiapi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Domain.Entities
{
    public class Product : EntityBase
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BrandId{ get; set; }
        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }
        
        public Brand Brand { get; set; } // tekil olacağını belirttik

        public ICollection<Category> Categories { get; set; }
        
        //   public required string ImagePath{ get; set; }
    }
}
