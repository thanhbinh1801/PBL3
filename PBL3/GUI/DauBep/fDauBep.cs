using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI.DauBep
{
    public partial class fDauBep : Form
    {
        QLNHDB db = new QLNHDB();
        public int IdDauBep { get; set; }
        public fDauBep(int iddaubep)
        {
            InitializeComponent();
            IdDauBep = iddaubep;
        }

        private void btnCheBien_Click(object sender, EventArgs e)
        {
            panelDB.Controls.Clear();
            UCCheBien cheBien = new UCCheBien();
            cheBien.Dock = DockStyle.Fill;
            panelDB.Controls.Add(cheBien);
        }



        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            panelDB.Controls.Clear();
            UCTaiKhoan uCTaiKhoan = new UCTaiKhoan(IdDauBep);
            uCTaiKhoan.Dock = DockStyle.Fill;
            panelDB.Controls.Add(uCTaiKhoan);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            panelDB.Controls.Clear();
            UCLichSu uCLichSu = new UCLichSu();
            uCLichSu.Dock = DockStyle.Fill;
            panelDB.Controls.Add(uCLichSu);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelDB.Controls.Clear();
        }
    }
}
