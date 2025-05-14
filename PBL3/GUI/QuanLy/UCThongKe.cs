using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PBL3.BLL;
using PBL3.DAL;

namespace PBL3.QuanLy
{
    public partial class UCThongKe : UserControl
    {
        private QLNHDB db = new QLNHDB();
        public UCThongKe()
        {
            InitializeComponent();
            ccbTime.Items.Add("Theo quý");
            ccbTime.Items.Add("Theo tháng");
            ccbTime.SelectedIndex = 0;
            VeBieuDoDoanhThu();

        }
      
        private void btnLoc_Click(object sender, EventArgs e)
        {
            VeBieuDoDoanhThu();
        }
        public (List<double> doanhThuTheoThang, double tongDoanhThu, int tongDonHang, string monAnBanChayNhat) ThongKeDoanhThu(int nam)
        {
            var doanhThuTheoThang = new List<double>(new double[12]); 
            double tongDoanhThu = 0;
            int tongDonHang = 0;
            var donHangs = db.donHang.Where(d => d.thoiGianTao.Year == nam).ToList();
            foreach (var donHang in donHangs)
            {
                tongDonHang++;
                var month = donHang.thoiGianTao.Month; 
                foreach (var chiTiet in donHang.DonHangChiTiets)
                {
                    var monAn = db.MonAns.FirstOrDefault(m => m.IDMonAn == chiTiet.IDMonAn);
                    if (monAn != null)
                    {
                        doanhThuTheoThang[month - 1] += chiTiet.soLuong * monAn.giaBan;
                        tongDoanhThu += chiTiet.soLuong * monAn.giaBan;
                    }
                }
            }
            var monAnBanChay = db.donHangChiTiet
                                  .GroupBy(d => d.IDMonAn)
                                  .OrderByDescending(g => g.Sum(d => d.soLuong))
                                  .FirstOrDefault();

            var tenMonAnBanChayNhat = "";
            if (monAnBanChay != null)
            {
                var monAn = db.MonAns.FirstOrDefault(m => m.IDMonAn == monAnBanChay.Key);
                if (monAn != null)
                {
                    tenMonAnBanChayNhat = monAn.tenMonAn;
                }
            }
            return (doanhThuTheoThang, tongDoanhThu, tongDonHang, tenMonAnBanChayNhat);
        }

        private void VeBieuDoDoanhThu()
        {
            List<int> doanhthu;
            List<string> thoiGian;
            if (ccbTime.SelectedIndex == 0)
            {
                doanhthu = new List<int> { 1000, 2000, 1500, 2500 };
                thoiGian = new List<string> { "Quý 1", "Quý 2", "Quý 3", "Quý 4" };
            }
            else
            {
                doanhthu = new List<int> { 1000, 2000, 1500, 2500, 1000, 2000, 1500, 2500, 1000, 2000, 1500, 2500 };
                thoiGian = new List<string> { "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12" };
            }
            chartBieuDoDuong.Series.Clear();
            Series seriesLine = new Series("Doanh Thu");
            seriesLine.ChartType = SeriesChartType.Line;
            for (int i = 0; i < doanhthu.Count; i++)
            {
                seriesLine.Points.AddXY(thoiGian[i], doanhthu[i]);
            }
            seriesLine.MarkerStyle = MarkerStyle.Circle;
            seriesLine.MarkerSize = 10; 
            chartBieuDoDuong.Series.Add(seriesLine);
            chartBieuDoDuong.ChartAreas[0].AxisX.Title = "Thời gian";
            chartBieuDoDuong.ChartAreas[0].AxisY.Title = "Doanh Thu";
            chartBieuDoTron.Series.Clear();
            Series seriesPie = new Series("Doanh Thu");
            seriesPie.ChartType = SeriesChartType.Pie; 
            int totalRevenue = doanhthu.Sum();
            for (int i = 0; i < doanhthu.Count; i++)
            {
                seriesPie.Points.AddXY(thoiGian[i], doanhthu[i]);
                double percentage = (double)doanhthu[i] / totalRevenue * 100;
                int roundedPercentage = (int)Math.Round(percentage);
                seriesPie.Points[i].Label = $"{roundedPercentage}%";
                seriesPie.Points[i].LabelBackColor = Color.Transparent; 
                seriesPie.Points[i].LabelForeColor = Color.Black;
            }
            seriesPie.Points[0].Color = Color.Red;   
            seriesPie.Points[1].Color = Color.Green; 
            seriesPie.Points[2].Color = Color.Blue;  
            seriesPie.Points[3].Color = Color.Yellow;
            if (ccbTime.SelectedIndex == 1)
            {
                seriesPie.Points[4].Color = Color.Orange;
                seriesPie.Points[5].Color = Color.Purple;
                seriesPie.Points[6].Color = Color.Pink;
                seriesPie.Points[7].Color = Color.Brown;
                seriesPie.Points[8].Color = Color.Cyan;
                seriesPie.Points[9].Color = Color.Magenta;
                seriesPie.Points[10].Color = Color.Gray;
                seriesPie.Points[11].Color = Color.Lime;
            }
            chartBieuDoTron.Series.Add(seriesPie);
            chartBieuDoTron.ChartAreas[0].Area3DStyle.Enable3D = false;
            chartBieuDoTron.ChartAreas[0].Area3DStyle.Inclination = 0;  
            chartBieuDoTron.ChartAreas[0].Area3DStyle.Rotation = 0;     
        }

    }
}
