using NPD.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPD.DAL.Repositories
{
    public class FaultRepository
    {
        public static int SaveFault(Fault entity)
        {
            using (var Context = new NPDEntities())
            {
                Context.Set<Fault>().Add(entity);
                return Context.SaveChanges();
            }
        }
        public static IEnumerable<Fault> GetFaults(Fault fault)
        {
            using (var Context = new NPDEntities())
            {
                return Context.Faults.OrderBy(x => x.Id).ToList();
            }
        }
    }
}
