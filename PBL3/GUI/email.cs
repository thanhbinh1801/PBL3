using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI
{
    public partial class email : Form
    {
        QLNHDB db = new QLNHDB();
        public email()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email");
            }
            else
            {
                var user = db.nguoidungs.Where(x => x.email == txtEmail.Text).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("Email không tồn tại");
                }
                else
                {
                    this.Hide();
                    DoiMatKhau form = new DoiMatKhau(user.IDUser);
                }
            }
        }
    }
}
