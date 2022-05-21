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
    [Route("[controller]/[Action]")]
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

        [HttpGet(Name ="GetVoyages")]
        [ProducesResponseType(typeof(IEnumerable<Voyage>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Voyage>>> GetVoyages()
        {
            var products = await _repository.GetVoyages();
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Voyage), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Voyage>> CreateVoyagePrice([FromBody] Voyage voyage)
        {
            await _repository.CreateVoyagePrice(voyage);
            return CreatedAtRoute(nameof(GetVoyages), new { id = voyage.Id }, voyage);
        }

    }
}
