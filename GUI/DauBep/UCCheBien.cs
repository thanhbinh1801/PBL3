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

namespace PBL3
{
    public partial class UCCheBien : UserControl
    {
        QLNHDB db = new QLNHDB();
        public int IdDauBep { get; set; }
        private int currentDonHangId;

        public UCCheBien(int idDauBep)
        {
            InitializeComponent();
            LoadDonHang();
            IdDauBep = idDauBep;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvMonAn.CellFormatting += DgvMonAn_CellFormatting;
        }

        private void DgvMonAn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dgvMonAn.Rows[e.RowIndex];
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

        public void LoadDonHang()
        {
            var donhang = db.donHang.Where(db => db.trangThai == DAL.TrangThaiDonHang.DangXuLy).ToList();
            cbbDanhSachDonHang.DataSource = donhang;
            cbbDanhSachDonHang.DisplayMember = "IDBan";
            cbbDanhSachDonHang.ValueMember = "IDDonHang";
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (cbbDanhSachDonHang.SelectedValue == null) return;

            currentDonHangId = (int)cbbDanhSachDonHang.SelectedValue;
            var listMonAn = db.donHangChiTiet
                .Where(dh => dh.IDDonHang == currentDonHangId)
                .Select(ma => new
                {
                    IDMonAn = ma.IDMonAn,
                    TenMonAn = ma.monAn.tenMonAn,
                    SoLuong = ma.soLuong,
                    TrangThai = ma.trangThai
                }).ToList();
            
            dgvMonAn.DataSource = listMonAn;
            KiemTraTrangThaiXacNhanDonHang();
        }

        private void KiemTraTrangThaiXacNhanDonHang()
        {
            if (dgvMonAn.Rows.Count == 0)
            {
                btnXacNhan.Enabled = false;
                return;
            }

            // Kiểm tra xem tất cả món ăn đã được chế biến chưa
            bool tatCaDaCheBien = true;
            foreach (DataGridViewRow row in dgvMonAn.Rows)
            {
                var trangThai = (TrangThaiMonAn)row.Cells["TrangThai"].Value;
                if (trangThai == TrangThaiMonAn.ChuaCheBien)
                {
                    tatCaDaCheBien = false;
                    break;
                }
            }

            btnXacNhan.Enabled = tatCaDaCheBien;
        }

        private void btnTimKiem_DB_Click(object sender, EventArgs e)
        {
            if (cbbDanhSachDonHang.SelectedValue == null) return;

            string txt = txtTimKiem.Text;
            var listMonAn = db.donHangChiTiet
                .Where(ma => ma.IDDonHang == currentDonHangId && 
                       ma.monAn.tenMonAn.ToLower().Contains(txt.ToLower()))
                .Select(ma => new
                {
                    IDMonAn = ma.IDMonAn,
                    TenMonAn = ma.monAn.tenMonAn,
                    SoLuong = ma.soLuong,
                    TrangThai = ma.trangThai
                }).ToList();
            dgvMonAn.DataSource = listMonAn;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cbbDanhSachDonHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xác nhận.");
                return;
            }

            int idDonHang = (int)cbbDanhSachDonHang.SelectedValue;
            var donHang = db.donHang.FirstOrDefault(dh => dh.IDDonHang == idDonHang);

            if (donHang != null)
            {
                // Kiểm tra xem tất cả món ăn đã được chế biến chưa
                var monAnChuaCheBien = db.donHangChiTiet
                    .Any(dh => dh.IDDonHang == idDonHang && dh.trangThai == TrangThaiMonAn.ChuaCheBien);

                if (monAnChuaCheBien)
                {
                    MessageBox.Show("Vui lòng chế biến hết tất cả món ăn trong đơn hàng!");
                    return;
                }

                donHang.trangThai = DAL.TrangThaiDonHang.HoanThanh;
                donHang.IDNguoiNhan = IdDauBep;
                db.SaveChanges();
                MessageBox.Show("Xác nhận đơn hàng thành công!");

                LoadDonHang();
                dgvMonAn.DataSource = null;
            }
            else
            {
                MessageBox.Show("Không tìm thấy đơn hàng.");
            }
        }

        private void btnXacNhanMon_Click(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xác nhận!");
                return;
            }

            var selectedRow = dgvMonAn.SelectedRows[0];
            int idMonAn = Convert.ToInt32(selectedRow.Cells["IDMonAn"].Value);
            var trangThai = (TrangThaiMonAn)selectedRow.Cells["TrangThai"].Value;

            if (trangThai == TrangThaiMonAn.DaCheBien)
            {
                MessageBox.Show("Món ăn này đã được chế biến!");
                return;
            }

            try
            {
                var chiTiet = db.donHangChiTiet
                    .FirstOrDefault(dh => dh.IDDonHang == currentDonHangId && dh.IDMonAn == idMonAn);

                if (chiTiet != null)
                {
                    chiTiet.trangThai = TrangThaiMonAn.DaCheBien;
                    db.SaveChanges();

                    // Cập nhật lại DataGridView
                    btnChon_Click(sender, e);
                    MessageBox.Show("Xác nhận chế biến món ăn thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận món ăn: " + ex.Message);
            }
        }
    }
}
