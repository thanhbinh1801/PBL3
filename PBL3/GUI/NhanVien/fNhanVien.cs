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
            foreach ( Control ctrl in flpBanAn.Controls)
            {
                if (ctrl is Button btn)
                {
                    var ban = dsachban.FirstOrDefault(b => b.IDBan == stt);
                    if (ban != null)
                    {
                        if (ban.trangThaiBanAn == TrangThaiBanAn.Trong)
                        {
                            btn.BackColor = Color.LightGray;
                            btn.Enabled = true;
                        }
                        else
                        {
                            btn.BackColor = Color.OrangeRed;
                            btn.Enabled = false;
                        }
                        btn.Click += Btn_Click;
                        btn.Tag = stt++;
                    }
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (banDangChon != null)
            {
                // Lấy lại trạng thái thực tế của bàn trước đó
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
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            flpBanAn.Visible = false;
            panelNV.Controls.Clear();
            UCLichSu lichSu = new UCLichSu();
            lichSu.Dock = DockStyle.Right;
            panelNV.Controls.Add(lichSu);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            flpBanAn.Visible = false;
            panelNV.Controls.Clear();
            UCTaiKhoan taiKhoan = new UCTaiKhoan(IdNhanVien);
            taiKhoan.Dock = DockStyle.Right;
            panelNV.Controls.Add(taiKhoan);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            flpBanAn.Visible = true;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangnhap dangnhap = new fDangnhap();
            dangnhap.ShowDialog();
        }
    }
}
