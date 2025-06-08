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
    public partial class DoiMatKhau : Form
    {
        private int idUser;
        public DoiMatKhau(int iduser)
        {
            InitializeComponent();
            idUser = iduser;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangnhap form = new fDangnhap();
            form.ShowDialog();
        }
    }
}
