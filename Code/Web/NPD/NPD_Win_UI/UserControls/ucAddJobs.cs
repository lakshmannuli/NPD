using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPD.DAL.Repositories;
using NPD.DAL.EntityFramework;
using NPD_Win_UI.Custom;

namespace NPD_Win_UI.UserControls
{
    public partial class ucAddJobs : UserControl
    {
        frmMaster _parent;
        IEnumerable<FaultPriority> Priorities;
        IEnumerable<FaultComplexity> Complexities;
        IEnumerable<company> Companies;
        IEnumerable<UsersInfo> Enigineers;

        public ucAddJobs()
        {
            InitializeComponent();
        }

        public ucAddJobs(frmMaster parent) : this()
        {
            _parent = parent;
            Load += UcAddJobs_Load;
        }

        private void UcAddJobs_Load(object sender, EventArgs e)
        {
            try
            {
                Priorities = FaultPrioritiesRepository.GetActivePriorities();
                Complexities = FaultComplexityRepository.GetActiveComplexities();
                Companies = CompanyRepository.GetAllActive();
                Enigineers = UsersinfoRepository.GetAllActiveEngineers();
                //ViewBag.UploadedFiles = FaultRepository.GetFilesByFaultId(model.Id);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ddlCompany.SelectedValue) <= 0)
                {
                    MessageBox.Show("Please select company ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    MessageBox.Show("Please enter location", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convert.ToInt32(ddlPriority.SelectedValue) <= -1)
                {
                    MessageBox.Show("Please select priority ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convert.ToInt32(ddlComplexity.SelectedValue) <= -1)
                {
                    MessageBox.Show("Please select complexity ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convert.ToInt32(ddlAssignedTo.SelectedValue) <= 0)
                {
                    MessageBox.Show("Please select engineer ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var imageLibrary = new FaultLibrary();

                var fault = new Fault();
                fault.CreatedDate = DateTime.Now;
                fault.CreatedBy = AuthenticatedDetails.LoggedUser.Id;
                fault.Status = 1;
                fault.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                fault.Complexity = Convert.ToInt32(ddlComplexity.SelectedValue);
                fault.FaultDescription = txtFaultDescription.Text;
                fault.FaultStatus = Convert.ToInt32(ddlPriority.SelectedValue) < 1 ? 0 : 1;
                fault.Location = txtLocation.Text;
                fault.MachineDescription = txtMachineDescription.Text;
                fault.ModifiedBy = AuthenticatedDetails.LoggedUser.Id;
                fault.ModifiedDate = DateTime.Now;
                fault.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
                fault.StartDate = DateTime.Now;
                fault.AssignedTo = Convert.ToInt32(ddlAssignedTo.SelectedValue);
                fault.FaultLibraries = new List<FaultLibrary>();

                FaultRepository.SaveFault(fault);
                MessageBox.Show("Job Added Successfully !!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _parent.ViewJobs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
