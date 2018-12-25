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

namespace NPD_Win_UI.UserControls
{
    public partial class frmViewCompanies : UserControl
    {
        frmMaster _parent;
        public frmViewCompanies()
        {
            InitializeComponent();
        }
        public frmViewCompanies(frmMaster parent) : this()
        {
            _parent = parent;
            Load += FrmViewCompanies_Load;
        }

        private void FrmViewCompanies_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;

                var list = CompanyRepository.GetAllActive().ToList();
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load companies", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
