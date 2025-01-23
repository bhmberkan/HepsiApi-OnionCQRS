using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Products.Command.CrateProduct
{
    public class CreateProductCommandRequest : IRequest<Unit> // burdaki unit kritik   
    {  // eski mediatr sürümlerinde boş dönmemize izin vermıyordu ancak şu an ızın verıyor o yüzden çalışmıyor eklenmeli
       // handlere da ekliyoruz
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public IList<int> CategoryIds { get; set; }

    }
}
