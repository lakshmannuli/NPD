using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPD.DAL.EntityFramework;
using NPD.DAL.Repositories;
using NPD.DAL;

namespace NPD_Win_UI.UserControls
{
    public partial class ucEditJobs : UserControl
    {
        CustomFault _customFault;
        IEnumerable<FaultPriority> Priorities;
        IEnumerable<FaultComplexity> Complexities;
        IEnumerable<company> Companies;
        IEnumerable<UsersInfo> Enigineers;

        public ucEditJobs()
        {
            InitializeComponent();
        }
        public ucEditJobs(CustomFault customFault) : this()
        {
            _customFault = customFault;
            Load += UcEditJobs_Load;
        }
        private void UcEditJobs_Load(object sender, EventArgs e)
        {
            try
            {
                Priorities = FaultPrioritiesRepository.GetActivePriorities();
                Complexities = FaultComplexityRepository.GetActiveComplexities();
                Companies = CompanyRepository.GetAllActive();
                Enigineers = UsersinfoRepository.GetAllActiveEngineers();
                var UploadedFiles = FaultRepository.GetFilesByFaultId(_customFault.Id);
                var fault = FaultRepository.GetFaultById(_customFault.Id);

                ddlCompany.DataSource = Companies;
                ddlCompany.DisplayMember = "Name";
                ddlCompany.ValueMember = "Id";

                ddlComplexity.DataSource = Complexities;
                ddlComplexity.DisplayMember = "Name";
                ddlComplexity.ValueMember = "Id";

                ddlPriority.DataSource = Priorities;
                ddlPriority.DisplayMember = "Name";
                ddlPriority.ValueMember = "Id";


                ddlAssignedTo.DataSource = Enigineers;
                ddlAssignedTo.DisplayMember = "Name";
                ddlAssignedTo.ValueMember = "Id";

                txtFaultDescription.Text = fault.FaultDescription;
                txtLocation.Text = fault.Location;
                txtMachineDescription.Text = fault.MachineDescription;
                ddlAssignedTo.SelectedValue = fault.AssignedTo;
                ddlCompany.SelectedValue = fault.CompanyId;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
