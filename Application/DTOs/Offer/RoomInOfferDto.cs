using Domain.Enums.RoomType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Offer
{
    public class RoomInOfferDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RoomType Type { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
