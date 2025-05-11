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
            this.btnChonMon = new System.Windows.Forms.Button();
            this.btnTimKiem_DB = new System.Windows.Forms.Button();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.cbbDanhSachDonHang = new System.Windows.Forms.ComboBox();
            this.pnControlFoodNV = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.pnControlFoodNV.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(243, 75);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(145, 62);
            this.btnChon.TabIndex = 6;
            this.btnChon.Text = "Chọn đơn hàng";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnChonMon
            // 
            this.btnChonMon.Location = new System.Drawing.Point(790, 75);
            this.btnChonMon.Name = "btnChonMon";
            this.btnChonMon.Size = new System.Drawing.Size(145, 62);
            this.btnChonMon.TabIndex = 5;
            this.btnChonMon.Text = "Hoàn thành món ";
            this.btnChonMon.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem_DB
            // 
            this.btnTimKiem_DB.Location = new System.Drawing.Point(592, 75);
            this.btnTimKiem_DB.Name = "btnTimKiem_DB";
            this.btnTimKiem_DB.Size = new System.Drawing.Size(145, 62);
            this.btnTimKiem_DB.TabIndex = 7;
            this.btnTimKiem_DB.Text = "Tìm kiếm";
            this.btnTimKiem_DB.UseVisualStyleBackColor = true;
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.Location = new System.Drawing.Point(53, 183);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.RowTemplate.Height = 24;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(882, 388);
            this.dgvMonAn.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Chọn món ăn chế biên";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(417, 604);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(145, 62);
            this.btnXacNhan.TabIndex = 11;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
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
            this.pnControlFoodNV.Controls.Add(this.textBox1);
            this.pnControlFoodNV.Controls.Add(this.cbbDanhSachDonHang);
            this.pnControlFoodNV.Controls.Add(this.btnXacNhan);
            this.pnControlFoodNV.Controls.Add(this.label1);
            this.pnControlFoodNV.Controls.Add(this.dgvMonAn);
            this.pnControlFoodNV.Controls.Add(this.btnTimKiem_DB);
            this.pnControlFoodNV.Controls.Add(this.btnChonMon);
            this.pnControlFoodNV.Controls.Add(this.btnChon);
            this.pnControlFoodNV.Location = new System.Drawing.Point(3, 3);
            this.pnControlFoodNV.Name = "pnControlFoodNV";
            this.pnControlFoodNV.Size = new System.Drawing.Size(983, 676);
            this.pnControlFoodNV.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(428, 85);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 42);
            this.textBox1.TabIndex = 13;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
        private System.Windows.Forms.Button btnChonMon;
        private System.Windows.Forms.Button btnTimKiem_DB;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ComboBox cbbDanhSachDonHang;
        private System.Windows.Forms.Panel pnControlFoodNV;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
