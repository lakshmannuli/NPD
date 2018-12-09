using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPD.DAL.EntityFramework;

namespace NPD.DAL.Repositories
{
    public class FaultPrioritiesRepository
    {
        public static IEnumerable<FaultPriority> GetActivePriorities()
        {
            using (var Context = new NPDEntities())
            {
                return Context.FaultPriorities.OrderBy(x => x.Id).ToList();
            }
        }
    }
}
