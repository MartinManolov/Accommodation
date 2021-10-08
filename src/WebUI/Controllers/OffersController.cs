using Accommodation.Application.Offers.Commands.CreateOffer;
using Accommodation.Application.Offers.Queries.GetActiveOffersByHotelId;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accommodation.WebUI.Controllers
{
    public class OffersController : ApiControllerBase
    {
        // GET: api/<OffersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OffersController>/5
        [HttpGet("{hotelId}")]
        public async Task<ActionResult<OffersListVm>> Get([FromQuery] string hotelId)
        {
            var vm = await this.Mediator.Send(new GetActiveOffersByHotelIdQuery(hotelId));

            return this.Ok(vm);
        }

        // POST api/<OffersController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateOfferCommand command)
        {
            var offerId = await this.Mediator.Send(command);

            return this.Ok(offerId);
        }

        // PUT api/<OffersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OffersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
