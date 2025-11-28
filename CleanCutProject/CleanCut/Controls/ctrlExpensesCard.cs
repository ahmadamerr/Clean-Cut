using CleanCutBussiness;
using System;
using System.Windows.Forms;

namespace CleanCut.Controls
{
    public partial class ctrlExpensesCard : UserControl
    {
        private clsExpenses _Expense;

        private int _ExpenseId;

        public int ExpenseId { get { return _ExpenseId; } }

        public ctrlExpensesCard()
        {
            InitializeComponent();
        }

        private void _ResetExpenseInfo()
        {
            lblAmount.Text = "????";
            dtpExpenses.Value = DateTime.Now.Date;
            lblExpensesID.Text = "????";
            txtReason.Text = "????";
            lblName.Text = "????";
        }

        private void _FillExpenseInfo()
        {
            llEditExpenses.Enabled = true;

            _ExpenseId = _Expense.ExpenseID;

            lblExpensesID.Text = _Expense.ExpenseID.ToString();
            lblAmount.Text = _Expense.ExpenseAmount.ToString();
            dtpExpenses.Value = _Expense.ExpenseDate;
            txtReason.Text = _Expense.ExpenseReason;
            lblName.Text = clsUser.GetUserNameById(_Expense.UserID);
        }

        public void LoadExpense(int expenseId)
        {
            _Expense = clsExpenses.GetExpenseById(expenseId);

            if (_Expense == null)
            {
                _ResetExpenseInfo();

                MessageBox.Show("No Expense with this Expense ID. = " + expenseId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillExpenseInfo();
        }

        private void llEditExpenses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateExpense frm = new frmAddUpdateExpense(_ExpenseId);
            frm.ShowDialog();
        }
    }
}
