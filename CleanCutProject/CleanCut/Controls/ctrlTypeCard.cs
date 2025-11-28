using CleanCutBussiness;
using System.Windows.Forms;

namespace CleanCut.Controls
{
    public partial class ctrlTypeCard : UserControl
    {
        private clsCutType _CutType;

        private sbyte _CutTypeId;
        public sbyte CutTypeId { get { return _CutTypeId; } }

        public ctrlTypeCard()
        {
            InitializeComponent();
        }

        private void _ResetTypeInfo()
        {
            lblCutTypeId.Text = "????";
            lblName.Text = "????";
            lblPrice.Text = "????";
        }

        private void _FillTypeInfo()
        {
            llEditCut.Enabled = true;

            _CutTypeId = _CutType.CutTypeID;

            lblCutTypeId.Text = _CutType.CutTypeID.ToString();
            lblName.Text = _CutType.CutTypeName;
            lblPrice.Text = _CutType.CutTypePrice.ToString();
        }

        public void LoadTypeInfo(sbyte cutTypeId)
        {
            _CutType = clsCutType.GetCutTypeById(cutTypeId);

            if (_CutType == null)
            {
                _ResetTypeInfo();

                MessageBox.Show("No Cut Type with this Cut Type ID. = " + cutTypeId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillTypeInfo();
        }

        private void llEditCut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateCutType frm = new frmAddUpdateCutType(_CutTypeId);
            frm.ShowDialog();
        }
    }
}
