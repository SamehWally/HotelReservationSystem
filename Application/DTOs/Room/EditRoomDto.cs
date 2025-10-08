namespace Application.DTOs.Room
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