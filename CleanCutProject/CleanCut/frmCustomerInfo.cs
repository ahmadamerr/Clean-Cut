using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmCustomerInfo : Form
    {
        private int _CustomerId;

        public frmCustomerInfo(int customerId)
        {
            InitializeComponent();

            _CustomerId = customerId;
        }

        private void frmCustomerDetails_Load(object sender, EventArgs e)
        {
            ctrlCustomerCard1.LoadCustomerById(_CustomerId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
