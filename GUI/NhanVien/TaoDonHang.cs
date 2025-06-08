using PBL3.BLL;
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
        private NguyenLieu_Service nguyenLieuService = new NguyenLieu_Service();
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
            var dsachMonAn = db.MonAns.ToList();
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

            // Kiểm tra số lượng nguyên liệu trong kho
            int soLuongMoi = soLuong;
            foreach (DataGridViewRow row in dgvMonAn.Rows)
            {
                if (row.Cells["IDMonAn"].Value != null && 
                    Convert.ToInt32(row.Cells["IDMonAn"].Value) == mon.IDMonAn)
                {
                    soLuongMoi += Convert.ToInt32(row.Cells["SoLuong"].Value);
                    break;
                }
            }

            // Kiểm tra đủ nguyên liệu cho món ăn
            var (du, thieu) = nguyenLieuService.KiemTraDuNguyenLieu(mon.IDMonAn, soLuongMoi);
            if (!du)
            {
                MessageBox.Show($"Không đủ nguyên liệu để chế biến món {mon.tenMonAn}:\n{thieu}", 
                    "Thiếu nguyên liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu đủ nguyên liệu, tiếp tục thêm món
            bool monAnDaTonTai = false;
            foreach (DataGridViewRow row in dgvMonAn.Rows)
            {
                if (row.Cells["IDMonAn"].Value != null && 
                    Convert.ToInt32(row.Cells["IDMonAn"].Value) == mon.IDMonAn)
                {
                    // Nếu món ăn đã tồn tại, tăng số lượng lên
                    int soLuongCu = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    int soLuongMoiCapNhat = soLuongCu + soLuong;
                    row.Cells["SoLuong"].Value = soLuongMoiCapNhat.ToString();
                    row.Cells["ThanhTien"].Value = (donGia * soLuongMoiCapNhat).ToString();
                    monAnDaTonTai = true;
                    break;
                }
            }

            // Nếu món ăn chưa tồn tại, thêm dòng mới
            if (!monAnDaTonTai)
            {
                double thanhTien = donGia * soLuong;
                dgvMonAn.Rows.Add(mon.IDMonAn, mon.tenMonAn, donGia.ToString(), soLuong.ToString(), thanhTien.ToString());
            }

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
            // Kiểm tra đủ nguyên liệu cho tất cả các món
            if (txtTongTien.Text == "" || dgvMonAn.Rows.Count == 0)
            {
                MessageBox.Show("Không thể tạo đơn hàng khi chưa thêm món ăn nào!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringBuilder thongBaoThieu = new StringBuilder();
            bool duNguyenLieu = true;

            foreach (DataGridViewRow row in dgvMonAn.Rows)
            {
                if (row.Cells["TenMonAn"].Value != null)
                {
                    int idMonAn = Convert.ToInt32(row.Cells["IDMonAn"].Value);
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                    var (du, thieu) = nguyenLieuService.KiemTraDuNguyenLieu(idMonAn, soLuong);
                    if (!du)
                    {
                        duNguyenLieu = false;
                        thongBaoThieu.AppendLine($"Món {row.Cells["TenMonAn"].Value}:");
                        thongBaoThieu.AppendLine(thieu);
                    }
                }
            }

            if (!duNguyenLieu)
            {
                MessageBox.Show($"Không đủ nguyên liệu để chế biến:\n{thongBaoThieu}", 
                    "Thiếu nguyên liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu đủ nguyên liệu, tạo đơn hàng
            DonHang donHang = new DonHang()
            {
                moTa = txtMoTa.Text,
                IDBan = SoBan,
                IDNguoiTao = IdNguoiTao, 
                IDNguoiNhan = null,
                thoiGianTao = DateTime.Now,
                trangThai = TrangThaiDonHang.DangXuLy,
                DonHangChiTiets = new List<DonHangChiTiet>()
            };

            try
            {
                db.donHang.Add(donHang);
                db.SaveChanges(); // Lấy được IDDonHang

                // Thêm chi tiết đơn hàng và trừ nguyên liệu
                foreach (DataGridViewRow row in dgvMonAn.Rows)
                {
                    if (row.Cells["TenMonAn"].Value != null)
                    {
                        int idMonAn = Convert.ToInt32(row.Cells["IDMonAn"].Value);
                        int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                        DonHangChiTiet donhang = new DonHangChiTiet()
                        {
                            soLuong = soLuong,
                            IDMonAn = idMonAn,
                            IDDonHang = donHang.IDDonHang, // Gán IDDonHang cho từng chi tiết
                        };
                        db.donHangChiTiet.Add(donhang);
                        donHang.DonHangChiTiets.Add(donhang);

                        // Trừ nguyên liệu trong kho
                        nguyenLieuService.TruNguyenLieu(idMonAn, soLuong);
                    }
                }

                db.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
