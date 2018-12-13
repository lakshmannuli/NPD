using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPD.DAL
{
    public class CustomFault
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string MachineDescription { get; set; }
        public string FaultDescription { get; set; }
        public string Priority { set; get; }
        public string Complexity { set; get; }
        public string FaultStatus { set; get; }
        public string AssignedTo { set; get; }
        public DateTime? StartDate { set; get; }
        public Nullable<System.DateTime> CreatedDate { set; get; }

        public string DisplayStartDate
        {
            get
            {
                var str = "-";
                str = StartDate != null && StartDate != DateTime.MinValue ? Convert.ToDateTime(StartDate).ToString("MM/dd/yyyy") : str;
                return str;
            }
        }

        public string DisplayCreatedDate
        {
            get
            {
                var str = "-";
                str = CreatedDate != null && CreatedDate != DateTime.MinValue ? Convert.ToDateTime(CreatedDate).ToString("MM/dd/yyyy") : str;
                return str;
            }
        }
    }
}
