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

namespace NPD_Win_UI.UserControls
{
    public partial class ucViewJobs : UserControl
    {
        frmMaster _parent;
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
                var list = FaultRepository.GetFaults(new Fault()).ToList();
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
