using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPD.ViewModel
{
    public class FaultDTO
    {
        public int Id { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Location { get; set; }
        public string MachineDescription { get; set; }
        public string FaultDescription { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> Complexity { get; set; }
        public Nullable<int> FaultStatus { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
