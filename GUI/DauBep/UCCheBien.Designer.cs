namespace PBL3
{
    partial class UCCheBien
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
            this.components = new System.ComponentModel.Container();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnTimKiem_DB = new System.Windows.Forms.Button();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.cbbDanhSachDonHang = new System.Windows.Forms.ComboBox();
            this.pnControlFoodNV = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnXacNhanMon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.pnControlFoodNV.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChon
            // 
            this.btnChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChon.Location = new System.Drawing.Point(299, 75);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(169, 51);
            this.btnChon.TabIndex = 6;
            this.btnChon.Text = "Chọn đơn hàng";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnTimKiem_DB
            // 
            this.btnTimKiem_DB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem_DB.Location = new System.Drawing.Point(782, 75);
            this.btnTimKiem_DB.Name = "btnTimKiem_DB";
            this.btnTimKiem_DB.Size = new System.Drawing.Size(169, 51);
            this.btnTimKiem_DB.TabIndex = 7;
            this.btnTimKiem_DB.Text = "Tìm kiếm";
            this.btnTimKiem_DB.UseVisualStyleBackColor = true;
            this.btnTimKiem_DB.Click += new System.EventHandler(this.btnTimKiem_DB_Click);
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.Location = new System.Drawing.Point(12, 177);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.RowTemplate.Height = 24;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(959, 388);
            this.dgvMonAn.TabIndex = 9;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(599, 590);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(156, 62);
            this.btnXacNhan.TabIndex = 11;
            this.btnXacNhan.Text = "Xác Nhận Đơn Hàng";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // cbbDanhSachDonHang
            // 
            this.cbbDanhSachDonHang.FormattingEnabled = true;
            this.cbbDanhSachDonHang.Location = new System.Drawing.Point(54, 95);
            this.cbbDanhSachDonHang.Name = "cbbDanhSachDonHang";
            this.cbbDanhSachDonHang.Size = new System.Drawing.Size(161, 24);
            this.cbbDanhSachDonHang.TabIndex = 12;
            // 
            // pnControlFoodNV
            // 
            this.pnControlFoodNV.BackColor = System.Drawing.Color.BurlyWood;
            this.pnControlFoodNV.Controls.Add(this.label1);
            this.pnControlFoodNV.Controls.Add(this.btnXacNhanMon);
            this.pnControlFoodNV.Controls.Add(this.txtTimKiem);
            this.pnControlFoodNV.Controls.Add(this.cbbDanhSachDonHang);
            this.pnControlFoodNV.Controls.Add(this.btnXacNhan);
            this.pnControlFoodNV.Controls.Add(this.dgvMonAn);
            this.pnControlFoodNV.Controls.Add(this.btnTimKiem_DB);
            this.pnControlFoodNV.Controls.Add(this.btnChon);
            this.pnControlFoodNV.Location = new System.Drawing.Point(3, 3);
            this.pnControlFoodNV.Name = "pnControlFoodNV";
            this.pnControlFoodNV.Size = new System.Drawing.Size(983, 676);
            this.pnControlFoodNV.TabIndex = 5;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(536, 95);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(178, 31);
            this.txtTimKiem.TabIndex = 13;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnXacNhanMon
            // 
            this.btnXacNhanMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanMon.Location = new System.Drawing.Point(299, 590);
            this.btnXacNhanMon.Name = "btnXacNhanMon";
            this.btnXacNhanMon.Size = new System.Drawing.Size(156, 62);
            this.btnXacNhanMon.TabIndex = 14;
            this.btnXacNhanMon.Text = "Xác Nhận Món Ăn";
            this.btnXacNhanMon.UseVisualStyleBackColor = true;
            this.btnXacNhanMon.Click += new System.EventHandler(this.btnXacNhanMon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(306, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 38);
            this.label1.TabIndex = 15;
            this.label1.Text = "CHỌN MÓN ĂN CHẾ BIẾN";
            // 
            // UCCheBien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnControlFoodNV);
            this.Name = "UCCheBien";
            this.Size = new System.Drawing.Size(1002, 689);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.pnControlFoodNV.ResumeLayout(false);
            this.pnControlFoodNV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnTimKiem_DB;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ComboBox cbbDanhSachDonHang;
        private System.Windows.Forms.Panel pnControlFoodNV;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnXacNhanMon;
        private System.Windows.Forms.Label label1;
    }
}
