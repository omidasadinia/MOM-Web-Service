using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM.BasicAuthentication.DTOs
{
    internal class AuthenticationRequestDto
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
