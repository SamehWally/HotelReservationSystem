namespace Presentation.ViewModels.Offer
{
    public class UpdateOfferVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DisCountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> RoomIds { get; set; } = new();
    }
}
