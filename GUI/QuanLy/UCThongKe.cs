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
            int namHienTai = DateTime.Now.Year;
            var (doanhThuTheoThang, tongDoanhThu, tongDonHang, monAnBanChayNhat) = ThongKeDoanhThu(namHienTai);

            // Hiển thị thông tin thống kê
            txtBestSale.Text = monAnBanChayNhat;
            txtTongThu.Text = string.Format("{0:N0} VNĐ", tongDoanhThu);
            txtTongDonHang.Text = tongDonHang.ToString();

            List<double> doanhthu;
            List<string> thoiGian;

            if (ccbTime.SelectedIndex == 0) // Theo quý
            {
                // Tính doanh thu theo quý
                doanhthu = new List<double>
                {
                    doanhThuTheoThang[0] + doanhThuTheoThang[1] + doanhThuTheoThang[2],  // Quý 1
                    doanhThuTheoThang[3] + doanhThuTheoThang[4] + doanhThuTheoThang[5],  // Quý 2
                    doanhThuTheoThang[6] + doanhThuTheoThang[7] + doanhThuTheoThang[8],  // Quý 3
                    doanhThuTheoThang[9] + doanhThuTheoThang[10] + doanhThuTheoThang[11] // Quý 4
                };
                thoiGian = new List<string> { "Quý 1", "Quý 2", "Quý 3", "Quý 4" };
            }
            else // Theo tháng
            {
                doanhthu = doanhThuTheoThang;
                thoiGian = new List<string> { "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12" };
            }

            // Vẽ biểu đồ đường
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
            chartBieuDoDuong.ChartAreas[0].AxisY.Title = "Doanh Thu (VNĐ)";

            // Vẽ biểu đồ tròn
            chartBieuDoTron.Series.Clear();
            Series seriesPie = new Series("Doanh Thu");
            seriesPie.ChartType = SeriesChartType.Pie;

            double totalRevenue = doanhthu.Sum();
            for (int i = 0; i < doanhthu.Count; i++)
            {
                if (totalRevenue > 0) // Tránh chia cho 0
                {
                    seriesPie.Points.AddXY(thoiGian[i], doanhthu[i]);
                    double percentage = doanhthu[i] / totalRevenue * 100;
                    seriesPie.Points[i].Label = $"{percentage:F1}%";
                    seriesPie.Points[i].LabelBackColor = Color.Transparent;
                    seriesPie.Points[i].LabelForeColor = Color.Black;
                }
            }

            // Màu sắc cho biểu đồ tròn
            Color[] colors = new Color[] 
            { 
                Color.Red, Color.Green, Color.Blue, Color.Yellow, 
                Color.Orange, Color.Purple, Color.Pink, Color.Brown,
                Color.Cyan, Color.Magenta, Color.Gray, Color.Lime 
            };

            for (int i = 0; i < seriesPie.Points.Count; i++)
            {
                seriesPie.Points[i].Color = colors[i];
            }

            chartBieuDoTron.Series.Add(seriesPie);
            chartBieuDoTron.ChartAreas[0].Area3DStyle.Enable3D = false;
            chartBieuDoTron.ChartAreas[0].Area3DStyle.Inclination = 0;
            chartBieuDoTron.ChartAreas[0].Area3DStyle.Rotation = 0;
        }

    }
}
