using Accommodation.Application.Rooms.Commands.CreateRoom;
using Accommodation.Application.Rooms.Queries.GetRoomsByHotelId;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accommodation.WebUI.Controllers
{
    public class RoomsController : ApiControllerBase
    {
        // GET: api/<RoomsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoomsController>/5
        [HttpGet("{hotelId}")]
        public async Task<ActionResult<RoomsVm>> Get(string hotelId)
        {
            var vm = await Mediator.Send(new GetRoomsByHotelIdQuery(hotelId));

            return Ok(vm);
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateRoomCommand command)
        {
            var roomId = await Mediator.Send(command);

            return Ok(roomId);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
