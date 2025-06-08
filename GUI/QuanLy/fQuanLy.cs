using PBL3.DAL;
using PBL3.GUI.QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.QuanLy
{
    public partial class fQuanLy : Form
    {
        //private Nguoidung user = new Nguoidung();

        private UCHome ucTrangChu;
        private UCThucDon ucThucDon;
        private UCThongKe ucThongKe;
        private UCLichSu ucLichSu;
        private UCQLKho ucQLKho;
        private UCQuanLiTK ucQuanLiTK;

        public fQuanLy()
        {
            InitializeComponent();
            ucTrangChu = new UCHome();
            ucThucDon = new UCThucDon();
            ucThongKe = new UCThongKe();
            ucLichSu = new UCLichSu();
            ucQLKho = new UCQLKho();
            ucQuanLiTK = new UCQuanLiTK();
            ShowUserControl(ucTrangChu);
        }

        private void ShowUserControl(UserControl uc)
        {

            panelContent.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucTrangChu);
        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucThucDon);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        { 
            ShowUserControl(ucThongKe);
        }

        private void btnLichSuDonHang_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucLichSu);
        }

        private void btnQuanLiKho_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucQLKho);
        }

       

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangnhap form = new fDangnhap();
            form.ShowDialog();
        }

        private void btnQuanLiTK_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucQuanLiTK);
        }
    }
}

