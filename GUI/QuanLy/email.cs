using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI.QuanLy
{
    public partial class email: Form
    {
        private readonly QLNHDB db = new QLNHDB();

        public email()
        {
            InitializeComponent();
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            string mail = txt_mail.Text;
            var user = db.nguoidungs.FirstOrDefault(u => u.email == mail);
            if (user != null)
            {
                DoiMatKhau form = new DoiMatKhau(user.IDUser);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản với email này!");
            }
        }
    }
}
