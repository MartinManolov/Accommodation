using Accommodation.Application.Accommodations.Commands;
using Accommodation.Application.Accommodations.Commands.CreateHotel;
using Accommodation.Application.Hotels.Queries.GetHotelById;
using Accommodation.Application.Hotels.Queries.GetHotelsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accommodation.WebUI.Controllers
{
    public class HotelsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<HotelsListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetHotelsListQuery());

            return base.Ok(vm);
        }

        [HttpGet("{hotelId}")]
        public async Task<ActionResult<HotelVm>> Get([FromQuery] string hotelId)
        {
            var vm = await Mediator.Send(new GetHotelByIdQuery(hotelId));

            return base.Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateHotelCommand command)
        {
            var hotelId = await Mediator.Send(command);
            return Ok(hotelId);
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
