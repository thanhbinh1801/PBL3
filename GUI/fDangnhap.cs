using PBL3.BLL;
using PBL3.DAL;
using PBL3.GUI;
using PBL3.GUI.DauBep;
using PBL3.GUI.QuanLy;
using PBL3.QuanLy;
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
    public partial class fDangnhap : Form
    {
        Nguoidung_Service db = new Nguoidung_Service();
        public fDangnhap()
        {
            InitializeComponent();
            
            // Configure password TextBox
            mk_txt.PasswordChar = '*';
            mk_txt.Multiline = false;
            
            // Add event handlers for placeholder text
            mk_txt.Enter += (s, e) => {
                if (mk_txt.Text == "Mật khẩu")
                {
                    mk_txt.Text = "";
                    mk_txt.PasswordChar = '*';
                }
            };
            
            mk_txt.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(mk_txt.Text))
                {
                    mk_txt.Text = "Mật khẩu";
                    mk_txt.PasswordChar = '\0';  // Show placeholder text normally
                }
            };
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            Nguoidung account = new Nguoidung();
            account = db.GetUserByUsername(tentk_txt.Text);
            if (account == null || !!HashPassword.VerifyPW(mk_txt.Text, account.matKhau))
            {
                MessageBox.Show("Nhập sai thông tin tài khoản");
            }
            else
            {
                this.Hide();
                if (account.phanQuyen == PhanQuyen.QuanLy)
                {
                    fQuanLy form = new fQuanLy();
                    form.ShowDialog();
                }
                else if (account.phanQuyen == PhanQuyen.DauBep)
                {
                    fDauBep form = new fDauBep(account.IDUser);
                    form.ShowDialog();
                }
                else
                {
                    fNhanVien form = new fNhanVien(account.IDUser);
                    form.ShowDialog();
                }
            }
        }

        private void lable_dangki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            fDangki form = new fDangki();
            form.ShowDialog();
        }

        private void lable_doimk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            email form = new email();
            form.ShowDialog();  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fDangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}