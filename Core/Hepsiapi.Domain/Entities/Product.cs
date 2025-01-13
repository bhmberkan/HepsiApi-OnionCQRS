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
        public  string Title { get; set; }
        public string Description { get; set; }
        public int BrandId{ get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        
        public Brand Brand { get; set; } // tekil olacağını belirttik

        public ICollection<Category> Categories { get; set; }
        
        //   public required string ImagePath{ get; set; }
    }
}
