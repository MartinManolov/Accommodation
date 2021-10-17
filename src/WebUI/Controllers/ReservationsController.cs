using Accommodation.Application.Reservations.Commands.CreateReservation;
using Accommodation.Application.Reservations.Queries.Common.Models.GetUserReservations;
using Accommodation.Application.Reservations.Queries.GetReservation;
using Accommodation.Application.Reservations.Queries.GetUserReservations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accommodation.WebUI.Controllers
{
    public class ReservationsController : ApiControllerBase
    {

        // GET api/<ReservationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReservationDto>> Get(string id)
        {
            var vm = await Mediator.Send(new GetReservationQuery(id));

            return Ok(vm);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<UserReservationsListVm>> GetAllByUser()
        {
            var vm = await Mediator.Send(new GetUserReservations());

            return Ok(vm);
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateReservationCommand command)
        {
            var reservationId = await Mediator.Send(command);

            return Ok(reservationId);
        }

        // PUT api/<ReservationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
