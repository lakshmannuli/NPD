namespace NPD_Win_UI.UserControls
{
    partial class ucViewJobs
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaultDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complexity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(409, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "All Jobs";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyName,
            this.Location,
            this.FaultDescription,
            this.Priority,
            this.Complexity,
            this.AssignedTo,
            this.DisplayCreatedDate,
            this.DisplayStartDate});
            this.dataGridView1.Location = new System.Drawing.Point(27, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1137, 346);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.HeaderText = "CompanyName";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.Width = 200;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 200;
            // 
            // FaultDescription
            // 
            this.FaultDescription.DataPropertyName = "FaultDescription";
            this.FaultDescription.HeaderText = "FaultDescription";
            this.FaultDescription.Name = "FaultDescription";
            this.FaultDescription.ReadOnly = true;
            this.FaultDescription.Width = 250;
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // Complexity
            // 
            this.Complexity.DataPropertyName = "Complexity";
            this.Complexity.HeaderText = "Complexity";
            this.Complexity.Name = "Complexity";
            this.Complexity.ReadOnly = true;
            // 
            // AssignedTo
            // 
            this.AssignedTo.DataPropertyName = "AssignedTo";
            this.AssignedTo.HeaderText = "AssignedTo";
            this.AssignedTo.Name = "AssignedTo";
            this.AssignedTo.ReadOnly = true;
            // 
            // DisplayCreatedDate
            // 
            this.DisplayCreatedDate.DataPropertyName = "DisplayCreatedDate";
            this.DisplayCreatedDate.HeaderText = "DisplayCreatedDate";
            this.DisplayCreatedDate.Name = "DisplayCreatedDate";
            this.DisplayCreatedDate.ReadOnly = true;
            // 
            // DisplayStartDate
            // 
            this.DisplayStartDate.DataPropertyName = "DisplayStartDate";
            this.DisplayStartDate.HeaderText = "DisplayStartDate";
            this.DisplayStartDate.Name = "DisplayStartDate";
            this.DisplayStartDate.ReadOnly = true;
            // 
            // ucViewJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "ucViewJobs";
            this.Size = new System.Drawing.Size(1179, 482);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaultDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Complexity;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayCreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayStartDate;
    }
}
