using Hepsiapi.Application.DTOs;
using Hepsiapi.Application.Interfaces.AutoMapper;
using Hepsiapi.Application.UnitOfWorks;
using Hepsiapi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryRepsonse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryRepsonse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x=>x.Include(b=>b.Brand));

            var brand = mapper.Map<BrandDto, Brand>(new Brand());
          //  List<GetAllProductsQueryRepsonse> response = new(); // liste olacak

           /* foreach (var product in products)
            {
                response.Add(new GetAllProductsQueryRepsonse // her seferinde listeye ekleyecek
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price - (product.Price * product.Discount / 100), // işleme tabi tuttuk
                    Discount = product.Discount
                    
                });
            }*/

            var map = mapper.Map<GetAllProductsQueryRepsonse, Product>(products);

            foreach (var x in map)
            {
                x.Price -= (x.Price * x.Discount / 100);
            }

            return map;
          //  throw new Exception("hata mesajı"); // ExceptionModeli denemek için yazdım
        }
    }
}
