using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Login
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Features { get; set; } = new List<string>();
    }
}
