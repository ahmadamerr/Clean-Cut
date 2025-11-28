using CleanCut.GlobalClasses;
using CleanCutBussiness;
using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindByUserNameAndPassword(
                txtUserName.Text.Trim(),
                clsUtils.ComputeHash(txtPassword.Text.Trim()));

            if (user != null)
            {
                Hide();

                clsGlobal.CurrentUser = user;

                frmMain frm = new frmMain(this);
                frm.ShowDialog();

                txtUserName.Text = "";
                txtPassword.Text = "";

                txtUserName.Focus();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
    }
}
