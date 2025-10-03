namespace Domain.Models.Room
{
    public class Facility 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<RoomFacility> RoomFacilities { get; set; } = new();
    }
}
