using CleanCutBussiness;
using System;
using System.Windows.Forms;

namespace CleanCut.Controls
{
    public partial class ctrlDeductionCard : UserControl
    {
        private clsDeduction _Deduction;

        private int _DeductionId;

        public int DeductionId { get { return _DeductionId; } }

        public ctrlDeductionCard()
        {
            InitializeComponent();
        }

        private void _ResetDeductionInfo()
        {
            lblAmount.Text = "????";
            dtpDeduction.Value = DateTime.Now.Date;
            lblDeductionID.Text = "????";
            txtReason.Text = "????";
            lblName.Text = "????";
        }

        private void _FillDeductionInfo()
        {
            llEditDeduction.Enabled = true;

            _DeductionId = _Deduction.DeductionID;

            lblDeductionID.Text = _Deduction.DeductionID.ToString();
            lblAmount.Text = _Deduction.DeductionAmount.ToString();
            dtpDeduction.Value = _Deduction.DeductionDate;
            txtReason.Text = _Deduction.Reason;
            lblName.Text = clsUser.GetUserNameById(_Deduction.UserID);
        }

        public void LoadDeduction(int deductionId)
        {
            _Deduction = clsDeduction.GetDeductionById(deductionId);

            if (_Deduction == null)
            {
                _ResetDeductionInfo();

                MessageBox.Show("No Deduction with this Deduction ID. = " + deductionId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillDeductionInfo();
        }

        private void llEditDeduction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateDeduction frm = new frmAddUpdateDeduction(_DeductionId);
            frm.ShowDialog();
        }
    }
}
