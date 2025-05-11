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
    public partial class UCCheBien : UserControl
    {
        QLNHDB db = new QLNHDB();
        public UCCheBien()
        {
            InitializeComponent();
            LoadDonHang();
        }
        public void LoadDonHang()
        {
            var donhang = db.donHang.Where( db => db.trangThai == DAL.TrangThaiDonHang.DangXuLy).ToList();
            cbbDanhSachDonHang.DataSource = donhang;
            cbbDanhSachDonHang.DisplayMember = "IDBan";
            cbbDanhSachDonHang.ValueMember = "IDDonHang";
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int idDonHang = (int)cbbDanhSachDonHang.SelectedValue;
            var listMonAn = db.donHangChiTiet.Where( dh => dh.IDDonHang == idDonHang)
                                .Select(ma => ma.monAn).ToList();
            dgvMonAn.DataSource = listMonAn;
        }
    }
}
