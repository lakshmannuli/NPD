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
using NPD_Win_UI.Custom;
using NPD.DAL.Repositories;

namespace NPD_Win_UI.UserControls
{
    public partial class frmAddClientCompanies : UserControl
    {
        public frmAddClientCompanies()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCompanyName.Text))
                {
                    MessageBox.Show("Please enter company name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var company = new company()
                {
                    Address = richTextBox1.Text,
                    Name = txtCompanyName.Text,
                    CreatedBy = AuthenticatedDetails.LoggedUser.Id,
                    CreatedDate = DateTime.Now,
                    Email = txtEmail.Text,
                    Fax = txtFax.Text,
                    ModifiedBy = AuthenticatedDetails.LoggedUser.Id,
                    ModifiedDate = DateTime.Now,
                    Phone = txtPhone.Text,
                    Status = 1
                };

                CompanyRepository.SaveCompany(company);
                MessageBox.Show("Company Added Successfully !!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save company", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
