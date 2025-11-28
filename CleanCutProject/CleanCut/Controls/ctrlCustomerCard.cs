using CleanCutBussiness;
using System.Windows.Forms;

namespace CleanCut.Controls
{
    public partial class ctrlCustomerCard : UserControl
    {
        private clsCustomer _Customer;

        private int _CustomerId;    

        public int CustomerId { get { return _CustomerId; } }

        public ctrlCustomerCard()
        {
            InitializeComponent();
        }

        private void _ResetCustomerInfo()
        {
            lblName.Text = "????";
            lblNumber.Text = "????";
            lblDebt.Text = "????";
            lblCustomerID.Text = "????";
        }

        private void _FillCustomerInfo()
        {
            llEditCustomer.Enabled = true;

            _CustomerId = _Customer.CustomerID;

            lblName.Text = _Customer.CustomerName;
            lblNumber.Text = _Customer.CustomerNumber;
            lblDebt.Text = _Customer.CustomerDebt.ToString();
            lblCustomerID.Text = _Customer.CustomerID.ToString();
        }

        public void LoadCustomerById(int customerId)
        {
           _Customer = clsCustomer.GetCustomerById(customerId);

            if (_Customer == null)
            {
                _ResetCustomerInfo();

                MessageBox.Show("No Customer with this Customer ID. = " + customerId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillCustomerInfo();
        }

        public void LoadCustomerByNumber(string customerNumber)
        {
            _Customer = clsCustomer.GetCustomerByNumber(customerNumber);

            if (_Customer == null)
            {
                _ResetCustomerInfo();

                MessageBox.Show("No Customer with this Customer Number. = " + customerNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillCustomerInfo();
        }

        public void LoadCustomerByName(string customerName)
        {
            _Customer = clsCustomer.GetCustomerByName(customerName);

            if (_Customer == null)
            {
                _ResetCustomerInfo();

                MessageBox.Show("No Customer with this Customer Name. = " + customerName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillCustomerInfo();
        }

        private void llEditCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer(_CustomerId);
            frm.ShowDialog();
        }
    }
}
