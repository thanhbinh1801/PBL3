using PBL3.BLL;
using PBL3.DAL;
using PBL3.Utils;
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
    public partial class fDangki : Form
    {
        Validate validate = new Validate();
        QLNHDB db  = new QLNHDB();
        public fDangki()
        {
            InitializeComponent();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (validate.checkHVT(txtHVT.Text) && validate.checkEmail(txtEmail.Text) && validate.checkTenTK(txtTenTK.Text) 
                && validate.checkMK(txtMK.Text) )
            {
                //&& validate.checkPhanQuyen(rbNhanVien, rbDauBep)
                try
                {
                    Console.WriteLine("bat dau dang ki");
                    Nguoidung nguoiDung = new Nguoidung()
                    {
                        tenNguoiDung = txtHVT.Text,
                        tenTaiKhoan = txtTenTK.Text,
                        matKhau = HashPassword.HashPW(txtMK.Text),
                        //phanQuyen = rbNhanVien.Checked ? PhanQuyen.NhanVien : PhanQuyen.DauBep,
                        phanQuyen = PhanQuyen.QuanLy,
                        email = txtEmail.Text,
                    };
                    db.nguoidungs.Add(nguoiDung);
                    Console.WriteLine("da add nguoi dung");
                    db.SaveChanges();
                    MessageBox.Show("Đăng kí thành công");
                    this.Hide();
                    new fDangnhap().ShowDialog();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Đăng kí không thành công" + err.Message);
                }
            }
        }
    }
}
