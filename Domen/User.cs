using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class User : IdentityUser
    {
        public string ImePrezime { get; set; }
    }
}
