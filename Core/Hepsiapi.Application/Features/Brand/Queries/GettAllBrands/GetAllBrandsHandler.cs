using AutoMapper;
using Hepsiapi.Application.Bases;
using Hepsiapi.Application.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Brand.Queries.GettAllBrands
{
    public class GetAllBrandsHandler :BaseHandler, IRequestHandler<GetAllBrandsQueryRequest, GettAllBrandsQueryResponse>
    {
        public GetAllBrandsHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GettAllBrandsQueryResponse> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();

            // return mapper.Map<GettAllBrandsQueryResponse, Brand>(brands);

            return mapper.Map<Brand>(brands);
        }
    }
}
