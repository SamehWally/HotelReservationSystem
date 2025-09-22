using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Room.DTO
{
    public class EditRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Type { get; set; }
        public decimal PricePerNight { get; set; }
        public string? Description { get; set; }
        public List<int> FacilityIds { get; set; } = new();
        public List<string> PictureUrls { get; set; } = new(); 
    }
}