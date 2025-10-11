using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Report;
public class PopularRoomDto
{
    public string RoomType { get; set; } = default!;
    public int BookedCount { get; set; }
}
