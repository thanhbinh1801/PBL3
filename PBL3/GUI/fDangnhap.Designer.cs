namespace PBL3
{
    partial class fDangnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDangnhap));
            this.label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tentk_txt = new System.Windows.Forms.TextBox();
            this.mk_txt = new System.Windows.Forms.TextBox();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.lable_doimk = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lable_dangki = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Red;
            this.label.Location = new System.Drawing.Point(235, 21);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(602, 42);
            this.label.TabIndex = 1;
            this.label.Text = "System Management  Restaurant";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(12, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 419);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tentk_txt
            // 
            this.tentk_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentk_txt.Location = new System.Drawing.Point(678, 92);
            this.tentk_txt.Multiline = true;
            this.tentk_txt.Name = "tentk_txt";
            this.tentk_txt.Size = new System.Drawing.Size(275, 39);
            this.tentk_txt.TabIndex = 3;
            this.tentk_txt.Text = "Tên tài khoản";
            // 
            // mk_txt
            // 
            this.mk_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mk_txt.Location = new System.Drawing.Point(678, 178);
            this.mk_txt.Multiline = true;
            this.mk_txt.Name = "mk_txt";
            this.mk_txt.Size = new System.Drawing.Size(275, 36);
            this.mk_txt.TabIndex = 4;
            this.mk_txt.Text = "Mật khẩu";
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dangnhap.Location = new System.Drawing.Point(678, 310);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(275, 66);
            this.btn_dangnhap.TabIndex = 5;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // lable_doimk
            // 
            this.lable_doimk.AutoSize = true;
            this.lable_doimk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable_doimk.Location = new System.Drawing.Point(822, 254);
            this.lable_doimk.Name = "lable_doimk";
            this.lable_doimk.Size = new System.Drawing.Size(131, 20);
            this.lable_doimk.TabIndex = 6;
            this.lable_doimk.TabStop = true;
            this.lable_doimk.Text = "Quên mật khẩu?";
            this.lable_doimk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lable_doimk_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(729, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bạn chưa có tài khoản?";
            // 
            // lable_dangki
            // 
            this.lable_dangki.AutoSize = true;
            this.lable_dangki.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable_dangki.Location = new System.Drawing.Point(760, 475);
            this.lable_dangki.Name = "lable_dangki";
            this.lable_dangki.Size = new System.Drawing.Size(123, 20);
            this.lable_dangki.TabIndex = 8;
            this.lable_dangki.TabStop = true;
            this.lable_dangki.Text = "Đăng kí tại đây.";
            this.lable_dangki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lable_dangki_LinkClicked);
            // 
            // fDangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 541);
            this.Controls.Add(this.lable_dangki);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lable_doimk);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.mk_txt);
            this.Controls.Add(this.tentk_txt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fDangnhap";
            this.Text = "ManagementRestaurant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tentk_txt;
        private System.Windows.Forms.TextBox mk_txt;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.LinkLabel lable_doimk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lable_dangki;
    }
}

