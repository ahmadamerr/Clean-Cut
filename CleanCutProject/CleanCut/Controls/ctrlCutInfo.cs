using CleanCutBussiness;
using System.Data;
using System.Windows.Forms;

namespace CleanCut.Controls
{
    public partial class ctrlCutInfo : UserControl
    {
        private DataTable _AllCutDetails;

        private clsCut _Cut;

        private int _CutId;
        public int CutId { get { return _CutId; } }

        public ctrlCutInfo()
        {
            InitializeComponent();
        }

        private void _ResetCutInfo()
        {
            lblBarberName.Text = "????";
            lblCustomer.Text = "????";
            lblCutId.Text = "????";
            lblMadeBy.Text = "????";

            dtpCutDate.Value = System.DateTime.Now.Date;

            dgvCutDetails.DataSource = null;
        }

        private void _FillCutInfo()
        {
            llEditCut.Enabled = true;

            _CutId = _Cut.CutId;

            lblBarberName.Text = clsUser.GetUserNameById(_Cut.Barber);
            lblCustomer.Text = clsCustomer.GetCustomerNameById(_Cut.Barber);
            lblMadeBy.Text = clsUser.GetUserNameById(_Cut.MadeByUser);
            lblCutId.Text = _Cut.CutId.ToString();

            dtpCutDate.Value = _Cut.CutDate;

            dgvCutDetails.DataSource = _AllCutDetails;

            if (_AllCutDetails.Rows.Count > 0)
            {
                dgvCutDetails.Columns[0].HeaderText = "Cut ID";
                dgvCutDetails.Columns[0].Width = 167;

                dgvCutDetails.Columns[1].HeaderText = "Cut Name";
                dgvCutDetails.Columns[1].Width = 168;

                dgvCutDetails.Columns[2].HeaderText = "Paid Fees";
                dgvCutDetails.Columns[2].Width = 168;
            }
        }

        public void LoadData(int cutId)
        {
            _Cut = clsCut.GetCutById(cutId);

            _AllCutDetails = clsCutDetails.GetCutDetailsById(cutId);

            if (_Cut == null)
            {
                _ResetCutInfo();

                MessageBox.Show("No Cut with this Deduction ID. = " + cutId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillCutInfo();
        }

        private void llEditCut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateCut frm = new frmAddUpdateCut(_CutId);
            frm.ShowDialog();
        }
    }
}
