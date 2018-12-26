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
        List<FaultLibrary> UploadedFiles;
        List<string> uploadedFiles = new List<string>();

        public delegate void syncData();
        public syncData UpdateJobs;

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
                UploadedFiles = FaultRepository.GetFilesByFaultId(_customFault.Id).ToList();
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

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = UploadedFiles;

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

                var fault = FaultRepository.GetFaultById(_customFault.Id);
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

                FaultRepository.UpdateFault(fault);
                UpdateJobs();
                MessageBox.Show("Job Updated Successfully !!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    var modifiedPath = Guid.NewGuid().ToString()+ ext;
                    File.Copy(file, appPath + modifiedPath);
                    richTextBox1.Text += file;
                    uploadedFiles.Add(Path.GetFileName(file)  + '@' + modifiedPath);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var file in uploadedFiles)
                {
                    var imageLibrary = new FaultLibrary();
                    imageLibrary.FileName = file.Split('@')[0];
                    imageLibrary.Url = file.Split('@')[1];
                    imageLibrary.FaultId = _customFault.Id;
                    imageLibrary.ModifiedBy = AuthenticatedDetails.LoggedUser.Id;
                    imageLibrary.ModifiedDate = DateTime.Now;
                    imageLibrary.CreatedDate = DateTime.Now;
                    imageLibrary.CreatedBy = AuthenticatedDetails.LoggedUser.Id;
                    FaultRepository.SaveFile(imageLibrary);
                    UploadedFiles = FaultRepository.GetFilesByFaultId(_customFault.Id).ToList();
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = UploadedFiles;
                }
                MessageBox.Show("Files Added Successfully !!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            var fileObj = UploadedFiles[e.RowIndex];
            saveDialog.Title = "Save";
            saveDialog.FileName = fileObj.Url;
            saveDialog.Filter = "All Files (*.*)|*.*";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string file = saveDialog.FileName;
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\LibraryImages\";
                File.Copy(appPath + fileObj.Url, file);
            }
        }
    }
}
