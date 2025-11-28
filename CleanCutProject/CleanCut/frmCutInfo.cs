using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmCutInfo : Form
    {
        private int _CutId;

        public frmCutInfo(int cutId)
        {
            InitializeComponent();

            _CutId = cutId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCutInfo_Load(object sender, EventArgs e)
        {
            ctrlCutInfo1.LoadData(_CutId);
        }
    }
}
