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
        public DateTime StartDate { set; get; }

        public string DisplayStartDate
        {
            get
            {
                var str = "-";
                str = StartDate != DateTime.MinValue ? StartDate.ToString("MM/dd/yyyy") : str;
                return str;
            }
        }

    }
}
