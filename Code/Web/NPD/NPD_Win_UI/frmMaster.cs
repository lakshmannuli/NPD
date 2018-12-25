﻿using System;
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
            LoadAllCompanies();
        }

        public void LoadAllCompanies()
        {
            frmViewCompanies frm = new frmViewCompanies(this);
            pnlMaster.Controls.Clear();
            pnlMaster.Controls.Add(frm);
            
        }
        public void AddCompanies()
        {
            frmAddClientCompanies frm = new frmAddClientCompanies(this);
            pnlMaster.Controls.Clear();
            pnlMaster.Controls.Add(frm);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCompanies();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAllCompanies();
        }
    }
}
