namespace PBL3.GUI.QuanLy
{
    partial class UCQuanLiTK
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
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.dgvTK = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiemNV = new System.Windows.Forms.Button();
            this.labelqltk = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTK.Location = new System.Drawing.Point(467, 100);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(179, 38);
            this.btnXoaTK.TabIndex = 41;
            this.btnXoaTK.Text = "Xóa Tài Khoản";
            this.btnXoaTK.UseVisualStyleBackColor = true;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // dgvTK
            // 
            this.dgvTK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTK.Location = new System.Drawing.Point(30, 164);
            this.dgvTK.Name = "dgvTK";
            this.dgvTK.RowHeadersWidth = 51;
            this.dgvTK.RowTemplate.Height = 24;
            this.dgvTK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTK.Size = new System.Drawing.Size(943, 366);
            this.dgvTK.TabIndex = 40;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(91, 104);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(245, 34);
            this.txtTimKiem.TabIndex = 39;
            // 
            // btnTimKiemNV
            // 
            this.btnTimKiemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemNV.Location = new System.Drawing.Point(737, 100);
            this.btnTimKiemNV.Name = "btnTimKiemNV";
            this.btnTimKiemNV.Size = new System.Drawing.Size(179, 38);
            this.btnTimKiemNV.TabIndex = 38;
            this.btnTimKiemNV.Text = "Tìm Kiếm";
            this.btnTimKiemNV.UseVisualStyleBackColor = true;
            this.btnTimKiemNV.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // labelqltk
            // 
            this.labelqltk.AutoSize = true;
            this.labelqltk.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelqltk.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelqltk.Location = new System.Drawing.Point(312, 37);
            this.labelqltk.Name = "labelqltk";
            this.labelqltk.Size = new System.Drawing.Size(348, 38);
            this.labelqltk.TabIndex = 37;
            this.labelqltk.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // UCQuanLiTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.Controls.Add(this.btnXoaTK);
            this.Controls.Add(this.dgvTK);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiemNV);
            this.Controls.Add(this.labelqltk);
            this.Name = "UCQuanLiTK";
            this.Size = new System.Drawing.Size(1015, 563);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.DataGridView dgvTK;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiemNV;
        private System.Windows.Forms.Label labelqltk;
    }
}
