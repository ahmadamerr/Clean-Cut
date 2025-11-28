using CleanCut.GlobalClasses;
using CleanCutBussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CleanCut
{
    public partial class frmAddUpdateCut : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;

        private int _CutId;
        private int _CustomerId;
        private decimal _TotalFees;

        private clsCut _Cut;
        private List<clsCutDetails> _CutDetails = new List<clsCutDetails>();
        private clsCustomer _Customer;
        public frmAddUpdateCut()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddUpdateCut(int CutId)
        {
            InitializeComponent();

            Mode = enMode.Update;

            _CutId = CutId;
        }

        private void _FillCutDetails()
        {
            foreach (CheckBox cb in gbCutTypes.Controls.OfType<CheckBox>())
            {
                if (cb.Checked)
                {
                    _CutDetails.Add(new clsCutDetails
                    {
                        CutId = _Cut.CutId,
                        CutType = clsCutType.GetCutIdByName(cb.Text),
                        PaidFees = (decimal)cb.Tag
                    });
                }
            }
        }

        private void _SaveCutDetails()
        {
            foreach (clsCutDetails detail in _CutDetails)
            {
                detail.Save();
            }
        }

        private void _RemoveUncheckCutDetails(sbyte cutType)
        {
            clsCutDetails.DeleteCutDetailsByType(cutType);

            _CutDetails.RemoveAll(d => d.CutType == cutType);
        }

        private void _FillBarberList()
        {
            List<string>barbers = clsUser.GetAllUsersNames();

            foreach (string barber in barbers)
            {
                cbBarbers.Items.Add(barber);
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;

            decimal price = (decimal)cb.Tag;

            if (cb.Checked)
                _TotalFees += price;
            else
            {
                _TotalFees -= price;

                if (Mode == enMode.Update)
                {
                    _RemoveUncheckCutDetails(clsCutType.GetCutIdByName(cb.Text));
                }
            }

            lblTotal.Text = _TotalFees.ToString();
        }

        private void _LoadCutTypeCheckBoxes()
        {
            DataTable CutTypes = clsCutType.GetAllCutTypesNameAPrice();

            int columns = 4; 
            int spacingX = 10;
            int spacingY = 30;
            int counter = 0;

            gbCutTypes.Controls.Clear(); 

            int x = spacingX;
            int y = spacingY;

            foreach (DataRow row in CutTypes.Rows)
            {
                string cutTypeName = row["CutName"].ToString();
                decimal cutTypePrice = Convert.ToDecimal(row["Fees"]);

                CheckBox cb = new CheckBox();
                cb.Text = cutTypeName;
                cb.Tag = cutTypePrice;
                cb.AutoSize = true;
                cb.Location = new System.Drawing.Point(x, y);

                cb.CheckedChanged += CheckBox_CheckedChanged;

                gbCutTypes.Controls.Add(cb);

                counter++;

                if (counter % columns == 0)
                {
                    y += spacingY;
                    x = spacingX;
                }
                else
                {
                    x += 150; 
                }
            }
        }

        private void _ResetAllDefaults()
        {
            _FillBarberList();

            _LoadCutTypeCheckBoxes();

            tpCutInfo.Enabled = false;

            btnNext.Enabled = ctrlCustomerWithFilter1.SelectedCustomerId != -1;

            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Cut";
                Text = "Add New Cut";
                tpCutInfo.Enabled = false;
                ctrlCustomerWithFilter1.FilterFocus();

                cbBarbers.SelectedIndex = 0;
                txtPaidFees.Text = "";
                lblTotal.Text = "";

                _Cut = new clsCut();
            }
            else
            {
                lblTitle.Text = "Update Cut";
                Text = "Update Cut";

                AcceptButton = btnNext;

                tpCutInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadCutTypes()
        {
            List<string>Types = clsCutType.GetAllCutTypesNameByCutId(_CutId);

            foreach (CheckBox cb in gbCutTypes.Controls.OfType<CheckBox>())
            {
                string cutName = cb.Text;

                if (Types.Contains(cutName))
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }

        private void _LoadData()
        {
            ctrlCustomerWithFilter1.FilterEnabled = false;

            _Cut = clsCut.GetCutById(_CutId);

            if (_Cut == null)
            {
                MessageBox.Show("No Cut with ID = " + _CutId, "Subscription Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Close();

                return;
            }

            _LoadCutTypes();

            ctrlCustomerWithFilter1.LoadData(_Cut.CustomerId);
            cbBarbers.Text = clsUser.GetUserNameById(_Cut.Barber);
            txtPaidFees.Text = _TotalFees.ToString();
            lblTotal.Text = _TotalFees.ToString();

            _CustomerId = _Cut.CustomerId;
         
            btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                AcceptButton = btnSave;
                btnSave.Enabled = true;
                tpCutInfo.Enabled = true;

                if (tcCut.SelectedIndex < tcCut.TabCount - 1)
                    tcCut.SelectedIndex++;

                return;
            }

            if (ctrlCustomerWithFilter1.SelectedCustomerId != -1)
            {
                AcceptButton = btnSave;
                btnSave.Enabled = true;
                tpCutInfo.Enabled = true;

                if (tcCut.SelectedIndex < tcCut.TabCount - 1)
                    tcCut.SelectedIndex++;
            }
            else
            {
                MessageBox.Show("Please select a Customer to proceed.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                ctrlCustomerWithFilter1.FilterFocus();
            }
        }

        private void frmAddUpdateCut_Load(object sender, EventArgs e)
        {
            _ResetAllDefaults();

            if (Mode == enMode.Update) _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctrlCustomerWithFilter1_OnCustomerSelected(int obj)
        {
            _CustomerId = obj;

            btnNext.Enabled = _CustomerId != -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Cut.MadeByUser = clsGlobal.CurrentUser.UserID;
            _Cut.Barber = clsUser.GetUserIdByName(cbBarbers.Text);
            _Cut.CutDate = DateTime.Now;
            _Cut.PaidFees = Convert.ToDecimal(txtPaidFees.Text);
            _Cut.CustomerId = _CustomerId;
            _Customer = clsCustomer.GetCustomerById(_Cut.CustomerId);

            if (_Cut.Save())
            {
                lblCutId.Text = _Cut.CutId.ToString();

                Mode = enMode.Update;

                lblTitle.Text = "Update Cut";

                Text = "Update Cut";

                _FillCutDetails();

                _SaveCutDetails();

                MessageBox.Show("Cut information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("An error occurred while saving Cut information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (_TotalFees > _Cut.PaidFees)
            {
                _Customer.CustomerDebt += (_TotalFees - _Cut.PaidFees);

                if (_Customer.Save())
                {
                    MessageBox.Show("Customer debt updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occurred while updating Customer debt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPaidFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
