using NPD.DAL.Repositories;
using NPD.ViewModel;
using NPD_Win_UI.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPD_Win_UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            AuthenticatedDetails.LoggedUser = null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                var user = UsersinfoRepository.ValidateUser(new NPD.DAL.EntityFramework.UsersInfo() { Email = txtUserName.Text, Password = txtPassword.Text });
                if (user == null)
                {
                    MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var loggedUser = new LoggedUser()
                {
                    Id = user.Id,
                    Name = user.Name,
                    RoleId = Convert.ToInt32(user.RoleId),
                    UserName = user.Email,
                    Password = txtPassword.Text
                };
                AuthenticatedDetails.LoggedUser = loggedUser;
                frmMaster obj = new frmMaster();
                obj.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to login", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
