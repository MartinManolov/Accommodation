namespace Accommodation.Application.Offers.Commands.CreateOffer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateOfferCommand(
        string HotelId,
        string RoomId,
        DateTime FromDate,
        DateTime ToDate,
        decimal PricePerNight,
        int MaxPeople) : IRequest<string>
    {
    }

    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateOfferCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = new Offer
            {
                HotelId = request.HotelId,
                RoomId = request.RoomId,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                PricePerNight = request.PricePerNight,
                MaxPeople = request.MaxPeople,
            };

            await _context.Offers.AddAsync(offer);
            await _context.SaveChangesAsync(cancellationToken);

            return offer.Id;
        }
    }

}
