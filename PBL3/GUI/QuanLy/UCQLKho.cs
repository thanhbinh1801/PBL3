using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.BLL;
using PBL3.DAL;

namespace PBL3.GUI.QuanLy
{
    public partial class UCQLKho : UserControl
    {
        private NguyenLieu_Service nguyenLieuService = new NguyenLieu_Service();  // thao tác với dữ liệu
        private List<NguyenLieu> _nguyenLieus = new List<NguyenLieu>(); //lưu trữ danh sách nglieu đã lọc
        public UCQLKho()
        {
            InitializeComponent();
            Load_data();
        }
        private void Load_data()
        {
            _nguyenLieus = nguyenLieuService.GetAllNguyenLieu();  

            var displayData = _nguyenLieus.Select(nl => new
            {
                ID = nl.IDNguyenLieu,
                TenNguyenLieu = nl.tenNguyenLieu,
                DonViTinh = nl.donViTinh,
                SoLuong = nl.soLuong,
                GiaNhap = nl.giaNhap,
                HanSuDung = nl.hanSuDung.ToString("dd/MM/yyyy"),
                Kho = nl.khoNguyenLieu?.tenKho
            }).ToList();

            dgvKhoNguyenLieu.DataSource = displayData;  
            dgvKhoNguyenLieu.Columns["ID"].Visible = false;  
            dgvKhoNguyenLieu.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dgvKhoNguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
            dgvKhoNguyenLieu.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvKhoNguyenLieu.Columns["GiaNhap"].HeaderText = "Giá Nhập";
            dgvKhoNguyenLieu.Columns["HanSuDung"].HeaderText = "Hạn Sử Dụng";
            dgvKhoNguyenLieu.Columns["Kho"].HeaderText = "Kho Nguyên Liệu";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var result = _nguyenLieus
                .Where(nl => nl.tenNguyenLieu.ToLower().Contains(keyword))
                .Select(nl => new
                {
                    ID = nl.IDNguyenLieu,
                    TenNguyenLieu = nl.tenNguyenLieu,
                    DonViTinh = nl.donViTinh,
                    SoLuong = nl.soLuong,
                    GiaNhap = nl.giaNhap,
                    HanSuDung = nl.hanSuDung.ToString("dd/MM/yyyy"),
                    Kho = nl.khoNguyenLieu?.tenKho
                })
                .ToList();
            dgvKhoNguyenLieu.DataSource = result;
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            ThemNguyenLieu form = new ThemNguyenLieu(); 
            form.ShowDialog();
            Load_data();
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (dgvKhoNguyenLieu.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvKhoNguyenLieu.SelectedRows[0].Cells["ID"].Value);
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá nguyên liệu này?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (nguyenLieuService.DeleteNguyenLieu(id)) // sử dụng service để xóa
                    {
                        MessageBox.Show("Xoá thành công!");
                        Load_data(); 
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu để xoá.");
            }
        }
    }
}
