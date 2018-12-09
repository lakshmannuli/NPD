﻿using NPD.DAL.EntityFramework;
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
        public static IEnumerable<CustomFault> GetFaults(Fault fault)
        {
            using (var Context = new NPDEntities())
            {
                return (from f in Context.Faults
                        join p in Context.FaultPriorities on f.Priority equals p.Id
                        join c in Context.FaultComplexities on f.Complexity equals c.Id
                        join co in Context.companies on f.CompanyId equals co.Id
                        where f.Status == 1
                        select new CustomFault()
                        {
                            CompanyName=co.Name,
                            AssignedTo = "",
                            Complexity=c.Name,
                            FaultDescription=f.FaultDescription,
                            FaultStatus="",
                            Location=f.Location,
                            MachineDescription=f.MachineDescription,
                            Priority=p.Name
                            
                        }).ToList();
            }
        }
    }
}
