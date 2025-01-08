using Hepsiapi.Domain.Common;
using Hepsiapi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Domain.Entities
{
    public class Category : EntityBase , IEntityBase
    {
        public Category() 
        {
        
        }

        public Category(int parentId, String name, int priorty)
        {
            ParentId = parentId;
            Name = name; 
            Priorty = priorty; 
        }


        public required int ParentId { get; set; }

        public required String Name { get; set; }
        public int Priorty { get; set; }

        public ICollection<Detail> Details { get; set; } // bire çok ilişki
        
        public ICollection<Product> Products { get; set; }
    }
}