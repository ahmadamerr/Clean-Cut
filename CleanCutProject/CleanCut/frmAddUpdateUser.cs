using CleanCut.GlobalClasses;
using CleanCutBussiness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        private clsUser _User;

        private sbyte _UserID = -1;
        public sbyte UserID
        {
            get { return _UserID; }
        }

        private short _permissions;

        public frmAddUpdateUser()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(sbyte userID)
        {
            InitializeComponent();

            Mode = enMode.Update;

            _UserID = userID;
        }

        private void _ResetDefaults()
        {
            if (Mode == enMode.AddNew)
            {
                Text = "Add New User";

                lblTitle.Text = "Add New User";

                _User = new clsUser();
            }
            else if (Mode == enMode.Update)
            {
                Text = "Update User";

                lblTitle.Text = "Update User";
            }

            txtUserName.Text = "";
            txtSalary.Text = "";

            foreach (Control ctrl in gbPermissions.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                }
            }
        }

        private void _LoadPermissions(short permissions)
        {
            if (_UserID == 1)
            {
                gbPermissions.Enabled = false;
            }

            if (permissions == -1)
            {
                foreach (Control ctrl in gbPermissions.Controls)
                {
                    if (ctrl is CheckBox chk) chk.Checked = true;
                }

                return;
            }

            foreach (Control ctrl in gbPermissions.Controls)
            {
                if (ctrl is CheckBox chk && chk.Tag != null)
                {
                    short permValue = Convert.ToInt16(chk.Tag);

                    chk.Checked = (permissions & permValue) == permValue;
                }
            }
        }

        private void _LoadData()
        {
            _User = clsUser.GetUserById(_UserID);

            if (_User == null)
            {
                _ResetDefaults();

                MessageBox.Show("No User with this User ID. = " + _UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblUserId.Text = _User.UserID.ToString();

            txtUserName.Text = _User.UserName;
            txtSalary.Text = _User.Salary == 0 ? "Undefined" : _User.Salary.ToString();
            _permissions = _User.Permissions;

            _LoadPermissions(_permissions);
        }

        private void UpdatePermissions(short permission, bool isChecked)
        {
            if (isChecked)
                _permissions |= permission;  
            else
                _permissions &= (short)~permission;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            short perm = Convert.ToInt16(cb.Tag);

            UpdatePermissions(perm, cb.Checked);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaults();

            if (Mode == enMode.Update) _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cbAll.Checked;

            foreach (Control ctrl in gbPermissions.Controls)
            {
                if (ctrl is CheckBox chk && chk != cbAll)
                {
                    chk.Checked = isChecked;
                    chk.Enabled = !isChecked; 
                }
            }

            _permissions = isChecked ? (short)-1 : (short)0;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtUserName, "This field is required!");
            }
            else if (clsUser.DoesUserExist(txtUserName.Text) && Mode != enMode.Update)
            {
                e.Cancel = true;

                errorProvider1.SetError(txtUserName, "This name already exists. Ask them for an additional name!");
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalary.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtSalary, "This field is required!");
            }
            else
                errorProvider1.SetError(txtSalary, "");
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _User.UserName = txtUserName.Text.Trim();
            _User.Salary = txtSalary.Text == "" ? Convert.ToDecimal(null) : Convert.ToDecimal(txtSalary.Text);
            _User.Permissions = _permissions;
            _User.UserPassword = clsUtils.ComputeHash(txtPassword.Text.Trim());

            if (_User.Save())
            {
                _UserID = _User.UserID;

                lblUserId.Text = _User.UserID.ToString();

                Mode = enMode.Update;

                lblTitle.Text = "Update User";

                Text = "Update User";

                MessageBox.Show("User information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("An error occurred, user information was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;    

                errorProvider1.SetError(txtPassword, "Password field Cannot be blank");
            }
            else
                errorProvider1.SetError(txtPassword, "");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtConfirmPassword, "Confirm Password field Cannot be blank");
            }
            else if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                e.Cancel = true;

                errorProvider1.SetError(txtConfirmPassword, "Password and Confirm Password do not match");
            }
            else
                errorProvider1.SetError(txtConfirmPassword, "");
        }
    }
}
