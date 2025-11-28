using System;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmExpensesInfo : Form
    {
        private int _ExpenseId;

        public frmExpensesInfo(int expenseId)
        {
            InitializeComponent();

            _ExpenseId = expenseId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmExpensesInfo_Load(object sender, EventArgs e)
        {
            ctrlExpensesCard1.LoadExpense(_ExpenseId);
        }
    }
}
