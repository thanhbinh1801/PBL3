using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PBL3.Utils
{
    public class Validate
    {
        public bool checkHVT(string hvt)
        {
            if (hvt == "")
            {
                MessageBox.Show("Vui lòng nhập họ và tên");
                return false;
            }
            return true;
        }

    public bool checkEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            MessageBox.Show("Vui lòng nhập email");
            return false;
        }

        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(email, emailPattern))
        {
            MessageBox.Show("Email không hợp lệ");
            return false;
        }

        return true;
    }

    public bool checkTenTK(string tentk)
        {
            if (tentk.Length < 9)
            {
                MessageBox.Show("Tên tài khoản phải lớn hơn 9 ký tự");
                return false;
            }
            return true;
        }
        public bool checkMK(string mk)
        {
            if (mk.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải lớn hơn 6 ký tự");
                return false;
            }
            return true;
        }
        public bool checkPhanQuyen(RadioButton DauBep, RadioButton NhanVien)
        {
            if (DauBep.Checked == false && NhanVien.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn quyền");
                return false;
            }
            return true;
        }
    }
}
