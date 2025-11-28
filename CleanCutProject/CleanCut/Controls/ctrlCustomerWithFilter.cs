using CleanCutBussiness;
using System;
using System.Windows.Forms;

namespace CleanCut.Controls
{
    public partial class ctrlCustomerWithFilter : UserControl
    {
        private int _SelectedCustomerId = -1;
        public int SelectedCustomerId
        {
            get
            {
                return _SelectedCustomerId;
            }
            set
            {
                _SelectedCustomerId = value;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public event Action<int> OnCustomerSelected;
        protected virtual void MemberSelected(int CustomerId)
        {
            Action<int> handler = OnCustomerSelected;

            if (handler != null) handler(CustomerId);
        }

        public ctrlCustomerWithFilter()
        {
            InitializeComponent();
        }

        private void _Find()
        {
            switch (cbFilterBy.Text)
            {
                case "Name":
                    ctrlCustomerCard1.LoadCustomerByName(txtFilterValue.Text);
                    break;
                case "Number":
                    ctrlCustomerCard1.LoadCustomerByNumber(txtFilterValue.Text);
                    break;
                default:
                    break;
            }

            if (OnCustomerSelected != null && FilterEnabled)
                OnCustomerSelected(ctrlCustomerCard1.CustomerId);

            _SelectedCustomerId = ctrlCustomerCard1.CustomerId;
        }

        public void LoadData(int customerId)
        {
            cbFilterBy.SelectedIndex = 0;

            txtFilterValue.Text = clsCustomer.GetCustomerNameById(customerId);

            _Find();
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Find();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) btnFind.PerformClick();

            if (cbFilterBy.Text == "Number")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
        }

        private void ctrlCustomerWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            txtFilterValue.Focus();
        }

        private void DataBackEvent(object sender, int CustomerId)
        {
            txtFilterValue.Text = clsCustomer.GetCustomerById(CustomerId).CustomerName;

            _Find();
        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.DataBack += DataBackEvent;

            frm.ShowDialog();
        }
    }
}
