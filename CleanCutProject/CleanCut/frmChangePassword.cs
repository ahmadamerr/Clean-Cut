using CleanCut.GlobalClasses;
using CleanCutBussiness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmChangePassword : Form
    {
        private sbyte _UserId;
        private clsUser _User;

        public frmChangePassword(sbyte userId)
        {
            InitializeComponent();

            _UserId = userId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _User = clsUser.GetUserById(_UserId);

            if (_User == null)
            {
                MessageBox.Show("No User with this User ID. = " + _UserId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();

                return;
            }

            ctrlUserCard1.LoadUserInfo(_UserId);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtCurrentPassword, "Current Password field Cannot be blank");

                return;
            }
            else errorProvider1.SetError(txtCurrentPassword, "");

            if (_User.UserPassword != clsUtils.ComputeHash(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtCurrentPassword, "User's Current Password is incorrect");

                return;
            }
            else errorProvider1.SetError(txtCurrentPassword, "");
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtNewPassword, "New Password field Cannot be blank");

                e.Cancel = true;

                return;
            }
            else errorProvider1.SetError(txtNewPassword, "");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtConfirmPassword, "New Password field Cannot be blank");

                e.Cancel = true;

                return;
            }
            else errorProvider1.SetError(txtConfirmPassword, "");

            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "New Password and Confirm Password do not match");

                e.Cancel = true;

                return;
            }
            else errorProvider1.SetError(txtConfirmPassword, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _User.UserPassword = clsUtils.ComputeHash(txtNewPassword.Text.Trim());

            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _ResetDefualtValues();
            }
            else
                MessageBox.Show("An Error Occurred, Password was not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
