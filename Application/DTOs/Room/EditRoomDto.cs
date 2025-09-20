using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Room
{
    public class EditRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
