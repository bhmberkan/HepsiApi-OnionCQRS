using Hepsiapi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail() 
        {
        }
        public Detail(string title, string description, int categoryıd)
        {
            Title = title;
            Description = description;
            CategoryId = categoryıd;
        }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
