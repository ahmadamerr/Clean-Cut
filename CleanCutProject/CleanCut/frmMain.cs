using System;
using System.Windows.Forms;
using static CleanCut.GlobalClasses.clsGlobal;

namespace CleanCut
{
    public partial class frmMain : Form
    {
        frmLogin _frm;

        public frmMain(frmLogin frm)
        {
            InitializeComponent();

            _frm = frm;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            
            _frm.Show();
            Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void acountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.ShowDialog();
        }

        private void DeductionstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDeductions frm = new frmDeductions();
            frm.ShowDialog();
        }

        private void cutsomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.ShowDialog();
        }

        private void ExpensestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenses frm = new frmExpenses();
            frm.ShowDialog();
        }

        private void CutTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCutTypes frm = new frmCutTypes();
            frm.ShowDialog();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCut frm = new frmCut();
            frm.ShowDialog();
        }
    }
}
