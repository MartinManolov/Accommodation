namespace Accommodation.Application.Reservations.Queries.GetReservation
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Reservations.Queries.Common.Models.GetUserReservations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public record GetReservationQuery(string ReservationId) : IRequest<UserReservationDto>
    {
    }

    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, UserReservationDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public GetReservationQueryHandler(IApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<UserReservationDto> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;

            return await _context.Reservations
                   .Where(x => x.Id == request.ReservationId && x.CreatedBy == userId)
                   .Select(x => new UserReservationDto
                   {
                       Id = x.Id,
                       FirstName = x.Guest.FirstName,
                       LastName = x.Guest.LastName,
                       Email = x.Guest.Email,
                       PhoneNumber = x.Guest.PhoneNumber,
                       HotelName = x.Hotel.Name,
                       HotelEmail = x.Hotel.Email,
                       HotelPhoneNumber = x.Hotel.PhoneNumber,
                       City = x.Hotel.City,
                       Country = x.Hotel.Country,
                       Nights = (x.Offer.CheckOutDate - x.Offer.CheckInDate).Days,
                       Price = x.Offer.PricePerNight * (x.Offer.CheckOutDate - x.Offer.CheckInDate).Days,
                       CheckIn = x.Offer.CheckInDate,
                       CheckOut = x.Offer.CheckOutDate,
                   }).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
