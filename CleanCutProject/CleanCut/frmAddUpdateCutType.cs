using CleanCutBussiness;
using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmAddUpdateCutType : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;

        private sbyte _CutTypeId;

        private clsCutType _CutType;

        public frmAddUpdateCutType()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddUpdateCutType(sbyte CutTypeId)
        {
            InitializeComponent();

            Mode = enMode.Update;

            _CutTypeId = CutTypeId;
        }

        private void _ResetDefaults()
        {
            if (Mode == enMode.AddNew)
            {
                Text = "Add New Cut Type";

                lblTitle.Text = "Add New Cut Type";

                _CutType = new clsCutType();
            }
            else
            {
                Text = "Update Cut Type";

                lblTitle.Text = "Update Cut Type";
            }

            txtCutName.Text = "";
            txtCutPrice.Text = "";
        }

        private void _LoadData()
        {
            _CutType = clsCutType.GetCutTypeById(_CutTypeId);

            if (_CutType == null)
            {
                MessageBox.Show("No Cut Type with this Cut Type ID. = " + _CutTypeId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();

                return;
            }

            txtCutName.Text = _CutType.CutTypeName;
            txtCutPrice.Text = _CutType.CutTypePrice.ToString();
        }

        private void frmAddUpdateCutType_Load(object sender, EventArgs e)
        {
            _ResetDefaults();

            if (Mode == enMode.Update) _LoadData();
        }

        private void txtCutPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtCutName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCutName.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtCutName, "Cut Name field Cannot be blank");
            }
            else
                errorProvider1.SetError(txtCutName, "");
        }

        private void txtCutPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCutPrice.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtCutPrice, "Cut Price field Cannot be blank");
            }
            else
                errorProvider1.SetError(txtCutPrice, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _CutType.CutTypeName = txtCutName.Text.Trim();
            _CutType.CutTypePrice = decimal.Parse(txtCutPrice.Text.Trim());

            if (_CutType.Save())
            {
                lblCutTypeId.Text = _CutType.CutTypeID.ToString();

                Mode = enMode.Update;

                lblTitle.Text = "Update Cut Type";

                Text = "Update Cut Type";

                MessageBox.Show("Cut Type saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("An error occurred while saving Cut Type information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
