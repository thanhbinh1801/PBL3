using PBL3.BLL;
using PBL3.DAL;
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
    public partial class ThemNguyenLieu : Form
    {
        private NguyenLieu_Service nguyenLieuService = new NguyenLieu_Service();
        public ThemNguyenLieu()
        {
            InitializeComponent();
            ThemNguyenLieu_Load();
        }
        private void ThemNguyenLieu_Load()
        {
            ccbDonVi.Items.Add("kg");
            ccbDonVi.Items.Add("g");
            //ccbDonVi.Items.Add("tấn");
            ccbDonVi.SelectedIndex = 0;  
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string tenNguyenLieu = txtTenNL.Text.Trim();
            int soLuong = int.TryParse(txtSoLuong.Text.Trim(), out soLuong) ? soLuong : 0;  
            string donViTinh = ccbDonVi.SelectedItem?.ToString(); 
            double giaNhap = double.TryParse(txtGiaNhap.Text.Trim(), out giaNhap) ? giaNhap : 0;  
            DateTime hanSuDung = dtpHSD.Value;  
            if (string.IsNullOrEmpty(tenNguyenLieu) || soLuong == 0 || string.IsNullOrEmpty(donViTinh) || giaNhap == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            NguyenLieu nguyenLieu = new NguyenLieu
            {
                tenNguyenLieu = tenNguyenLieu,
                soLuong = soLuong,
                donViTinh = donViTinh,
                giaNhap = giaNhap,
                hanSuDung = hanSuDung,
                IDKho = 1  
            };
            bool result =  nguyenLieuService.AddNguyenLieu(nguyenLieu);

            if (result)
            {
                MessageBox.Show("Thêm nguyên liệu thành công!");
                this.Close();  // Đóng form sau khi thêm thành công
            }
            else
            {
                MessageBox.Show("Thêm nguyên liệu thất bại. Vui lòng thử lại.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
