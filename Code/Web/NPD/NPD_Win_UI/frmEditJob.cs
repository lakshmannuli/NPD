using NPD.DAL;
using NPD.DAL.EntityFramework;
using NPD.DAL.Repositories;
using NPD_Win_UI.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPD_Win_UI
{
    public partial class frmEditJob : Form
    {
        CustomFault _customFault;
        IEnumerable<FaultPriority> Priorities;
        IEnumerable<FaultComplexity> Complexities;
        IEnumerable<company> Companies;
        IEnumerable<UsersInfo> Enigineers;
        List<string> uploadedFiles = new List<string>();
        public frmEditJob()
        {
            InitializeComponent();
        }
        public frmEditJob(CustomFault customFault) : this()
        {
            _customFault = customFault;
            Load += FrmEditJob_Load;

        }

        private void FrmEditJob_Load(object sender, EventArgs e)
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
                ddlComplexity.SelectedValue = fault.Complexity;
                ddlPriority.SelectedValue = fault.Priority;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Files";
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\LibraryImages\"; 
            if (Directory.Exists(appPath) == false)                                            
            {                                                                                  
                Directory.CreateDirectory(appPath);                                            
            }
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    var ext = Path.GetExtension(file);
                    var modifiedPath = Guid.NewGuid().ToString();
                    File.Copy(file, appPath + modifiedPath);
                    richTextBox1.Text += file;
                    uploadedFiles.Add(modifiedPath);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(var file in uploadedFiles)
                {
                    var imageLibrary = new FaultLibrary();
                    imageLibrary.FileName = file;
                    imageLibrary.Url = file;
                    imageLibrary.FaultId = _customFault.Id;
                    imageLibrary.ModifiedBy = AuthenticatedDetails.LoggedUser.Id;
                    imageLibrary.ModifiedDate = DateTime.Now;
                    imageLibrary.CreatedDate = DateTime.Now;
                    imageLibrary.CreatedBy = AuthenticatedDetails.LoggedUser.Id;
                    FaultRepository.SaveFile(imageLibrary);
                }
                MessageBox.Show("Files Added Successfully !!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
