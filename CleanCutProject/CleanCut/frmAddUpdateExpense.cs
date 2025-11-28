using CleanCutBussiness;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using CleanCut.GlobalClasses;

namespace CleanCut
{
    public partial class frmAddUpdateExpense : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;

        private int _ExpenseId;

        private clsExpenses _Expense;

        public frmAddUpdateExpense()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddUpdateExpense(int ExpenseId)
        {
            InitializeComponent();

            Mode = enMode.Update;

            _ExpenseId = ExpenseId;
        }

        private void _ResetDefaults()
        {
            if (Mode == enMode.AddNew)
            {
                Text = "Add New Expense";

                lblTitle.Text = "Add New Expense";

                _Expense = new clsExpenses();
            }
            else
            {
                Text = "Update Expense";

                lblTitle.Text = "Update Expense";
            }

            txtDetails.Text = "";
            txtAmount.Text = "";
        }

        private void _LoadData()
        {
            _Expense = clsExpenses.GetExpenseById(_ExpenseId);

            if (_Expense == null)
            {
                _ResetDefaults();

                MessageBox.Show("No Expense with this Expense ID. = " + _ExpenseId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txtAmount.Text = _Expense.ExpenseAmount.ToString();
            txtDetails.Text = _Expense.ExpenseReason;
        }

        private void frmAddUpdateExpense_Load(object sender, EventArgs e)
        {
            _ResetDefaults();

            if (Mode == enMode.Update) _LoadData();
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtAmount, "Expense Amount field is required!");
            }
            else
                errorProvider1.SetError(txtAmount, "");
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Expense.ExpenseAmount = decimal.Parse(txtAmount.Text.Trim());
            _Expense.ExpenseReason = txtDetails.Text.Trim();
            _Expense.ExpenseDate = DateTime.Now;
            _Expense.UserID = clsGlobal.CurrentUser.UserID;

            if (_Expense.Save())
            {
                lblExpenseId.Text = _Expense.ExpenseID.ToString();

                Mode = enMode.Update;

                lblTitle.Text = "Update Expense";

                Text = "Update Expense";

                MessageBox.Show("Expense information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("An error occurred while saving Expense information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
