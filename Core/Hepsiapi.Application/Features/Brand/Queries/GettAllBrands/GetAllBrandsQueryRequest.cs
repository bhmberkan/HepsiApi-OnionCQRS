using Hepsiapi.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Brand.Queries.GettAllBrands
{
    public class GetAllBrandsQueryRequest : IRequest<GettAllBrandsQueryResponse>, ICacheableQuery
    {
        public string CacheKey => "GetAllBrands";

        public double CacheTime => 5;
    }
}
