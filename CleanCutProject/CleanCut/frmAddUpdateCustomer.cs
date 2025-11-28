using CleanCutBussiness;
using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmAddUpdateCustomer : Form
    {
        public delegate void DataBackEventHandler(object sender, int CustomerId);
        public event DataBackEventHandler DataBack;

        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        private clsCustomer _Customer;
        private int _CustomerId;

        public frmAddUpdateCustomer()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddUpdateCustomer(int customerId)
        {
            InitializeComponent();

            _CustomerId = customerId;

            Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _ResetDefaults()
        {
            if (Mode == enMode.AddNew)
            {
                Text = "Add New Customer";

                lblTitle.Text = "Add New Customer";

                _Customer = new clsCustomer();
            }
            else
            {
                Text = "Update Customer";

                lblTitle.Text = "Update Customer";
            }

            txtName.Text = "";
            txtDebt.Text = "";
            txtNumber.Text = "";
        }

        private void _LoadData()
        {
            _Customer = clsCustomer.GetCustomerById(_CustomerId);

            if (_Customer == null)
            {
                _ResetDefaults();

                MessageBox.Show("No Customer with this Customer ID. = " + _CustomerId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txtName.Text = _Customer.CustomerName;
            txtDebt.Text = _Customer.CustomerDebt.ToString();
            txtNumber.Text = _Customer.CustomerNumber;
        }

        private void frmAddUpdateCustomer_Load(object sender, EventArgs e)
        {
            _ResetDefaults();

            if (Mode == enMode.Update) _LoadData();
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtName, "Customer Name field Cannot be blank");
            }
            else
                errorProvider1.SetError(txtName, "");
        }

        private void txtNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumber.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtNumber, "Customer Number field Cannot be blank");
            }
            else
                errorProvider1.SetError(txtNumber, "");
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDebt_KeyPress(object sender, KeyPressEventArgs e)
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

            _Customer.CustomerName = txtName.Text.Trim();
            _Customer.CustomerNumber = txtNumber.Text.Trim();
            _Customer.CustomerDebt = string.IsNullOrEmpty(txtDebt.Text.Trim()) ? 0 : Convert.ToDecimal(txtDebt.Text.Trim());

            if (_Customer.Save())
            {
                lblCustomerId.Text = _Customer.CustomerID.ToString();

                Mode = enMode.Update;

                lblTitle.Text = "Update Customer";

                Text = "Update Customer";

                MessageBox.Show("Customer information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Customer.CustomerID);
            }
            else
                MessageBox.Show("An error occurred, Customer information was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
