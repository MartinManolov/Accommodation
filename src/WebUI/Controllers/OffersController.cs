using Accommodation.Application.Offers.Commands.CreateOffer;
using Accommodation.Application.Offers.Queries.Common.Models;
using Accommodation.Application.Offers.Queries.GetActiveOffersByHotelId;
using Accommodation.Application.Offers.Queries.GetOfferById;
using Accommodation.Application.Offers.Queries.GetOffersBySearch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Accommodation.WebUI.Controllers
{
    public class OffersController : ApiControllerBase
    {

        [HttpGet("search")]
        public async Task<ActionResult<OffersListVm>> GetBySearch([FromQuery] GetOffersBySearchQuery query)
        {
            var vm = await this.Mediator.Send(query);

            return this.Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDto>> Get(string id)
        {
            var vm = await this.Mediator.Send(new GetOfferByIdQuery(id));

            return this.Ok(vm);
        }


        [Route("[action]/{hotelId}")]
        [HttpGet]
        public async Task<ActionResult<OffersListVm>> GetByHotelId(string hotelId)
        {
            var vm = await this.Mediator.Send(new GetActiveOffersByHotelIdQuery(hotelId));

            return this.Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateOfferCommand command)
        {
            var offerId = await this.Mediator.Send(command);

            return this.Ok(offerId);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
