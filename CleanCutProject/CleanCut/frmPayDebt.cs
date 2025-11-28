using CleanCutBussiness;
using System.Windows.Forms;
using System;

namespace CleanCut
{
    public partial class frmPayDebt : Form
    {
        private int _CustomerId;

        private clsCustomer _Customer;

        public frmPayDebt(int customerId)
        {
            InitializeComponent();

            _CustomerId = customerId;
        }

        private void _ResetDefaults()
        {
            lblDebt.Text = "[????]";
            textBox1.Text = "";
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

            lblDebt.Text = _Customer.CustomerDebt.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPayDebt_Load(object sender, EventArgs e)
        {
            _ResetDefaults();

            _LoadData();
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(textBox1, "Your Debt Should be Paid.");
            }
            else
                errorProvider1.SetError(textBox1, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Convert.ToDecimal(textBox1.Text) > _Customer.CustomerDebt)
            {
                MessageBox.Show("The Paid Amount cannot be greater than the Customer Debt.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Customer.CustomerDebt -= Convert.ToDecimal(textBox1.Text);

            if (_Customer.Save())
            {
                lblDebt.Text = _Customer.CustomerDebt.ToString();

                MessageBox.Show("Customer Debt Paid Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("An Error Occurred, Customer Debt was not paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
