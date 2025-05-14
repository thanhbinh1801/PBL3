namespace PBL3.GUI.QuanLy
{
    partial class UCQLKho
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
            this.label8 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvKhoNguyenLieu = new System.Windows.Forms.DataGridView();
            this.btnXoaNL = new System.Windows.Forms.Button();
            this.btnThemNL = new System.Windows.Forms.Button();
            this.cbbKho = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoNguyenLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label8.Location = new System.Drawing.Point(349, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 38);
            this.label8.TabIndex = 21;
            this.label8.Text = "KHO QUẢN LÝ";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(412, 79);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(119, 38);
            this.btnTimKiem.TabIndex = 24;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(215, 83);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(162, 30);
            this.txtTimKiem.TabIndex = 31;
            // 
            // dgvKhoNguyenLieu
            // 
            this.dgvKhoNguyenLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoNguyenLieu.Location = new System.Drawing.Point(65, 141);
            this.dgvKhoNguyenLieu.Name = "dgvKhoNguyenLieu";
            this.dgvKhoNguyenLieu.RowHeadersWidth = 51;
            this.dgvKhoNguyenLieu.RowTemplate.Height = 24;
            this.dgvKhoNguyenLieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoNguyenLieu.Size = new System.Drawing.Size(879, 366);
            this.dgvKhoNguyenLieu.TabIndex = 34;
            // 
            // btnXoaNL
            // 
            this.btnXoaNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNL.Location = new System.Drawing.Point(771, 79);
            this.btnXoaNL.Name = "btnXoaNL";
            this.btnXoaNL.Size = new System.Drawing.Size(173, 38);
            this.btnXoaNL.TabIndex = 35;
            this.btnXoaNL.Text = "Xóa Nguyên Liệu";
            this.btnXoaNL.UseVisualStyleBackColor = true;
            this.btnXoaNL.Click += new System.EventHandler(this.btnXoaNL_Click);
            // 
            // btnThemNL
            // 
            this.btnThemNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNL.Location = new System.Drawing.Point(566, 79);
            this.btnThemNL.Name = "btnThemNL";
            this.btnThemNL.Size = new System.Drawing.Size(189, 38);
            this.btnThemNL.TabIndex = 36;
            this.btnThemNL.Text = "Thêm Nguyên Liệu";
            this.btnThemNL.UseVisualStyleBackColor = true;
            this.btnThemNL.Click += new System.EventHandler(this.btnThemNL_Click);
            // 
            // cbbKho
            // 
            this.cbbKho.FormattingEnabled = true;
            this.cbbKho.Location = new System.Drawing.Point(65, 89);
            this.cbbKho.Name = "cbbKho";
            this.cbbKho.Size = new System.Drawing.Size(121, 24);
            this.cbbKho.TabIndex = 37;
            // 
            // UCQLKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbbKho);
            this.Controls.Add(this.btnThemNL);
            this.Controls.Add(this.btnXoaNL);
            this.Controls.Add(this.dgvKhoNguyenLieu);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label8);
            this.Name = "UCQLKho";
            this.Size = new System.Drawing.Size(1010, 533);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoNguyenLieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvKhoNguyenLieu;
        private System.Windows.Forms.Button btnXoaNL;
        private System.Windows.Forms.Button btnThemNL;
        private System.Windows.Forms.ComboBox cbbKho;
    }
}
