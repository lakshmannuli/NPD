using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPD_Win_UI.UserControls;

namespace NPD_Win_UI
{
    public partial class frmMaster : Form
    {
        public frmMaster()
        {
            InitializeComponent();
            frmAddClientCompanies frm = new frmAddClientCompanies();
            pnlMaster.Controls.Add(frm);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
