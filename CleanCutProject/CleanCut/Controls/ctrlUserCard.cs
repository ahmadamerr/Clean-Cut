using CleanCutBussiness;
using System.Windows.Forms;

namespace CleanCut.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;

        private sbyte _UserId;

        public sbyte UserId { get { return _UserId; } }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _ResetUserInfo()
        {
            lblName.Text = "????";
            lblPermessions.Text = "????";
            lblSalary.Text = "????";
            lblUserID.Text = "????";
        }

        private void _FillPersonInfo()
        {
            llEditUser.Enabled = true;

            _UserId = _User.UserID;

            lblName.Text = _User.UserName;
            lblPermessions.Text = _User.Permissions == -1 ? "Full" : "Partial";
            lblSalary.Text = _User.Salary == 0 ? "Undefined" : _User.Salary.ToString();
            lblUserID.Text = _User.UserID.ToString();
        }

        public void LoadUserInfo(sbyte userId)
        {
           _User = clsUser.GetUserById(userId);

            if (_User == null)
            {
                _ResetUserInfo();

                MessageBox.Show("No User with this User ID. = " + userId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillPersonInfo();
        }

        private void llEditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(_UserId);
            frm.ShowDialog();
        }
    }
}
