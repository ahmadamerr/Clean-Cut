using CleanCut.GlobalClasses;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static CleanCutBussiness.clsUser;

namespace CleanCut
{
    public partial class frmUsers : Form
    {
        private DataTable _AllUsers;

        public frmUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _RefereshData()
        {
            _AllUsers = GetAllUsers();

            dgvUsers.DataSource = _AllUsers;

            lblRecordsCount.Text = _AllUsers.Rows.Count.ToString();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.HasPermission(enPermissions.pUsers))
            {
                MessageBox.Show("You don't have permission to access Users Management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();

                return;
            }

            cbFilterBy.SelectedIndex = 0;

            _AllUsers = GetAllUsers();

            dgvUsers.DataSource = _AllUsers;

            lblRecordsCount.Text = _AllUsers.Rows.Count.ToString();

            if (_AllUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 213;

                dgvUsers.Columns[1].HeaderText = "User Name";
                dgvUsers.Columns[1].Width = 213;

                dgvUsers.Columns[2].HeaderText = "Permissions";
                dgvUsers.Columns[2].Width = 213;

                dgvUsers.Columns[3].HeaderText = "Salary";
                dgvUsers.Columns[3].Width = 213;
            }
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!clsGlobal.CurrentUser.HasPermission(enPermissions.pAll))
            {
                if (dgvUsers.Columns[e.ColumnIndex].Name == "Salary")
                {
                    e.Value = ""; 
                    e.CellStyle.ForeColor = Color.Gray;
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(Convert.ToSByte(dgvUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(Convert.ToSByte(dgvUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(Convert.ToSByte(dgvUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(dgvUsers.CurrentRow.Cells[0].Value) == 1)
            {
                MessageBox.Show("An Error Occurred, User was not deleted because it is Admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Convert.ToSByte(dgvUsers.CurrentRow.Cells[0].Value) == clsGlobal.CurrentUser.UserID)
            {
                MessageBox.Show("An Error Occurred, User was not deleted because it is Current User.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this User [" + dgvUsers.CurrentRow.Cells[1].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (DeleteUser(Convert.ToSByte(dgvUsers.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefereshData();
                }
                else
                    MessageBox.Show("An Error Occurred, User was not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            _RefereshData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            _RefereshData();
        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(Convert.ToSByte(dgvUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _RefereshData();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddUpdateDeduction frm = new frmAddUpdateDeduction(Convert.ToSByte(dgvUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_AllUsers == null) return;

            txtFilterValue.Visible = cbFilterBy.Text != "None";

            _AllUsers.DefaultView.RowFilter = "";

            lblRecordsCount.Text = _AllUsers.Rows.Count.ToString();

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";

                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User ID" || cbFilterBy.Text == "Salary")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = txtFilterValue.Text.Trim();
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    ColumnFilter = "UserID";
                    break;
                case "Name":
                    ColumnFilter = "UserName";
                    break;
                case "Salary":
                    ColumnFilter = "Salary";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (FilterValue == "" || ColumnFilter == "None")
            {
                _AllUsers.DefaultView.RowFilter = "";

                lblRecordsCount.Text = _AllUsers.Rows.Count.ToString();

                return;
            }

            if (ColumnFilter == "UserName")
                _AllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, FilterValue);
            else
                _AllUsers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", ColumnFilter, FilterValue);
        }

        private void cbPermessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbPermessions.SelectedItem.ToString();

            if (selectedValue == "All") 
                _AllUsers.DefaultView.RowFilter = "";
            else 
                _AllUsers.DefaultView.RowFilter = string.Format("[Permessions] = '{0}'", selectedValue);

            lblRecordsCount.Text = _AllUsers.DefaultView.Count.ToString();
        }
    }
}
