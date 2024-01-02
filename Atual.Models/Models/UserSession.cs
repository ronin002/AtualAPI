using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualAPI.Models
{
    public class UserSession
    {
        public UserModel UserLogged { get; set; }
        public Company UserLoggedCompany { get; set; }
        public List<Role> UserLoggedRoles { get; set; }
    }
}
