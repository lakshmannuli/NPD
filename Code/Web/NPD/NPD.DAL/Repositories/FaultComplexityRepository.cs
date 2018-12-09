using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPD.DAL.EntityFramework;

namespace NPD.DAL.Repositories
{
    public class FaultComplexityRepository
    {
        public static IEnumerable<FaultComplexity> GetActiveComplexities()
        {
            using (var Context = new NPDEntities())
            {
                return Context.FaultComplexities.OrderBy(x => x.Id).ToList();
            }
        }
    }
}
