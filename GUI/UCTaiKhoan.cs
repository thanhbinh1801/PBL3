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
    public partial class UCTaiKhoan : UserControl
    {
        public int IDNHANVIEN;
        QLNHDB db = new QLNHDB();
        public UCTaiKhoan(int idnhanvien)
        {
            InitializeComponent();
            IDNHANVIEN = idnhanvien;
            LoadData();
        }
        public void LoadData()
        {
            var nhanvien = db.nguoidungs.Where( u => u.IDUser == IDNHANVIEN).FirstOrDefault();
            if (nhanvien != null)
            {
                txtHoTen.Text = nhanvien.tenNguoiDung;
                txtTenTaiKhoan.Text = nhanvien.tenTaiKhoan;
                txtEmail.Text = nhanvien.email;
                txtVaiTro.Text = nhanvien.phanQuyen.ToString();
            }
            txtHoTen.Enabled = false;
            txtTenTaiKhoan.Enabled = false;
            txtEmail.Enabled = false;
            txtVaiTro.Enabled = false;
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            txtTenTaiKhoan.Enabled = true;
            txtEmail.Enabled = true;    
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "" || txtTenTaiKhoan.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            var nhanvien = db.nguoidungs.Where ( u => u.IDUser == IDNHANVIEN).FirstOrDefault();
            if (nhanvien != null){
                nhanvien.tenNguoiDung = txtHoTen.Text;
                nhanvien.tenTaiKhoan = txtTenTaiKhoan.Text;
                nhanvien.email = txtEmail.Text;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thông tin thành công");
                txtHoTen.Enabled = false;
                txtTenTaiKhoan.Enabled = false;
                txtEmail.Enabled = false;
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thất bại");
            }
        }

        private void pbAnhNguoiDung_Click(object sender, EventArgs e)
        {

        }
    }
}
