using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Login
{
    public class LoginRequestDto
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
