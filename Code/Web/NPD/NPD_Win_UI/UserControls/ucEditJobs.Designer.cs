namespace NPD_Win_UI.UserControls
{
    partial class ucEditJobs
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
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlAssignedTo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlComplexity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlPriority = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFaultDescription = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlCompany = new System.Windows.Forms.ComboBox();
            this.txtMachineDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(599, 503);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Save Details";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlAssignedTo
            // 
            this.ddlAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAssignedTo.FormattingEnabled = true;
            this.ddlAssignedTo.Location = new System.Drawing.Point(477, 453);
            this.ddlAssignedTo.Name = "ddlAssignedTo";
            this.ddlAssignedTo.Size = new System.Drawing.Size(397, 21);
            this.ddlAssignedTo.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Assigned To";
            // 
            // ddlComplexity
            // 
            this.ddlComplexity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlComplexity.FormattingEnabled = true;
            this.ddlComplexity.Location = new System.Drawing.Point(477, 401);
            this.ddlComplexity.Name = "ddlComplexity";
            this.ddlComplexity.Size = new System.Drawing.Size(397, 21);
            this.ddlComplexity.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Complexity";
            // 
            // ddlPriority
            // 
            this.ddlPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPriority.FormattingEnabled = true;
            this.ddlPriority.Location = new System.Drawing.Point(477, 353);
            this.ddlPriority.Name = "ddlPriority";
            this.ddlPriority.Size = new System.Drawing.Size(397, 21);
            this.ddlPriority.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Priority";
            // 
            // txtFaultDescription
            // 
            this.txtFaultDescription.Location = new System.Drawing.Point(477, 249);
            this.txtFaultDescription.Name = "txtFaultDescription";
            this.txtFaultDescription.Size = new System.Drawing.Size(397, 71);
            this.txtFaultDescription.TabIndex = 42;
            this.txtFaultDescription.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Fault Description";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(477, 108);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(397, 20);
            this.txtLocation.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(359, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Location";
            // 
            // ddlCompany
            // 
            this.ddlCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCompany.FormattingEnabled = true;
            this.ddlCompany.Location = new System.Drawing.Point(477, 66);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Size = new System.Drawing.Size(397, 21);
            this.ddlCompany.TabIndex = 38;
            // 
            // txtMachineDescription
            // 
            this.txtMachineDescription.Location = new System.Drawing.Point(477, 153);
            this.txtMachineDescription.Name = "txtMachineDescription";
            this.txtMachineDescription.Size = new System.Drawing.Size(397, 71);
            this.txtMachineDescription.TabIndex = 37;
            this.txtMachineDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Machine Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Company";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(579, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 26);
            this.label1.TabIndex = 34;
            this.label1.Text = "Edit Job";
            // 
            // ucEditJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ddlAssignedTo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ddlComplexity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddlPriority);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFaultDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ddlCompany);
            this.Controls.Add(this.txtMachineDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucEditJobs";
            this.Size = new System.Drawing.Size(1243, 566);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlAssignedTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlComplexity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlPriority;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtFaultDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlCompany;
        private System.Windows.Forms.RichTextBox txtMachineDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
