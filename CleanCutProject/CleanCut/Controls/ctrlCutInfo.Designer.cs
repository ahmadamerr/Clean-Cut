namespace CleanCut.Controls
{
    partial class ctrlCutInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCutDetails = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMadeBy = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dtpCutDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.llEditCut = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBarberName = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblCutId = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCutDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCutDetails
            // 
            this.dgvCutDetails.AllowUserToAddRows = false;
            this.dgvCutDetails.AllowUserToDeleteRows = false;
            this.dgvCutDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvCutDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCutDetails.Location = new System.Drawing.Point(3, 259);
            this.dgvCutDetails.Name = "dgvCutDetails";
            this.dgvCutDetails.ReadOnly = true;
            this.dgvCutDetails.Size = new System.Drawing.Size(546, 181);
            this.dgvCutDetails.TabIndex = 124;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMadeBy);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.dtpCutDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.llEditCut);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblBarberName);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.lblCutId);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 221);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cut Info";
            // 
            // lblMadeBy
            // 
            this.lblMadeBy.AutoSize = true;
            this.lblMadeBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMadeBy.Location = new System.Drawing.Point(418, 99);
            this.lblMadeBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMadeBy.Name = "lblMadeBy";
            this.lblMadeBy.Size = new System.Drawing.Size(53, 20);
            this.lblMadeBy.TabIndex = 150;
            this.lblMadeBy.Text = "[????]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CleanCut.Properties.Resources.Calendar_32;
            this.pictureBox3.Location = new System.Drawing.Point(110, 147);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 149;
            this.pictureBox3.TabStop = false;
            // 
            // dtpCutDate
            // 
            this.dtpCutDate.CustomFormat = "yyyy-MM-dd";
            this.dtpCutDate.Enabled = false;
            this.dtpCutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCutDate.Location = new System.Drawing.Point(148, 147);
            this.dtpCutDate.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtpCutDate.MinDate = new System.DateTime(2025, 11, 4, 4, 16, 0, 0);
            this.dtpCutDate.Name = "dtpCutDate";
            this.dtpCutDate.Size = new System.Drawing.Size(127, 26);
            this.dtpCutDate.TabIndex = 148;
            this.dtpCutDate.Value = new System.DateTime(2025, 11, 5, 4, 16, 9, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 147;
            this.label2.Text = "Cut Date :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CleanCut.Properties.Resources.User_32__2;
            this.pictureBox2.Location = new System.Drawing.Point(380, 93);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 146;
            this.pictureBox2.TabStop = false;
            // 
            // llEditCut
            // 
            this.llEditCut.AutoSize = true;
            this.llEditCut.Enabled = false;
            this.llEditCut.Location = new System.Drawing.Point(418, 186);
            this.llEditCut.Name = "llEditCut";
            this.llEditCut.Size = new System.Drawing.Size(66, 20);
            this.llEditCut.TabIndex = 143;
            this.llEditCut.TabStop = true;
            this.llEditCut.Text = "Edit Cut";
            this.llEditCut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditCut_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 140;
            this.label4.Text = "Made By :";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(148, 92);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(53, 20);
            this.lblCustomer.TabIndex = 139;
            this.lblCustomer.Text = "[????]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CleanCut.Properties.Resources.Person_32;
            this.pictureBox1.Location = new System.Drawing.Point(110, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 138;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 137;
            this.label3.Text = "Customer :";
            // 
            // lblBarberName
            // 
            this.lblBarberName.AutoSize = true;
            this.lblBarberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarberName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBarberName.Location = new System.Drawing.Point(418, 30);
            this.lblBarberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarberName.Name = "lblBarberName";
            this.lblBarberName.Size = new System.Drawing.Size(59, 20);
            this.lblBarberName.TabIndex = 136;
            this.lblBarberName.Text = "[????]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(17, 32);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 20);
            this.label22.TabIndex = 132;
            this.label22.Text = "Cut ID :";
            // 
            // lblCutId
            // 
            this.lblCutId.AutoSize = true;
            this.lblCutId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCutId.Location = new System.Drawing.Point(117, 32);
            this.lblCutId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCutId.Name = "lblCutId";
            this.lblCutId.Size = new System.Drawing.Size(53, 20);
            this.lblCutId.TabIndex = 134;
            this.lblCutId.Text = "[????]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::CleanCut.Properties.Resources.barber_shop_6275796;
            this.pictureBox8.Location = new System.Drawing.Point(380, 28);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 135;
            this.pictureBox8.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 133;
            this.label1.Text = "Barber :";
            // 
            // ctrlCutInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCutDetails);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlCutInfo";
            this.Size = new System.Drawing.Size(554, 448);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCutDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCutDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DateTimePicker dtpCutDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel llEditCut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBarberName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCutId;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMadeBy;
    }
}
