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
using NPD.DAL;

namespace NPD_Win_UI.UserControls
{
    public partial class ucViewJobs : UserControl
    {
        frmMaster _parent;
        List<CustomFault> Faults { set; get; }
        public ucViewJobs()
        {
            InitializeComponent();
        }
        public ucViewJobs(frmMaster parent) : this()
        {
            _parent = parent;
            Load += UcViewJobs_Load;
        }

        private void UcViewJobs_Load(object sender, EventArgs e)
        {
            try
            {
                Faults = FaultRepository.GetFaults(new Fault()).ToList();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = Faults;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.RowIndex >= Faults.Count() - 1 && e.RowIndex <= Faults.Count() - 1)
                {
                    var faultObj = Faults[e.RowIndex];
                    frmEditJob obj = new frmEditJob(faultObj);
                    obj.ShowDialog();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get data", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
