namespace Presentation.ViewModels.Offer
{
    public class GetAllOfferVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public List<AllRoomInOfferVM> RoomInOfferDtos { get; set; } = new();
    }
}
