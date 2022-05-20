using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceCalculator.API.Entities;
using PriceCalculator.API.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PriceCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceCalculatorController : ControllerBase
    {
        private readonly IVoyageRepository _repository;
        private readonly ILogger<PriceCalculatorController> _logger;
        public PriceCalculatorController(IVoyageRepository repository, ILogger<PriceCalculatorController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Voyage>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Voyage>>> GetProducts()
        {
            var products = await _repository.GetVoyages();
            return Ok(products);
        }

    }
}
