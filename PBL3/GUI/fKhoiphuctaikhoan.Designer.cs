namespace PBL3
{
    partial class fKhoiphuctaikhoan
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
            this.button1 = new System.Windows.Forms.Button();
            this.newpass_confirm_txt = new System.Windows.Forms.TextBox();
            this.newpass_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxacthuc_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 50);
            this.button1.TabIndex = 13;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // newpass_confirm_txt
            // 
            this.newpass_confirm_txt.Location = new System.Drawing.Point(296, 212);
            this.newpass_confirm_txt.Name = "newpass_confirm_txt";
            this.newpass_confirm_txt.Size = new System.Drawing.Size(100, 22);
            this.newpass_confirm_txt.TabIndex = 12;
            // 
            // newpass_txt
            // 
            this.newpass_txt.Location = new System.Drawing.Point(296, 159);
            this.newpass_txt.Name = "newpass_txt";
            this.newpass_txt.Size = new System.Drawing.Size(100, 22);
            this.newpass_txt.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Xác nhận lại mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mật khẩu mới";
            // 
            // maxacthuc_txt
            // 
            this.maxacthuc_txt.Location = new System.Drawing.Point(296, 116);
            this.maxacthuc_txt.Name = "maxacthuc_txt";
            this.maxacthuc_txt.Size = new System.Drawing.Size(100, 22);
            this.maxacthuc_txt.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã xác nhận";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(103, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 36);
            this.label4.TabIndex = 14;
            this.label4.Text = "Khôi phục tài khoản";
            // 
            // fKhoiphuctaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 380);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newpass_confirm_txt);
            this.Controls.Add(this.newpass_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxacthuc_txt);
            this.Controls.Add(this.label1);
            this.Name = "fKhoiphuctaikhoan";
            this.Text = "Khôi phục tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox newpass_confirm_txt;
        private System.Windows.Forms.TextBox newpass_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxacthuc_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}