namespace PBL3.QuanLy
{
    partial class UCThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ccbTime = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongThu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongDonHang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBestSale = new System.Windows.Forms.TextBox();
            this.chartBieuDoDuong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBieuDoTron = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartBieuDoDuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBieuDoTron)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(332, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Thời gian";
            // 
            // ccbTime
            // 
            this.ccbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbTime.FormattingEnabled = true;
            this.ccbTime.Location = new System.Drawing.Point(204, 67);
            this.ccbTime.Name = "ccbTime";
            this.ccbTime.Size = new System.Drawing.Size(192, 33);
            this.ccbTime.TabIndex = 7;
            // 
            // btnLoc
            // 
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Location = new System.Drawing.Point(504, 71);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(106, 35);
            this.btnLoc.TabIndex = 11;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 36);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tổng doanh thu";
            // 
            // txtTongThu
            // 
            this.txtTongThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThu.Location = new System.Drawing.Point(329, 450);
            this.txtTongThu.Name = "txtTongThu";
            this.txtTongThu.Size = new System.Drawing.Size(257, 41);
            this.txtTongThu.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 500);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 36);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tổng đơn hàng";
            // 
            // txtTongDonHang
            // 
            this.txtTongDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDonHang.Location = new System.Drawing.Point(329, 497);
            this.txtTongDonHang.Name = "txtTongDonHang";
            this.txtTongDonHang.Size = new System.Drawing.Size(257, 41);
            this.txtTongDonHang.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(729, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 29);
            this.label6.TabIndex = 16;
            this.label6.Text = "MÓN BÁN CHẠY NHẤT";
            // 
            // txtBestSale
            // 
            this.txtBestSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBestSale.Location = new System.Drawing.Point(756, 105);
            this.txtBestSale.Name = "txtBestSale";
            this.txtBestSale.Size = new System.Drawing.Size(207, 41);
            this.txtBestSale.TabIndex = 17;
            // 
            // chartBieuDoDuong
            // 
            chartArea3.Name = "ChartArea1";
            this.chartBieuDoDuong.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartBieuDoDuong.Legends.Add(legend3);
            this.chartBieuDoDuong.Location = new System.Drawing.Point(43, 128);
            this.chartBieuDoDuong.Name = "chartBieuDoDuong";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartBieuDoDuong.Series.Add(series3);
            this.chartBieuDoDuong.Size = new System.Drawing.Size(658, 300);
            this.chartBieuDoDuong.TabIndex = 18;
            this.chartBieuDoDuong.Text = "chart1";
            // 
            // chartBieuDoTron
            // 
            chartArea4.Name = "ChartArea1";
            this.chartBieuDoTron.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartBieuDoTron.Legends.Add(legend4);
            this.chartBieuDoTron.Location = new System.Drawing.Point(734, 187);
            this.chartBieuDoTron.Name = "chartBieuDoTron";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartBieuDoTron.Series.Add(series4);
            this.chartBieuDoTron.Size = new System.Drawing.Size(263, 241);
            this.chartBieuDoTron.TabIndex = 19;
            this.chartBieuDoTron.Text = "chart2";
            // 
            // UCThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.Controls.Add(this.chartBieuDoTron);
            this.Controls.Add(this.chartBieuDoDuong);
            this.Controls.Add(this.txtBestSale);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTongDonHang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTongThu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.ccbTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "UCThongKe";
            this.Size = new System.Drawing.Size(1010, 553);
            ((System.ComponentModel.ISupportInitialize)(this.chartBieuDoDuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBieuDoTron)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ccbTime;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongThu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongDonHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBestSale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBieuDoDuong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBieuDoTron;
    }
}
