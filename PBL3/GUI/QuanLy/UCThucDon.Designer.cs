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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvThucDon = new System.Windows.Forms.DataGridView();
            this.txtTimKiem_QL = new System.Windows.Forms.TextBox();
            this.pnControlFoodQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimKiem_QL
            // 
            this.btnTimKiem_QL.Location = new System.Drawing.Point(259, 55);
            this.btnTimKiem_QL.Name = "btnTimKiem_QL";
            this.btnTimKiem_QL.Size = new System.Drawing.Size(113, 46);
            this.btnTimKiem_QL.TabIndex = 0;
            this.btnTimKiem_QL.Text = "Tìm Kiếm";
            this.btnTimKiem_QL.UseVisualStyleBackColor = true;
            // 
            // btnThemMonAn
            // 
            this.btnThemMonAn.Location = new System.Drawing.Point(442, 55);
            this.btnThemMonAn.Name = "btnThemMonAn";
            this.btnThemMonAn.Size = new System.Drawing.Size(113, 46);
            this.btnThemMonAn.TabIndex = 1;
            this.btnThemMonAn.Text = "Thêm món ăn";
            this.btnThemMonAn.UseVisualStyleBackColor = true;
            // 
            // btnSuaMonAn
            // 
            this.btnSuaMonAn.Location = new System.Drawing.Point(625, 55);
            this.btnSuaMonAn.Name = "btnSuaMonAn";
            this.btnSuaMonAn.Size = new System.Drawing.Size(113, 46);
            this.btnSuaMonAn.TabIndex = 2;
            this.btnSuaMonAn.Text = "Sửa món ăn";
            this.btnSuaMonAn.UseVisualStyleBackColor = true;
            // 
            // btnXoaMonAn_QL
            // 
            this.btnXoaMonAn_QL.Location = new System.Drawing.Point(811, 55);
            this.btnXoaMonAn_QL.Name = "btnXoaMonAn_QL";
            this.btnXoaMonAn_QL.Size = new System.Drawing.Size(113, 46);
            this.btnXoaMonAn_QL.TabIndex = 3;
            this.btnXoaMonAn_QL.Text = "Xóa món ăn";
            this.btnXoaMonAn_QL.UseVisualStyleBackColor = true;
            // 
            // pnControlFoodQL
            // 
            this.pnControlFoodQL.Controls.Add(this.label1);
            this.pnControlFoodQL.Controls.Add(this.dgvThucDon);
            this.pnControlFoodQL.Controls.Add(this.txtTimKiem_QL);
            this.pnControlFoodQL.Controls.Add(this.btnTimKiem_QL);
            this.pnControlFoodQL.Controls.Add(this.btnXoaMonAn_QL);
            this.pnControlFoodQL.Controls.Add(this.btnThemMonAn);
            this.pnControlFoodQL.Controls.Add(this.btnSuaMonAn);
            this.pnControlFoodQL.Location = new System.Drawing.Point(3, 3);
            this.pnControlFoodQL.Name = "pnControlFoodQL";
            this.pnControlFoodQL.Size = new System.Drawing.Size(1004, 547);
            this.pnControlFoodQL.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thực đơn";
            // 
            // dgvThucDon
            // 
            this.dgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucDon.Location = new System.Drawing.Point(36, 133);
            this.dgvThucDon.Name = "dgvThucDon";
            this.dgvThucDon.RowHeadersWidth = 51;
            this.dgvThucDon.RowTemplate.Height = 24;
            this.dgvThucDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThucDon.Size = new System.Drawing.Size(935, 392);
            this.dgvThucDon.TabIndex = 5;
            // 
            // txtTimKiem_QL
            // 
            this.txtTimKiem_QL.Location = new System.Drawing.Point(77, 55);
            this.txtTimKiem_QL.Multiline = true;
            this.txtTimKiem_QL.Name = "txtTimKiem_QL";
            this.txtTimKiem_QL.Size = new System.Drawing.Size(125, 46);
            this.txtTimKiem_QL.TabIndex = 4;
            // 
            // UserControlFood_QL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnControlFoodQL);
            this.Name = "UserControlFood_QL";
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
        private System.Windows.Forms.TextBox txtTimKiem_QL;
        private System.Windows.Forms.DataGridView dgvThucDon;
        private System.Windows.Forms.Label label1;
    }
}
