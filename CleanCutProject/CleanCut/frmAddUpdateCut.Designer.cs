namespace CleanCut
{
    partial class frmAddUpdateCut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcCut = new System.Windows.Forms.TabControl();
            this.tpCustomerInfo = new System.Windows.Forms.TabPage();
            this.ctrlCustomerWithFilter1 = new CleanCut.Controls.ctrlCustomerWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpCutInfo = new System.Windows.Forms.TabPage();
            this.lblCutId = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbCutTypes = new System.Windows.Forms.GroupBox();
            this.txtPaidFees = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBarbers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcCut.SuspendLayout();
            this.tpCustomerInfo.SuspendLayout();
            this.tpCutInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcCut
            // 
            this.tcCut.Controls.Add(this.tpCustomerInfo);
            this.tcCut.Controls.Add(this.tpCutInfo);
            this.tcCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcCut.Location = new System.Drawing.Point(12, 75);
            this.tcCut.Name = "tcCut";
            this.tcCut.SelectedIndex = 0;
            this.tcCut.Size = new System.Drawing.Size(713, 387);
            this.tcCut.TabIndex = 124;
            // 
            // tpCustomerInfo
            // 
            this.tpCustomerInfo.BackColor = System.Drawing.Color.White;
            this.tpCustomerInfo.Controls.Add(this.ctrlCustomerWithFilter1);
            this.tpCustomerInfo.Controls.Add(this.btnNext);
            this.tpCustomerInfo.Location = new System.Drawing.Point(4, 29);
            this.tpCustomerInfo.Name = "tpCustomerInfo";
            this.tpCustomerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustomerInfo.Size = new System.Drawing.Size(705, 354);
            this.tpCustomerInfo.TabIndex = 0;
            this.tpCustomerInfo.Text = "Customer Info";
            // 
            // ctrlCustomerWithFilter1
            // 
            this.ctrlCustomerWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlCustomerWithFilter1.FilterEnabled = true;
            this.ctrlCustomerWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlCustomerWithFilter1.Location = new System.Drawing.Point(7, 5);
            this.ctrlCustomerWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlCustomerWithFilter1.Name = "ctrlCustomerWithFilter1";
            this.ctrlCustomerWithFilter1.Size = new System.Drawing.Size(687, 277);
            this.ctrlCustomerWithFilter1.TabIndex = 122;
            this.ctrlCustomerWithFilter1.OnCustomerSelected += new System.Action<int>(this.ctrlCustomerWithFilter1_OnCustomerSelected);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::CleanCut.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(572, 309);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(126, 37);
            this.btnNext.TabIndex = 121;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpCutInfo
            // 
            this.tpCutInfo.BackColor = System.Drawing.Color.White;
            this.tpCutInfo.Controls.Add(this.lblCutId);
            this.tpCutInfo.Controls.Add(this.pictureBox3);
            this.tpCutInfo.Controls.Add(this.label5);
            this.tpCutInfo.Controls.Add(this.lblTotal);
            this.tpCutInfo.Controls.Add(this.pictureBox2);
            this.tpCutInfo.Controls.Add(this.label3);
            this.tpCutInfo.Controls.Add(this.gbCutTypes);
            this.tpCutInfo.Controls.Add(this.txtPaidFees);
            this.tpCutInfo.Controls.Add(this.pictureBox1);
            this.tpCutInfo.Controls.Add(this.label2);
            this.tpCutInfo.Controls.Add(this.cbBarbers);
            this.tpCutInfo.Controls.Add(this.label1);
            this.tpCutInfo.Location = new System.Drawing.Point(4, 29);
            this.tpCutInfo.Name = "tpCutInfo";
            this.tpCutInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpCutInfo.Size = new System.Drawing.Size(705, 354);
            this.tpCutInfo.TabIndex = 1;
            this.tpCutInfo.Text = "Cut Info";
            // 
            // lblCutId
            // 
            this.lblCutId.AutoSize = true;
            this.lblCutId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCutId.Location = new System.Drawing.Point(124, 117);
            this.lblCutId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCutId.Name = "lblCutId";
            this.lblCutId.Size = new System.Drawing.Size(53, 20);
            this.lblCutId.TabIndex = 153;
            this.lblCutId.Text = "[????]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CleanCut.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(86, 117);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 152;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 151;
            this.label5.Text = "Cut ID :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(397, 311);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 20);
            this.lblTotal.TabIndex = 150;
            this.lblTotal.Text = "[????]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CleanCut.Properties.Resources.money_32;
            this.pictureBox2.Location = new System.Drawing.Point(359, 311);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 149;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 148;
            this.label3.Text = "Total Fees:";
            // 
            // gbCutTypes
            // 
            this.gbCutTypes.Location = new System.Drawing.Point(15, 161);
            this.gbCutTypes.Name = "gbCutTypes";
            this.gbCutTypes.Size = new System.Drawing.Size(659, 135);
            this.gbCutTypes.TabIndex = 147;
            this.gbCutTypes.TabStop = false;
            this.gbCutTypes.Text = "Cut Types";
            // 
            // txtPaidFees
            // 
            this.txtPaidFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidFees.Location = new System.Drawing.Point(507, 44);
            this.txtPaidFees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaidFees.MaxLength = 50;
            this.txtPaidFees.Name = "txtPaidFees";
            this.txtPaidFees.Size = new System.Drawing.Size(167, 26);
            this.txtPaidFees.TabIndex = 146;
            this.txtPaidFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaidFees_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CleanCut.Properties.Resources.money_32;
            this.pictureBox1.Location = new System.Drawing.Point(458, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 139;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Paid Fees:";
            // 
            // cbBarbers
            // 
            this.cbBarbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBarbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbBarbers.FormattingEnabled = true;
            this.cbBarbers.Location = new System.Drawing.Point(91, 36);
            this.cbBarbers.Name = "cbBarbers";
            this.cbBarbers.Size = new System.Drawing.Size(210, 28);
            this.cbBarbers.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Barber:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(2, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(719, 39);
            this.lblTitle.TabIndex = 122;
            this.lblTitle.Text = "Add New Cut";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::CleanCut.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(465, 477);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::CleanCut.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(599, 477);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 125;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateCut
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(736, 522);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tcCut);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdateCut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/UpdateCut";
            this.Load += new System.EventHandler(this.frmAddUpdateCut_Load);
            this.tcCut.ResumeLayout(false);
            this.tpCustomerInfo.ResumeLayout(false);
            this.tpCutInfo.ResumeLayout(false);
            this.tpCutInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcCut;
        private System.Windows.Forms.TabPage tpCustomerInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblTitle;
        private Controls.ctrlCustomerWithFilter ctrlCustomerWithFilter1;
        private System.Windows.Forms.TabPage tpCutInfo;
        private System.Windows.Forms.ComboBox cbBarbers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPaidFees;
        private System.Windows.Forms.GroupBox gbCutTypes;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblCutId;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
    }
}