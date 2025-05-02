namespace PBL3.GUI.NhanVien
{
    partial class UCBanAn
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
            this.lbIdBanAn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbIdBanAn
            // 
            this.lbIdBanAn.AutoSize = true;
            this.lbIdBanAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdBanAn.Location = new System.Drawing.Point(78, 52);
            this.lbIdBanAn.Name = "lbIdBanAn";
            this.lbIdBanAn.Size = new System.Drawing.Size(33, 29);
            this.lbIdBanAn.TabIndex = 0;
            this.lbIdBanAn.Text = "id";
            // 
            // UCBanAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbIdBanAn);
            this.Name = "UCBanAn";
            this.Size = new System.Drawing.Size(196, 137);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIdBanAn;
    }
}
