using PBL3.BLL;
using PBL3.DAL;
using PBL3.GUI.NhanVien;
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
    public partial class fNhanVien : Form
    {
        QLNHDB db = new QLNHDB();
        MonAn_Service db_monan = new MonAn_Service();
        private Button banDangChon = null;
        public int IdNhanVien { get; set; }
        public fNhanVien(int idNhanVien)
        {
            InitializeComponent();
            IdNhanVien = idNhanVien;
        }
        private void fNhanVien_Load(object sender, EventArgs e)
        {
            int stt = 1;
            var dsachban = db.BanAns.ToList();
            foreach (Control ctrl in flpBanAn.Controls)
            {
                if (ctrl is Button btn)
                {
                    var ban = dsachban.FirstOrDefault(b => b.IDBan == stt);
                    if (ban != null)
                    {
                        if (ban.trangThaiBanAn == TrangThaiBanAn.Trong)
                        {
                            btn.BackColor = Color.LightGray;
                        }
                        else
                        {
                            btn.BackColor = Color.OrangeRed;
                        }
                        btn.Enabled = true;
                        btn.Click += Btn_Click;
                        btn.Tag = stt++;
                    }
                }
            }

            // Kiểm tra và thông báo các món đã chế biến xong
            KiemTraMonDaCheBien();
        }

        private void KiemTraMonDaCheBien()
        {
            // Lấy tất cả chi tiết đơn hàng đã chế biến xong nhưng chưa được phục vụ
            var chiTietList = db.donHangChiTiet
                .Where(d => d.trangThai == TrangThaiMonAn.DaCheBien)
                .ToList();

            // Nạp thông tin đơn hàng cho từng chi tiết (do .Include không dùng được với EF6 khi dùng DbSet thay vì IQueryable)
            foreach (var chiTiet in chiTietList)
            {
                // Nạp đơn hàng nếu chưa có
                if (chiTiet.donHang == null)
                {
                    chiTiet.donHang = db.donHang.FirstOrDefault(dh => dh.IDDonHang == chiTiet.IDDonHang);
                }
            }

            foreach (var chiTiet in chiTietList)
            {
                MessageBox.Show($"Món {db_monan.GetMonAnById(chiTiet.IDMonAn).tenMonAn} của bàn {chiTiet.donHang.IDBan} đã chế biến xong, cần được phục vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Sau khi thông báo, cập nhật trạng thái thành đã phục vụ
                chiTiet.trangThai = TrangThaiMonAn.DaPhucVu;
            }
            if (chiTietList.Any())
            {
                db.SaveChanges();
            }
        }

        private void KiemTraBanKhongCoMonAnDeSetLaiTrangThai()
        {
            var dsachban = db.BanAns.ToList();
            foreach (var ban in dsachban)
            {
                // Nếu bàn không trống nhưng không có đơn hàng nào chưa thanh toán hoặc chưa có món ăn
                var donHangDangXuLy = db.donHang.FirstOrDefault(dh => dh.IDBan == ban.IDBan &&
                    (dh.trangThai == TrangThaiDonHang.DangXuLy || dh.trangThai == TrangThaiDonHang.HoanThanh));
                if (ban.trangThaiBanAn != TrangThaiBanAn.Trong)
                {
                    if (donHangDangXuLy == null)
                    {
                        ban.trangThaiBanAn = TrangThaiBanAn.Trong;
                    }
                    else
                    {
                        // Kiểm tra đơn hàng này có món ăn không
                        var soMon = db.donHangChiTiet.Count(ct => ct.IDDonHang == donHangDangXuLy.IDDonHang);
                        if (soMon == 0)
                        {
                            ban.trangThaiBanAn = TrangThaiBanAn.Trong;
                        }
                    }
                }
            }
            db.SaveChanges();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (banDangChon != null)
            {
                int soBanTruoc = (int)banDangChon.Tag;
                var banTruoc = db.BanAns.FirstOrDefault(b => b.IDBan == soBanTruoc);
                if (banTruoc != null)
                {
                    if (banTruoc.trangThaiBanAn == TrangThaiBanAn.Trong)
                        banDangChon.BackColor = Color.LightGray;
                    else
                        banDangChon.BackColor = Color.OrangeRed;
                }
            }
            banDangChon = sender as Button;
            banDangChon.BackColor = Color.LightBlue;

            int soBan = (int)banDangChon.Tag;
            var ban = db.BanAns.FirstOrDefault(b => b.IDBan == soBan);
            if (ban != null && ban.trangThaiBanAn != TrangThaiBanAn.Trong)
            {
                formDonHang form = new formDonHang(soBan, IdNhanVien);
                form.Owner = this;
                form.ShowDialog();
            }
            // Kiểm tra và set lại trạng thái bàn không có món ăn
            KiemTraBanKhongCoMonAnDeSetLaiTrangThai();
            fNhanVien_Load(null, EventArgs.Empty);
        }
        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            if (banDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn bàn ăn");
                return;
            }
            int soBan = (int)banDangChon.Tag;
            TaoDonHang taoDonHang = new TaoDonHang(soBan, IdNhanVien);
            var result = taoDonHang.ShowDialog();
            if (taoDonHang.DialogResult == DialogResult.OK)
            {
                var ban = db.BanAns.FirstOrDefault(b => b.IDBan == soBan);
                if (ban != null)
                {
                    ban.trangThaiBanAn = TrangThaiBanAn.DaGoiMon;
                    db.SaveChanges();
                }
                banDangChon.BackColor = Color.OrangeRed;
            }
            // Kiểm tra và set lại trạng thái bàn không có món ăn
            KiemTraBanKhongCoMonAnDeSetLaiTrangThai();
            fNhanVien_Load(null, EventArgs.Empty);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            flpBanAn.Visible = false;
            UCLichSu lichSu = new UCLichSu();
            lichSu.Dock = DockStyle.Right;
            panelNV.Controls.Add(lichSu);
            // Kiểm tra và set lại trạng thái bàn không có món ăn
            KiemTraBanKhongCoMonAnDeSetLaiTrangThai();
            fNhanVien_Load(null, EventArgs.Empty);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            flpBanAn.Visible = false;
            UCTaiKhoan taiKhoan = new UCTaiKhoan(IdNhanVien);
            taiKhoan.Dock = DockStyle.Right;
            panelNV.Controls.Add(taiKhoan);
            // Kiểm tra và set lại trạng thái bàn không có món ăn
            KiemTraBanKhongCoMonAnDeSetLaiTrangThai();
            fNhanVien_Load(null, EventArgs.Empty);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelNV.Controls)
            {
                if (control is UCLichSu || control is UCTaiKhoan)
                {
                    panelNV.Controls.Remove(control);
                    control.Dispose();
                }
            }
            flpBanAn.Visible = true;
            // Kiểm tra và set lại trạng thái bàn không có món ăn
            KiemTraBanKhongCoMonAnDeSetLaiTrangThai();
            fNhanVien_Load(this, EventArgs.Empty);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        { this.Hide();
            fDangnhap dangnhap = new fDangnhap();
            dangnhap.ShowDialog();
        }
    }
}
