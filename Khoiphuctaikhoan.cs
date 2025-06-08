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
    public partial class Khoiphuctaikhoan : Form
    {
        private string data;
        public Khoiphuctaikhoan(string data)
        {
            InitializeComponent();
            this.data = data;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!List_DATA.checkma(maxacthuc_txt.Text) || !(newpass_confirm_txt.Text == newpass_txt.Text))
            {
                MessageBox.Show("nhap lai thongtin");
            }
            else
            {
                foreach (account i in List_DATA.tk)
                {
                    if (i.email == data)
                    {
                        i.matkhau = newpass_txt.Text;
                        MessageBox.Show("Mật khẩu đã được thay đổi thành công.");
                        this.Hide();
                        fDangnhap form_login = new fDangnhap();
                        form_login.ShowDialog();
                        return;  
                    }
                }
                MessageBox.Show("Không tìm thấy tài khoản với email này.");
            }
        }

        private void btn_Quaylai_Click(object sender, EventArgs e)
        {
            Quenmatkhau quenmatkhau = new Quenmatkhau();
            quenmatkhau.Show();
            this.Close();
        }
    }
}
