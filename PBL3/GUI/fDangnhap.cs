using PBL3.BLL;
using PBL3.DAL;
using PBL3.GUI.DauBep;
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
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            Nguoidung account = new Nguoidung();
            account = db.GetUserByUsername(tentk_txt.Text);
            if (account == null || !!HashPassword.VerifyPW(mk_txt.Text, account.matKhau))
            {
                MessageBox.Show("nhap sai thong tin tai khoan");
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
                    fDauBep form = new fDauBep();
                    form.ShowDialog();
                }
                else
                {
                    fNhanVien form = new fNhanVien();
                    form.ShowDialog();
                }
            }
        }
    }
}
