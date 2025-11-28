namespace CleanCut
{
    partial class frmDeductionInfo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlDeductionCard1 = new CleanCut.Controls.ctrlDeductionCard();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::CleanCut.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(456, 237);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 100;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlDeductionCard1
            // 
            this.ctrlDeductionCard1.BackColor = System.Drawing.Color.White;
            this.ctrlDeductionCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlDeductionCard1.Location = new System.Drawing.Point(1, 4);
            this.ctrlDeductionCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDeductionCard1.Name = "ctrlDeductionCard1";
            this.ctrlDeductionCard1.Size = new System.Drawing.Size(598, 225);
            this.ctrlDeductionCard1.TabIndex = 0;
            // 
            // frmDeductionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(601, 284);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDeductionCard1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDeductionInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deduction Info";
            this.Load += new System.EventHandler(this.frmDeductionInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlDeductionCard ctrlDeductionCard1;
        private System.Windows.Forms.Button btnClose;
    }
}