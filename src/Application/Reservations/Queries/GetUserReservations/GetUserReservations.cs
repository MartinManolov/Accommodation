namespace Accommodation.Application.Reservations.Queries.GetUserReservations
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Reservations.Queries.Common.Models.GetUserReservations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public record GetUserReservations : IRequest<UserReservationsListVm>
    {
    }

    public class GetUserReservationsHandler : IRequestHandler<GetUserReservations, UserReservationsListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public GetUserReservationsHandler(IApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<UserReservationsListVm> Handle(GetUserReservations request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;

            return new UserReservationsListVm
            {
                Reservations = await _context.Reservations
                    .Where(x => x.CreatedBy == userId)
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
                    }).OrderByDescending(x => x.CheckIn)
                    .ToListAsync(cancellationToken),
            };
        }
    }
}
