
namespace Application.DTOs.Report
{
    public class PopularRoomDto
    {
        public string RoomType { get; set; } = default!;
        public int BookedCount { get; set; }
    }
}