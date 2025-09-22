namespace Presentation.ViewModels.Room
{
    public class AvailableRoomsVM
    {
        public string Name { get; set; } = string.Empty;
        public int Type { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> PictureUrls { get; set; } = new();
        public List<int> FacilityIds { get; set; } = new();
    }
}
