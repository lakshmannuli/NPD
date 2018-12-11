using NPD.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPD.DAL.Repositories
{
    public class UsersinfoRepository
    {
        public static IEnumerable<UsersInfo> GetAllActiveEngineers()
        {
            using (var Context = new NPDEntities())
            {
                return Context.UsersInfoes.Where(x => x.RoleId == 2).OrderBy(x => x.Name).ToList();
            }
        }

        public static UsersInfo ValidateUser(UsersInfo user)
        {
            using (var Context = new NPDEntities())
            {
                return Context.UsersInfoes.FirstOrDefault(x => x.Email == user.Email && x.Password==user.Password);
            }
        }
    }
}
