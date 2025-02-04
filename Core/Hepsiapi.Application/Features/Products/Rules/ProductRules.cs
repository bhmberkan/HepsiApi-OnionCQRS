using Hepsiapi.Application.Bases;
using Hepsiapi.Application.Features.Products.Exceptions;
using Hepsiapi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
        {  
        
            if(products.Any(x=>x.Title==requestTitle)) throw new NotImplementedException();
            return Task.CompletedTask;
        }

        
    }
}
