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
        public UCCheBien(int idDauBep)
        {
            InitializeComponent();
            LoadDonHang();
            IdDauBep = idDauBep;
        }
        public void LoadDonHang()
        {
            var donhang = db.donHang.Where( db => db.trangThai == DAL.TrangThaiDonHang.DangXuLy).ToList();
            cbbDanhSachDonHang.DataSource = donhang;
            cbbDanhSachDonHang.DisplayMember = "IDBan";
            cbbDanhSachDonHang.ValueMember = "IDDonHang";
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int idDonHang = (int)cbbDanhSachDonHang.SelectedValue;
            var listMonAn = db.donHangChiTiet.Where( dh => dh.IDDonHang == idDonHang)
                                .Select(ma => new
                                {
                                    IDMonAn = ma.IDMonAn,
                                    TenMonAn = ma.monAn.tenMonAn,
                                    SoLuong = ma.soLuong
                                }).ToList();
            dgvMonAn.DataSource = listMonAn;
        }

        private void btnTimKiem_DB_Click(object sender, EventArgs e)
        {
            string txt = txtTimKiem.Text;
            var listMonAn = db.donHangChiTiet.Where(ma => ma.monAn.tenMonAn.ToLower().Contains(txt.ToLower()))
                .Select(ma => new
                {
                    IDMonAn = ma.IDMonAn,
                    TenMonAn = ma.monAn.tenMonAn,
                    SoLuong = ma.soLuong
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
    }
}
