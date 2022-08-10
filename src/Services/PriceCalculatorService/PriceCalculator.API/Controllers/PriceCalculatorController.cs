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

            var voyages = await _repository.GetVoyages();
            _logger.Log(LogLevel.Information, "Log information",voyages);
            _logger.LogInformation("Log information", voyages);
            return Ok(voyages);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Voyage), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Voyage>> UpdatePrice([FromBody] Voyage voyage)
        {
            await _repository.UpdatePrice(voyage);
            return CreatedAtRoute(nameof(GetVoyages), new { id = voyage.Id }, voyage);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Voyage>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("{voyagecode}/{currency}", Name = "GetAveragePrice")]
        public async Task<ActionResult<IEnumerable<Voyage>>> GetAveragePrice(string voyagecode, Currency currency)
        {
            // we check voyageCode is exist in the database , if not found error
            var voyage = await _repository.GetVoyageCode(voyagecode);
            if (voyage == null)
            {
                _logger.LogError($"VouageCode:{voyagecode} is not exist in the database.");
                _logger.LogWarning("Null VoyageCode Warning");
                return NotFound();
            }
            // calculate average price by currency and voyageCode
            var avgPrice = await _repository.GetAveragePrice(voyagecode, currency);
            return Ok(avgPrice);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Voyage>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("{voyagecode}", Name = "GetVoyageCode")]
        public async Task<ActionResult<Voyage>> GetVoyageCode(string voyagecode) 
        {
            // we check voyageCode is exist in the database , if not found error
            var voyage = await _repository.GetVoyageCode(voyagecode);
            if (voyage == null)
            {
                _logger.LogError($"VouageCode:{voyagecode} is not exist in the database.");
                return NotFound();
            }
            return Ok(voyage);
        }
    }
}