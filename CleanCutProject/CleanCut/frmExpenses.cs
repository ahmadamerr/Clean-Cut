using CleanCut.GlobalClasses;
using System;
using static CleanCutBussiness.clsExpenses;
using static CleanCutBussiness.clsUser;
using System.Data;
using System.Windows.Forms;
using CleanCutBussiness;

namespace CleanCut
{
    public partial class frmExpenses : Form
    {
        private DataTable _AllExpenses;

        public frmExpenses()
        {
            InitializeComponent();
        }

        private void _RefreshExpensesData()
        {
            _AllExpenses = GetAllExpenses();

            dgvExpenses.DataSource = _AllExpenses;

            lblRecordsCount.Text = _AllExpenses.Rows.Count.ToString();
        }

        private void frmExpenses_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.HasPermission(enPermissions.pExpenses))
            {
                MessageBox.Show("You don't have permission to access Expenses Management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();

                return;
            }

            cbFilterBy.SelectedIndex = 0;

            _AllExpenses = GetAllExpenses();

            dgvExpenses.DataSource = _AllExpenses;

            lblRecordsCount.Text = _AllExpenses.Rows.Count.ToString();

            if (_AllExpenses.Rows.Count > 0)
            {
                dgvExpenses.Columns[0].HeaderText = "Expenses ID";
                dgvExpenses.Columns[0].Width = 142;

                dgvExpenses.Columns[1].HeaderText = "Amount";
                dgvExpenses.Columns[1].Width = 142;

                dgvExpenses.Columns[2].HeaderText = "Reason";
                dgvExpenses.Columns[2].Width = 142;

                dgvExpenses.Columns[3].HeaderText = "Made By User";
                dgvExpenses.Columns[3].Width = 142;

                dgvExpenses.Columns[4].HeaderText = "Date";
                dgvExpenses.Columns[4].Width = 142;

                dgvExpenses.Columns[5].HeaderText = "Daily Total Expenses";
                dgvExpenses.Columns[5].Width = 142;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpensesInfo frm = new frmExpensesInfo(Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells[0].Value));
            frm.ShowDialog();

            _RefreshExpensesData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvExpenses_DoubleClick(object sender, EventArgs e)
        {
            frmExpensesInfo frm = new frmExpensesInfo(Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells[0].Value));
            frm.ShowDialog();

            _RefreshExpensesData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateExpense frm = new frmAddUpdateExpense(Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells[0].Value));
            frm.ShowDialog();

            _RefreshExpensesData();
        }

        private void AddtoolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddUpdateExpense frm = new frmAddUpdateExpense();
            frm.ShowDialog();

            _RefreshExpensesData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateExpense frm = new frmAddUpdateExpense();
            frm.ShowDialog();

            _RefreshExpensesData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected expense?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (DeleteExpense(Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells[0].Value)))
                {
                    MessageBox.Show("Expense deleted successfully.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshExpensesData();
                }
                else
                {
                    MessageBox.Show("An error occurred while deleting the expense.", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_AllExpenses == null) return;

            txtFilterValue.Visible = cbFilterBy.Text != "None" && cbFilterBy.Text != "Date";
            dateTimePicker1.Visible = cbFilterBy.Text == "Date";

            _AllExpenses.DefaultView.RowFilter = "";

            lblRecordsCount.Text = _AllExpenses.Rows.Count.ToString();

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";

                txtFilterValue.Focus();
            }

            if (dateTimePicker1.Visible)
            {
                dateTimePicker1.Value = DateTime.Now;

                dateTimePicker1.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text != "Made By User")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = txtFilterValue.Text.Trim();
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Expenses ID":
                    ColumnFilter = "ExpensesId";
                    break;
                case "Expenses Amount":
                    ColumnFilter = "ExpenseAmount";
                    break;
                case "Made By User":
                    ColumnFilter = "MadeByUser";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (FilterValue == "" || ColumnFilter == "None")
            {
                _AllExpenses.DefaultView.RowFilter = "";

                lblRecordsCount.Text = _AllExpenses.Rows.Count.ToString();

                return;
            }

            if (ColumnFilter == "MadeByUser")
                _AllExpenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, FilterValue);
            else
                _AllExpenses.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", ColumnFilter, FilterValue);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text != "Date")
            {
                _AllExpenses.DefaultView.RowFilter = "";

                lblRecordsCount.Text = _AllExpenses.Rows.Count.ToString();

                return;
            }

            DateTime selectedDate = dateTimePicker1.Value.Date;

            _AllExpenses.DefaultView.RowFilter = string.Format(
                "CONVERT([ExpenseDate], 'System.DateTime') = #{0}#",
                selectedDate.ToString("MM/dd/yyyy")
            );

            lblRecordsCount.Text = _AllExpenses.DefaultView.Count.ToString();
        }
    }
}
