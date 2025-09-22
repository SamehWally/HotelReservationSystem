using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Room.DTO
{
    public class AvailableRoomsDto
    {
        public string Name { get; set; } = string.Empty;
        public int Type { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> PictureUrls { get; set; } = new();
        public List<int> FacilityIds { get; set; } = new();
    }
}
