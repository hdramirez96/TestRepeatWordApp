using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.API.Security
{
    public class JwtConfig
    {
        public const string jwtConfig = "JwtConfig";
        public string SecretKey { get; set; }
        public double ExpireTime { get; set; }
    }
}
