namespace PBL3.GUI.QuanLy
{
    partial class SuaMonAn
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.ccbDVi = new System.Windows.Forms.ComboBox();
            this.ccbNL = new System.Windows.Forms.ComboBox();
            this.btn_themNL = new System.Windows.Forms.Button();
            this.dgvNguyenLieu = new System.Windows.Forms.DataGridView();
            this.btnSuaMonAn = new System.Windows.Forms.Button();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenMonAn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(135, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "Nguyên Liệu ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(491, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(682, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Đơn vị ";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(583, 163);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(80, 22);
            this.txtSL.TabIndex = 44;
            // 
            // ccbDVi
            // 
            this.ccbDVi.FormattingEnabled = true;
            this.ccbDVi.Location = new System.Drawing.Point(758, 163);
            this.ccbDVi.Name = "ccbDVi";
            this.ccbDVi.Size = new System.Drawing.Size(112, 24);
            this.ccbDVi.TabIndex = 43;
            // 
            // ccbNL
            // 
            this.ccbNL.FormattingEnabled = true;
            this.ccbNL.Location = new System.Drawing.Point(288, 163);
            this.ccbNL.Name = "ccbNL";
            this.ccbNL.Size = new System.Drawing.Size(186, 24);
            this.ccbNL.TabIndex = 42;
            // 
            // btn_themNL
            // 
            this.btn_themNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_themNL.Location = new System.Drawing.Point(904, 163);
            this.btn_themNL.Name = "btn_themNL";
            this.btn_themNL.Size = new System.Drawing.Size(73, 29);
            this.btn_themNL.TabIndex = 41;
            this.btn_themNL.Text = "OK";
            this.btn_themNL.UseVisualStyleBackColor = true;
            this.btn_themNL.Click += new System.EventHandler(this.btn_themNL_Click);
            // 
            // dgvNguyenLieu
            // 
            this.dgvNguyenLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguyenLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguyenLieu.Location = new System.Drawing.Point(130, 207);
            this.dgvNguyenLieu.Name = "dgvNguyenLieu";
            this.dgvNguyenLieu.RowHeadersWidth = 51;
            this.dgvNguyenLieu.RowTemplate.Height = 24;
            this.dgvNguyenLieu.Size = new System.Drawing.Size(812, 332);
            this.dgvNguyenLieu.TabIndex = 40;
            this.dgvNguyenLieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguyenLieu_CellClick);
            this.dgvNguyenLieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguyenLieu_CellContentClick);
            // 
            // btnSuaMonAn
            // 
            this.btnSuaMonAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaMonAn.Location = new System.Drawing.Point(957, 496);
            this.btnSuaMonAn.Name = "btnSuaMonAn";
            this.btnSuaMonAn.Size = new System.Drawing.Size(119, 43);
            this.btnSuaMonAn.TabIndex = 39;
            this.btnSuaMonAn.Text = "OK";
            this.btnSuaMonAn.UseVisualStyleBackColor = true;
            this.btnSuaMonAn.Click += new System.EventHandler(this.btnSuaMonAn_Click_1);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(653, 102);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(186, 22);
            this.txtGiaBan.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(550, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Giá bán";
            // 
            // txtTenMonAn
            // 
            this.txtTenMonAn.Location = new System.Drawing.Point(288, 102);
            this.txtTenMonAn.Name = "txtTenMonAn";
            this.txtTenMonAn.Size = new System.Drawing.Size(186, 22);
            this.txtTenMonAn.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(135, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "Tên món ăn mới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(453, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 38);
            this.label1.TabIndex = 48;
            this.label1.Text = "SỬA MÓN ĂN";
            // 
            // SuaMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1159, 571);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.ccbDVi);
            this.Controls.Add(this.ccbNL);
            this.Controls.Add(this.btn_themNL);
            this.Controls.Add(this.dgvNguyenLieu);
            this.Controls.Add(this.btnSuaMonAn);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenMonAn);
            this.Controls.Add(this.label8);
            this.Name = "SuaMonAn";
            this.Text = "SuaMonAn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.ComboBox ccbDVi;
        private System.Windows.Forms.ComboBox ccbNL;
        private System.Windows.Forms.Button btn_themNL;
        private System.Windows.Forms.DataGridView dgvNguyenLieu;
        private System.Windows.Forms.Button btnSuaMonAn;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenMonAn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
    }
}