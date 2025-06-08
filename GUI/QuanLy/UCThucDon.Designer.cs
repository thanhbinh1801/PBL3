namespace PBL3
{
    partial class UCThucDon
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
            this.btnTimKiem_QL = new System.Windows.Forms.Button();
            this.btnThemMonAn = new System.Windows.Forms.Button();
            this.btnSuaMonAn = new System.Windows.Forms.Button();
            this.btnXoaMonAn_QL = new System.Windows.Forms.Button();
            this.pnControlFoodQL = new System.Windows.Forms.Panel();
            this.dgvThucDon = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnControlFoodQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimKiem_QL
            // 
            this.btnTimKiem_QL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem_QL.Location = new System.Drawing.Point(210, 73);
            this.btnTimKiem_QL.Name = "btnTimKiem_QL";
            this.btnTimKiem_QL.Size = new System.Drawing.Size(151, 46);
            this.btnTimKiem_QL.TabIndex = 0;
            this.btnTimKiem_QL.Text = "Tìm Kiếm";
            this.btnTimKiem_QL.UseVisualStyleBackColor = true;
            this.btnTimKiem_QL.Click += new System.EventHandler(this.btnTimKiem_QL_Click);
            // 
            // btnThemMonAn
            // 
            this.btnThemMonAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMonAn.Location = new System.Drawing.Point(403, 75);
            this.btnThemMonAn.Name = "btnThemMonAn";
            this.btnThemMonAn.Size = new System.Drawing.Size(152, 46);
            this.btnThemMonAn.TabIndex = 1;
            this.btnThemMonAn.Text = "Thêm Món Ăn";
            this.btnThemMonAn.UseVisualStyleBackColor = true;
            this.btnThemMonAn.Click += new System.EventHandler(this.btnThemMonAn_Click);
            // 
            // btnSuaMonAn
            // 
            this.btnSuaMonAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaMonAn.Location = new System.Drawing.Point(606, 75);
            this.btnSuaMonAn.Name = "btnSuaMonAn";
            this.btnSuaMonAn.Size = new System.Drawing.Size(159, 46);
            this.btnSuaMonAn.TabIndex = 2;
            this.btnSuaMonAn.Text = "Sửa Món Ăn";
            this.btnSuaMonAn.UseVisualStyleBackColor = true;
            this.btnSuaMonAn.Click += new System.EventHandler(this.btnSuaMonAn_Click);
            // 
            // btnXoaMonAn_QL
            // 
            this.btnXoaMonAn_QL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMonAn_QL.Location = new System.Drawing.Point(812, 75);
            this.btnXoaMonAn_QL.Name = "btnXoaMonAn_QL";
            this.btnXoaMonAn_QL.Size = new System.Drawing.Size(159, 46);
            this.btnXoaMonAn_QL.TabIndex = 3;
            this.btnXoaMonAn_QL.Text = "Xóa Món Ăn";
            this.btnXoaMonAn_QL.UseVisualStyleBackColor = true;
            this.btnXoaMonAn_QL.Click += new System.EventHandler(this.btnXoaMonAn_QL_Click);
            // 
            // pnControlFoodQL
            // 
            this.pnControlFoodQL.BackColor = System.Drawing.Color.BurlyWood;
            this.pnControlFoodQL.Controls.Add(this.label1);
            this.pnControlFoodQL.Controls.Add(this.dgvThucDon);
            this.pnControlFoodQL.Controls.Add(this.txtTimKiem);
            this.pnControlFoodQL.Controls.Add(this.btnTimKiem_QL);
            this.pnControlFoodQL.Controls.Add(this.btnXoaMonAn_QL);
            this.pnControlFoodQL.Controls.Add(this.btnThemMonAn);
            this.pnControlFoodQL.Controls.Add(this.btnSuaMonAn);
            this.pnControlFoodQL.Location = new System.Drawing.Point(3, 3);
            this.pnControlFoodQL.Name = "pnControlFoodQL";
            this.pnControlFoodQL.Size = new System.Drawing.Size(1004, 547);
            this.pnControlFoodQL.TabIndex = 4;
            this.pnControlFoodQL.Paint += new System.Windows.Forms.PaintEventHandler(this.pnControlFoodQL_Paint);
            // 
            // dgvThucDon
            // 
            this.dgvThucDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucDon.Location = new System.Drawing.Point(36, 154);
            this.dgvThucDon.Name = "dgvThucDon";
            this.dgvThucDon.RowHeadersWidth = 51;
            this.dgvThucDon.RowTemplate.Height = 24;
            this.dgvThucDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThucDon.Size = new System.Drawing.Size(935, 371);
            this.dgvThucDon.TabIndex = 5;
            this.dgvThucDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThucDon_CellContentClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(36, 87);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(147, 32);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(396, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "THỰC ĐƠN";
            // 
            // UCThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnControlFoodQL);
            this.Name = "UCThucDon";
            this.Size = new System.Drawing.Size(1010, 553);
            this.pnControlFoodQL.ResumeLayout(false);
            this.pnControlFoodQL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTimKiem_QL;
        private System.Windows.Forms.Button btnThemMonAn;
        private System.Windows.Forms.Button btnSuaMonAn;
        private System.Windows.Forms.Button btnXoaMonAn_QL;
        private System.Windows.Forms.Panel pnControlFoodQL;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvThucDon;
        private System.Windows.Forms.Label label1;
    }
}
