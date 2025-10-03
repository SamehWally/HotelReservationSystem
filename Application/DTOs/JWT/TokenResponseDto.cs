using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.JWT
{
    public record TokenResponseDto (
        string AccessToken,
        DateTime ExpiresAt
    );

}
