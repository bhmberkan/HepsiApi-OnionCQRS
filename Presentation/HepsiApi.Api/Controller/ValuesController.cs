using Hepsiapi.Application.UnitOfWorks;
using Hepsiapi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApi.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await unitOfWork.GetReadRepository<Product>().GetAllAsync());

        }
    }
}
