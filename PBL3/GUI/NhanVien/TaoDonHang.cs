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
    public partial class TaoDonHang : Form
    {
        QLNHDB db = new QLNHDB();
        public int SoBan { get; set; }
        public int IdNguoiTao { get; set; }
        public TaoDonHang(int soBan, int idNguoiTao)
        {
            InitializeComponent();
            SoBan = soBan;
            IdNguoiTao = idNguoiTao;
            LoadMonAn();
        }
        public void LoadMonAn()
        {
            var dsachMonAn = db.MonAns.Where(ms => ms.trangThai == TrangThaiMonAn.Con).ToList();
            ccbMonAn.DataSource = dsachMonAn;
            ccbMonAn.DisplayMember = "tenMonAn";
            ccbMonAn.ValueMember = "IDMonAn";
        }

        private void btnThemmon_Click(object sender, EventArgs e)
        {
            if(ccbMonAn.SelectedItem == null || nuoSoLuong.Value == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn và số lượng");
                return;
            }
            MonAn mon = (MonAn)ccbMonAn.SelectedItem;
            int soLuong = (int)nuoSoLuong.Value;
            double donGia = mon.giaBan;
            double thanhTien = donGia * soLuong;

            dgvMonAn.Rows.Add(mon.IDMonAn, mon.tenMonAn, donGia.ToString(), soLuong.ToString(), thanhTien.ToString());

            tinhTongTien();
        }
        public void tinhTongTien()
        {
            double tongTien = 0;
            foreach (DataGridViewRow row in dgvMonAn.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDouble(row.Cells["ThanhTien"].Value);
                }
            }
            txtTongTien.Text = tongTien.ToString();
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if(dgvMonAn.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow row in dgvMonAn.SelectedRows)
                {
                    dgvMonAn.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn để xóa"); 
            }
        }

        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            DonHang donHang = new DonHang()
            {
                moTa = txtMoTa.Text,
                IDBan = SoBan,
                IDNguoiTao = IdNguoiTao, // phai tao db nguoidung
                IDNguoiNhan = 101 ,
                thoiGianTao = DateTime.Now,
                trangThai = TrangThaiDonHang.DangXuLy,
                DonHangChiTiets = new List<DonHangChiTiet>()
            };
            db.donHang.Add(donHang);
            try
            {
            db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
            foreach (DataGridViewRow row in dgvMonAn.Rows)
            {
                if (row.Cells["TenMonAn"].Value != null)
                {
                    DonHangChiTiet donhang = new DonHangChiTiet()
                    {
                        soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                        IDMonAn = Convert.ToInt32(row.Cells["IDMonAn"].Value),
                        IDDonHang = donHang.IDDonHang,
                    };
                    donHang.DonHangChiTiets.Add(donhang);
                }
            }
            try
            {
            db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
            this.Hide();
        }
    }
}
