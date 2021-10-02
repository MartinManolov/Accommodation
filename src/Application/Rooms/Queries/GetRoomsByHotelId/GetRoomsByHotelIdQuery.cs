﻿using Accommodation.Application.Common.Interfaces;
using Accommodation.Application.Offers.Queries.GetOffersByHotelId;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accommodation.Application.Rooms.Queries.GetRoomsByHotelId
{
    public record GetRoomsByHotelIdQuery(string HotelId) : IRequest<RoomsVm>
    {
    }

    public class GetRoomsByHotelIdQueryHandler : IRequestHandler<GetRoomsByHotelIdQuery, RoomsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsByHotelIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomsVm> Handle(GetRoomsByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var rooms = _context.Rooms
               .Where(x => x.HotelId == request.HotelId)
               .Select(x => new RoomDto
               {
                   Id = x.Id,
                   Size = x.Size,
                   Sleeps = x.Sleeps,
                   Description = x.Description,
                   View = x.View,
                   Facilities = x.Facilities.Select(f => f.Name).ToList(),
                   Offers = x.Offers.Select(o => new OfferDto
                   {
                       Id = o.Id,
                       RoomId = x.Id,
                       MaxPeople = o.MaxPeople,
                       PricePerNight = o.PricePerNight,
                       FromDate = o.FromDate,
                       ToDate = o.ToDate,
                   }).ToList(),
               }).ToList();

            var vm = new RoomsVm { Rooms = rooms };

            return vm;
        }
    }
}
