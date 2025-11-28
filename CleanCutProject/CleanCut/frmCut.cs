using CleanCut.GlobalClasses;
using System;
using System.Data;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
using static CleanCutBussiness.clsCut;
using static CleanCutBussiness.clsUser;

namespace CleanCut
{
    public partial class frmCut : Form
    {
        private DataTable _AllCut;

        public frmCut()
        {
            InitializeComponent();
        }

        private void _RefereshData()
        {
            _AllCut = GetAllCut();

            dgvCut.DataSource = _AllCut;

            lblRecordsCount.Text = _AllCut.Rows.Count.ToString();
        }   

        private void frmCut_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.HasPermission(enPermissions.pCut))
            {
                MessageBox.Show("You don't have permission to access Cut Management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();

                return;
            }

            cbFilterBy.SelectedIndex = 0;

            _AllCut = GetAllCut();

            dgvCut.DataSource = _AllCut;

            lblRecordsCount.Text = _AllCut.Rows.Count.ToString();

            if (_AllCut.Rows.Count > 0)
            {
                dgvCut.Columns[0].HeaderText = "Customer ID";
                dgvCut.Columns[0].Width = 121;

                dgvCut.Columns[1].HeaderText = "Barber Name";
                dgvCut.Columns[1].Width = 122;

                dgvCut.Columns[2].HeaderText = "Customer Name";
                dgvCut.Columns[2].Width = 122;

                dgvCut.Columns[3].HeaderText = "Made By User";
                dgvCut.Columns[3].Width = 122;

                dgvCut.Columns[4].HeaderText = "Cut Date";
                dgvCut.Columns[4].Width = 122;

                dgvCut.Columns[5].HeaderText = "Paid Fees";
                dgvCut.Columns[5].Width = 121;

                dgvCut.Columns[6].HeaderText = "Daily Earnings";
                dgvCut.Columns[6].Width = 122;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateCut frm = new frmAddUpdateCut();
            frm.ShowDialog();

            _RefereshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCutInfo frm = new frmCutInfo(Convert.ToInt32(dgvCut.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void dgvCut_DoubleClick(object sender, EventArgs e)
        {
            frmCutInfo frm = new frmCutInfo(Convert.ToInt32(dgvCut.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCut frm = new frmAddUpdateCut(Convert.ToInt32(dgvCut.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Cut for customer [" + dgvCut.CurrentRow.Cells[2].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (DeleteCut(Convert.ToInt32(dgvCut.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Cut Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefereshData();
                }
                else
                    MessageBox.Show("An Error Occurred, Cut was not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_AllCut == null) return;

            txtFilterValue.Visible = cbFilterBy.Text != "None" && cbFilterBy.Text != "Cut Date";
            dateTimePicker1.Visible = cbFilterBy.Text == "Cut Date";

            _AllCut.DefaultView.RowFilter = "";
            lblRecordsCount.Text = _AllCut.Rows.Count.ToString();

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
            if (cbFilterBy.Text == "Paid Fees" || cbFilterBy.Text == "Cut ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = txtFilterValue.Text.Trim();
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Cut ID":
                    ColumnFilter = "CutId";
                    break;
                case "Paid Fees":
                    ColumnFilter = "PaidFees";
                    break;
                case "Customer Name":
                    ColumnFilter = "CustomerName";
                    break;
                case "Barber Name":
                    ColumnFilter = "BarberName";
                    break;
                default: ColumnFilter = "None";
                    return;
            }

            if (FilterValue == "" || ColumnFilter == "None")
            {
                _AllCut.DefaultView.RowFilter = "";

                lblRecordsCount.Text = _AllCut.Rows.Count.ToString();

                return;
            }

            if (ColumnFilter == "PaidFees" || ColumnFilter == "CutId")
                _AllCut.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", ColumnFilter, FilterValue);
            else
                _AllCut.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, FilterValue);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text != "Cut Date")
            {
                _AllCut.DefaultView.RowFilter = "";

                lblRecordsCount.Text = _AllCut.Rows.Count.ToString();

                return;
            }

            DateTime selectedDate = dateTimePicker1.Value.Date;

            _AllCut.DefaultView.RowFilter = string.Format(
                "CONVERT([CutDate], 'System.DateTime') = #{0}#",
                selectedDate.ToString("MM/dd/yyyy")
            );

            lblRecordsCount.Text = _AllCut.DefaultView.Count.ToString();
        }
    }
}
