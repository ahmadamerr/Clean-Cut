using CleanCut.GlobalClasses;
using System;
using static CleanCutBussiness.clsUser;
using static CleanCutBussiness.clsCustomer;
using System.Data;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmCustomers : Form
    {
        private DataTable _AllCustomers;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void _RefereshData()
        {
            _AllCustomers = GetAllCustomers();

            dgvCustomers.DataSource = _AllCustomers;

            lblRecordsCount.Text = _AllCustomers.Rows.Count.ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();

            _RefereshData();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.HasPermission(enPermissions.pCustomer))
            {
                MessageBox.Show("You don't have permission to access Customers Management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();

                return;
            }

            cbFilterBy.SelectedIndex = 0;

            _AllCustomers = GetAllCustomers();

            dgvCustomers.DataSource = _AllCustomers;

            lblRecordsCount.Text = _AllCustomers.Rows.Count.ToString();

            if (_AllCustomers.Rows.Count > 0)
            {
                dgvCustomers.Columns[0].HeaderText = "Customer ID";
                dgvCustomers.Columns[0].Width = 213;

                dgvCustomers.Columns[1].HeaderText = "Customer Name";
                dgvCustomers.Columns[1].Width = 213;

                dgvCustomers.Columns[2].HeaderText = "Customer Number";
                dgvCustomers.Columns[2].Width = 213;

                dgvCustomers.Columns[3].HeaderText = "Customer Debt";
                dgvCustomers.Columns[3].Width = 213;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer(Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerInfo frm = new frmCustomerInfo(Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            frmCustomerInfo frm = new frmCustomerInfo(Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();

            _RefereshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Customer [" + dgvCustomers.CurrentRow.Cells[1].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (DeleteCustomer(Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Customer Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefereshData();
                }
                else
                    MessageBox.Show("An Error Occurred, Customer was not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_AllCustomers == null) return;

            txtFilterValue.Visible = cbFilterBy.Text != "None";

            _AllCustomers.DefaultView.RowFilter = "";

            lblRecordsCount.Text = _AllCustomers.Rows.Count.ToString();

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";

                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text != "Name")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = txtFilterValue.Text.Trim();
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Name":
                    ColumnFilter = "CustomerName";
                    break;
                case "Customer ID":
                    ColumnFilter = "CustomerID";
                    break;
                case "Debt":
                    ColumnFilter = "CustomerDebt";
                    break;
                case "Number":
                    ColumnFilter = "CustomerNumber";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (FilterValue == "" || ColumnFilter == "None")
            {
                _AllCustomers.DefaultView.RowFilter = "";

                lblRecordsCount.Text = _AllCustomers.Rows.Count.ToString();

                return;
            }

            if (ColumnFilter == "CustomerName" || ColumnFilter == "CustomerNumber")
                _AllCustomers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, FilterValue);
            else
                _AllCustomers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", ColumnFilter, FilterValue);
        }

        private void payDebtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayDebt frm = new frmPayDebt(Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }
    }
}
