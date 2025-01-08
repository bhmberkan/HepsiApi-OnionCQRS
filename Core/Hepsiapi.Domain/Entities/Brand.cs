using Hepsiapi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Domain.Entities
{
    public class Brand :EntityBase /*, IEntityBase zaten entitybaseden alıyoruz yazmasakta olur*/
    {
        public Brand() 
        {
        }
        public Brand(string name)
        {
            Name = name;
        }

         public required string Name { get; set; }
    }
}
