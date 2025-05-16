using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Nguoidung_Service db = new Nguoidung_Service();
            //Nguoidung new_user = new Nguoidung();
            //new_user.email = "admin@gmail.com";
            //new_user.phanQuyen = PhanQuyen.QuanLy;
            //new_user.matKhau = "admin123";
            //new_user.tenNguoiDung = "admin";
            //new_user.tenTaiKhoan = "admin";

            //Nguoidung user1 = new Nguoidung();
            //user1.email = "user1@gmail.com";
            //user1.phanQuyen = PhanQuyen.NhanVien;
            //user1.matKhau = "user1123";
            //user1.tenNguoiDung = "User 1";
            //user1.tenTaiKhoan = "user1";

            //Nguoidung user2 = new Nguoidung();
            //user2.email = "user2@gmail.com";
            //user2.phanQuyen = PhanQuyen.DauBep;
            //user2.matKhau = "user2123";
            //user2.tenNguoiDung = "User 2";
            //user2.tenTaiKhoan = "user2";

            //db.AddUser(new_user);
            //db.AddUser(user1);
            //db.AddUser(user2);

            // Chuẩn hóa nguyên liệu khi khởi động chương trình
            try
            {
                NguyenLieu_Service nguyenLieuService = new NguyenLieu_Service();
                nguyenLieuService.ChuanHoaTatCaNguyenLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuẩn hóa nguyên liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new fDangnhap());
        }
    }
}
