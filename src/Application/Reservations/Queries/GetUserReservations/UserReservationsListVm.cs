namespace Accommodation.Application.Reservations.Queries.GetUserReservations
{
    using System.Collections.Generic;
    using Accommodation.Application.Reservations.Queries.Common.Models.GetUserReservations;

    public class UserReservationsListVm
    {
        public IList<UserReservationDto> Reservations { get; set; }
    }
}
