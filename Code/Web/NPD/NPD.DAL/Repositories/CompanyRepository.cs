using NPD.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPD.DAL.Repositories
{
    public class CompanyRepository
    {
        public int SaveCompany(company companyEntity)
        {
            using (var Context = new NPDEntities())
            {
                Context.Set<company>().Add(companyEntity);
                return Context.SaveChanges();
            }
        }
    }
}
