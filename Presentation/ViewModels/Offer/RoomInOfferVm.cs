using Domain.Enums.RoomType;

namespace Presentation.ViewModels.Offer
{
    public class RoomInOfferVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RoomType Type { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
