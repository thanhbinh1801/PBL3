using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI.NhanVien
{
    public partial class formDonHang: Form
    {
        private QLNHDB db = new QLNHDB();
        private int soBan;
        private int idNhanVien;
        private DonHang donHangHienTai;

        public formDonHang(int soban, int idnhanvien)
        {
            InitializeComponent();
            soBan = soban;
            idNhanVien = idnhanvien;
            SetupDataGridView();
            LoadDonHang();
        }

        private void SetupDataGridView()
        {
            dgvMonan.CellFormatting += DgvMonan_CellFormatting;
        }

        private void DgvMonan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dgvMonan.Rows[e.RowIndex];
                var trangThai = (TrangThaiMonAn)row.Cells["TrangThai"].Value;
                
                if (trangThai == TrangThaiMonAn.ChuaCheBien)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else // Đã chế biến
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void LoadDonHang()
        {
            // Tìm đơn hàng của bàn có trạng thái HoanThanh hoặc DangXuLy
            donHangHienTai = db.donHang
                .FirstOrDefault(d => d.IDBan == soBan && 
                    (d.trangThai == TrangThaiDonHang.HoanThanh || 
                     d.trangThai == TrangThaiDonHang.DangXuLy));
           
            if (donHangHienTai != null)
            {
                // Load chi tiết món ăn vào DataGridView
                var chiTietDonHang = db.donHangChiTiet
                    .Where(d => d.IDDonHang == donHangHienTai.IDDonHang)
                    .Select(d => new
                    {
                        d.monAn.tenMonAn,
                        d.soLuong,
                        d.monAn.giaBan,
                        ThanhTien = d.soLuong * d.monAn.giaBan,
                        d.trangThai

                    }).ToList();

                dgvMonan.DataSource = chiTietDonHang;

                // Tính tổng tiền
                double tongTien = chiTietDonHang.Sum(d => d.ThanhTien);
                txtTongTien.Text = tongTien.ToString("N0") + " VNĐ";

                // Disable nút thanh toán nếu đơn hàng chưa hoàn thành
                btnThanhtoan.Enabled = donHangHienTai.trangThai == TrangThaiDonHang.HoanThanh;
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (donHangHienTai == null || donHangHienTai.trangThai != TrangThaiDonHang.HoanThanh)
            {
                MessageBox.Show("Đơn hàng chưa hoàn thành, không thể thanh toán!");
                return;
            }

            try
            {
                // Cập nhật trạng thái đơn hàng thành ĐãThanhToan
                donHangHienTai.trangThai = TrangThaiDonHang.DaThanhToan;
                
                // Cập nhật trạng thái bàn thành Trống
                var ban = db.BanAns.FirstOrDefault(b => b.IDBan == soBan);
                if (ban != null)
                {
                    ban.trangThaiBanAn = TrangThaiBanAn.Trong;
                }

                db.SaveChanges();
                MessageBox.Show("Thanh toán thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
            }
        }
    }
}
