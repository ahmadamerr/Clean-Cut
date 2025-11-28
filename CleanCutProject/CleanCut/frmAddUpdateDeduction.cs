using CleanCutBussiness;
using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmAddUpdateDeduction : Form
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        private clsDeduction _Deduction;

        private int _DeductionId;

        private sbyte  _UserId = -1;

        public frmAddUpdateDeduction()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddUpdateDeduction(int deductionId)
        {
            InitializeComponent();

            _DeductionId = deductionId;

            Mode = enMode.Update;
        }

        public frmAddUpdateDeduction(sbyte userId)
        {
            InitializeComponent();

            _UserId = userId;

            Mode = enMode.AddNew;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddUpdateDeduction_Load(object sender, EventArgs e)
        {
            _ResetDefaults();

            if (Mode == enMode.Update) _LoadData();
        }

        private void _ResetDefaults()
        {
            if (Mode == enMode.AddNew)
            {
                Text = "Add New Deduction";

                lblTitle.Text = "Add New Deduction";

                _Deduction = new clsDeduction();

                _Deduction.UserID = _UserId;
            }
            else if (Mode == enMode.Update)
            {
                Text = "Update Deduction";

                lblTitle.Text = "Update Deduction";
            }
        }

        private void _LoadData()
        {
            _Deduction = clsDeduction.GetDeductionById(_DeductionId);

            if (_Deduction == null)
            {
                _ResetDefaults();

                MessageBox.Show("No Deduction with this Deduction ID. = " + _DeductionId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDeductionId.Text = _Deduction.DeductionID.ToString();
            txtAmount.Text = _Deduction.DeductionAmount.ToString();
            txtDetails.Text = _Deduction.Reason;
            lblUserName.Text = clsUser.GetUserNameById(_Deduction.UserID);
        }

        private void txtAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtAmount, "Deduction Amount field Cannot be blank");
            }
            else errorProvider1.SetError(txtAmount, "");
        }

        private void txtDetails_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDetails.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtDetails, "Deduction Details field Cannot be blank");
            }
            else errorProvider1.SetError(txtDetails, "");
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

            if (Mode == enMode.AddNew)
            {
                if (_UserId != -1)
                    _Deduction.UserID = _UserId; 
                else
                    _Deduction.UserID = clsUser.GetUserIdByName(lblUserName.Text); 
            }

            _Deduction.DeductionAmount = Convert.ToDecimal(txtAmount.Text);
            _Deduction.Reason = txtDetails.Text;
            _Deduction.DeductionDate = DateTime.Now;

            if (_Deduction.Save())
            {
                lblDeductionId.Text = _Deduction.DeductionID.ToString();

                lblUserName.Text = clsUser.GetUserNameById(_Deduction.UserID);

                Mode = enMode.Update;

                lblTitle.Text = "Update Deduction";

                Text = "Update Deduction";  

                MessageBox.Show("Deduction saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("An error occurred, Deduction was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
