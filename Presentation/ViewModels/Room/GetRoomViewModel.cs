namespace Presentation.ViewModels.Room
{
    public class GetRoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public string Description { get; set; } = string.Empty;

        // ✅ أسماء أو IDs الـ Facilities
        public List<int> Facilities { get; set; } = new();

        // ✅ URLs للصور
        public List<string> Pictures { get; set; } = new();
    }
}
