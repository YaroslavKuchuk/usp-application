using Microsoft.AspNetCore.Mvc;
using Usp.Api.BusinessLogic.Services.Abstractions;

namespace Usp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellingPointsController : ControllerBase
    {
        private readonly ISellingPointService _sellingPointService;

        public SellingPointsController(ISellingPointService sellingPointService)
        {
            _sellingPointService = sellingPointService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var sellingPoints = _sellingPointService.GetList();

            return Ok(sellingPoints);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var sellingPoint = _sellingPointService.Get(id);

            if (sellingPoint is null)
                return NotFound();

            return Ok(sellingPoint);
        }
    }
}
