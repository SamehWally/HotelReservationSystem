using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Room
{
    public class RoomPicture : BaseModel
    {
        public string Url { get; set; } = string.Empty;

        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
    }
}
