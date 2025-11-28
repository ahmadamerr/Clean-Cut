using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmDeductionInfo : Form
    {
        private int _DeductionId;   

        public frmDeductionInfo(int deductionId)
        {
            InitializeComponent();

            _DeductionId = deductionId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDeductionInfo_Load(object sender, EventArgs e)
        {
            ctrlDeductionCard1.LoadDeduction(_DeductionId);
        }
    }
}
