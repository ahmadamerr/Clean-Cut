using System;
using System.Windows.Forms;
using CleanCut.GlobalClasses;
using static CleanCutBussiness.clsUser;
using static CleanCutBussiness.clsCutType;
using System.Data;

namespace CleanCut
{
    public partial class frmCutTypes : Form
    {
        private DataTable _AllCutTypes;

        public frmCutTypes()
        {
            InitializeComponent();
        }

        private void _RefereshData()
        {
            _AllCutTypes = GetAllCutTypes();

            dgvCutTypes.DataSource = _AllCutTypes;

            lblRecordsCount.Text = _AllCutTypes.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCutTypes_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.HasPermission(enPermissions.pCutTypes))
            {
                MessageBox.Show("You don't have permission to access Cut Types Management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();

                return;
            }

            cbFilterBy.SelectedIndex = 0;

            _AllCutTypes = GetAllCutTypes();

            dgvCutTypes.DataSource = _AllCutTypes;

            lblRecordsCount.Text = _AllCutTypes.Rows.Count.ToString();

            if (_AllCutTypes.Rows.Count > 0)
            {
                dgvCutTypes.Columns[0].HeaderText = "Cut Type ID";
                dgvCutTypes.Columns[0].Width = 284;

                dgvCutTypes.Columns[1].HeaderText = "Cut Name";
                dgvCutTypes.Columns[1].Width = 284;

                dgvCutTypes.Columns[2].HeaderText = "Cut Price";
                dgvCutTypes.Columns[2].Width = 284;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCutTypeInfo frm = new frmCutTypeInfo(Convert.ToSByte(dgvCutTypes.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void dgvCutTypes_DoubleClick(object sender, EventArgs e)
        {
            frmCutTypeInfo frm = new frmCutTypeInfo(Convert.ToSByte(dgvCutTypes.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateCutType frm = new frmAddUpdateCutType();
            frm.ShowDialog();

            _RefereshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCutType frm = new frmAddUpdateCutType(Convert.ToSByte(dgvCutTypes.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Cut Type [" + dgvCutTypes.CurrentRow.Cells[1].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (DeleteCutType(Convert.ToSByte(dgvCutTypes.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("This Cut Type Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefereshData();
                }
                else
                    MessageBox.Show("An Error Occurred, Cut Type was not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_AllCutTypes == null) return;

            txtFilterValue.Visible = cbFilterBy.Text != "None";

            _AllCutTypes.DefaultView.RowFilter = "";

            lblRecordsCount.Text = _AllCutTypes.Rows.Count.ToString();

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";

                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text != "Cut Name")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = txtFilterValue.Text.Trim();
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Cut ID":
                    ColumnFilter = "TypesID";
                    break;
                case "Cut Name":
                    ColumnFilter = "CutName";
                    break;
                case "Cut Price":
                    ColumnFilter = "Fees";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (FilterValue == "" || ColumnFilter == "None")
            {
                _AllCutTypes.DefaultView.RowFilter = "";

                lblRecordsCount.Text = _AllCutTypes.Rows.Count.ToString();

                return;
            }

            if (ColumnFilter == "CutName")
                _AllCutTypes.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, FilterValue);
            else
                _AllCutTypes.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", ColumnFilter, FilterValue);
        }
    }
}
