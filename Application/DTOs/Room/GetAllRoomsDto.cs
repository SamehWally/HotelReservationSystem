using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Room;

namespace Application.DTOs.Room
{
    public class GetAllRoomsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }
        public List<RoomPictureDto> PictureUrls { get; set; }
        public List<RoomFacilityDto> RoomFasilities { get; set; }

    }
}
