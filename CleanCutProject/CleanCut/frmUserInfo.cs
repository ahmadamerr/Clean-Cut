using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmUserInfo : Form
    {
        private sbyte _UserId;

        public frmUserInfo(sbyte userId)
        {
            InitializeComponent();

            _UserId = userId;
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
