using CleanCut.GlobalClasses;
using System;
using System.Data;
using System.Windows.Forms;
using static CleanCutBussiness.clsUser;
using static CleanCutBussiness.clsDeduction;

namespace CleanCut
{
    public partial class frmDeductions : Form
    {
        private DataTable _AllDeductions;

        public frmDeductions()
        {
            InitializeComponent();
        }

        private void _RefereshData()
        {
            _AllDeductions = GetAllDeductions();

            dgvDeductions.DataSource = _AllDeductions;

            lblRecordsCount.Text = _AllDeductions.Rows.Count.ToString();
        }

        private void frmDeductions_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.HasPermission(enPermissions.PDeductions))
            {
                MessageBox.Show("You don't have permission to access Deductions Management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();

                return;
            }

            cbFilterBy.SelectedIndex = 0;

            _AllDeductions = GetAllDeductions();

            dgvDeductions.DataSource = _AllDeductions;

            lblRecordsCount.Text = _AllDeductions.Rows.Count.ToString();

            if (_AllDeductions.Rows.Count > 0)
            {
                dgvDeductions.Columns[0].HeaderText = "Deduction ID";
                dgvDeductions.Columns[0].Width = 167;

                dgvDeductions.Columns[1].HeaderText = "Username";
                dgvDeductions.Columns[1].Width = 168;

                dgvDeductions.Columns[2].HeaderText = "Deduction Amount";
                dgvDeductions.Columns[2].Width = 168;

                dgvDeductions.Columns[3].HeaderText = "Date";
                dgvDeductions.Columns[3].Width = 168;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateDeduction frm = new frmAddUpdateDeduction(Convert.ToInt32(dgvDeductions.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeductionInfo frm = new frmDeductionInfo(Convert.ToInt32(dgvDeductions.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void dgvDeductions_DoubleClick(object sender, EventArgs e)
        {
            frmDeductionInfo frm = new frmDeductionInfo(Convert.ToInt32(dgvDeductions.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Deduction [" + dgvDeductions.CurrentRow.Cells[1].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (DeleteDeduction(Convert.ToInt32(dgvDeductions.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Deduction Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefereshData();
                }
                else
                    MessageBox.Show("An Error Occurred, Deduction was not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_AllDeductions == null) return;

            txtFilterValue.Visible = cbFilterBy.Text != "None" && cbFilterBy.Text != "Date";
            dateTimePicker1.Visible = cbFilterBy.Text == "Date";

            _AllDeductions.DefaultView.RowFilter = "";

            lblRecordsCount.Text = _AllDeductions.Rows.Count.ToString();

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
            if (cbFilterBy.Text != "Username")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = txtFilterValue.Text.Trim();
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Deduction ID":
                    ColumnFilter = "DeductionID";
                    break;
                case "Username":
                    ColumnFilter = "UserName";
                    break;
                case "Amount":
                    ColumnFilter = "Amount";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (FilterValue == "" || ColumnFilter == "None")
            {
                _AllDeductions.DefaultView.RowFilter = "";

                lblRecordsCount.Text = _AllDeductions.Rows.Count.ToString();

                return;
            }

            if (ColumnFilter == "UserName")
                _AllDeductions.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, FilterValue);
            else
                _AllDeductions.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", ColumnFilter, FilterValue);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;

            _AllDeductions.DefaultView.RowFilter = string.Format(
                "CONVERT([Date], 'System.DateTime') = #{0}#",
                selectedDate.ToString("MM/dd/yyyy")
            );

            lblRecordsCount.Text = _AllDeductions.DefaultView.Count.ToString();
        }
    }
}
