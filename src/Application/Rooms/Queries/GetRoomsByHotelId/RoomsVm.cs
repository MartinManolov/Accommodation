namespace Accommodation.Application.Rooms.Queries.GetRoomsByHotelId
{
    using System.Collections.Generic;

    public class RoomsVm
    {
        public IList<RoomDto> Rooms { get; set; }
    }
}
