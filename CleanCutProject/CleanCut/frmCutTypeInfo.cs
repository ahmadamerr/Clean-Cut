using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmCutTypeInfo : Form
    {
        private sbyte _CutTypeId;

        public frmCutTypeInfo(sbyte cutTypeId)
        {
            InitializeComponent();

            _CutTypeId = cutTypeId;
        }

        private void frmCutTypeInfo_Load(object sender, EventArgs e)
        {
            ctrlTypeCard1.LoadTypeInfo(_CutTypeId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
