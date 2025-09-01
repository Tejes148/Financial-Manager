using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Core.DTOs
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; } 
        public int AccessTokenExpiryMinutes { get; set; } 
        public int RefreshTokenExpiryDays { get; set; }
    }
}
