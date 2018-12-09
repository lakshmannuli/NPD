using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPD.ViewModel
{
    public class LoggedUser
    {
        public string Name { set; get; }
        public string UserName { set; get; }
        public int RoleId { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public int Id { set; get; }
        public int CompanyId { set; get; }
    }
}
