namespace Domain.Models.Room
{
    public class RoomFacility : BaseModel
    {
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;

        public int FacilityId { get; set; }
        public Facility Facility { get; set; } = null!;
    }
}
