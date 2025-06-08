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
using PBL3.GUI.QuanLy;

namespace PBL3
{
    public partial class UCThucDon : UserControl
    {
        private MonAn_Service service = new MonAn_Service();  // Khởi tạo lớp MonAn_Service
        private List<MonAn> _filterMonAns = new List<MonAn>();  // Lưu trữ danh sách món ăn
        public UCThucDon()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            // Lấy tất cả món ăn 
            _filterMonAns = service.GetAllMonAn().ToList();
            // Chuyển đổi danh sách món ăn thành một danh sách có thể hiển thị
            var displayData = _filterMonAns
                .Select(m => new
                {
                    ID = m.IDMonAn, 
                    tenMonAn = m.tenMonAn,
                    giaBan = m.giaBan,
                    trangThai = m.trangThai
                }).ToList();
            // Đưa dữ liệu vào dgv 
            dgvThucDon.DataSource = displayData;
            // Tùy chỉnh hiển thị trong dgv
                dgvThucDon.Columns["ID"].Visible = false;
                dgvThucDon.Columns["tenMonAn"].HeaderText = "Tên món ăn";
                dgvThucDon.Columns["giaBan"].HeaderText = "Giá bán";
                dgvThucDon.Columns["trangThai"].HeaderText = "Trạng thái";
        }
        private void btnTimKiem_QL_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower().Trim();  // Lấy từ khóa tìm kiếm
            // Tìm kiếm món ăn theo tên
            var result = _filterMonAns
                .Where(m => m.tenMonAn.ToLower().Contains(keyword))
                .Select(m => new
                {
                    ID = m.IDMonAn,
                    tenMonAn = m.tenMonAn,
                    giaBan = m.giaBan,
                    trangThai = m.trangThai
                }).ToList();
            dgvThucDon.DataSource = result;  // Hiển thị kết quả tìm kiếm trong gdv
        }
        private void btnXoaMonAn_QL_Click(object sender, EventArgs e)
        {
            if (dgvThucDon.SelectedRows.Count > 0) 
            {
                int id = Convert.ToInt32(dgvThucDon.SelectedRows[0].Cells["ID"].Value);  
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá món ăn này?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (service.DeleteMonAn(id))
                    {
                        MessageBox.Show("Xoá món ăn thành công!");
                        LoadData();  
                    }
                    else
                    {
                        MessageBox.Show("Xóa món ăn thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn để xóa.");
            }
        }

        private void btnSuaMonAn_Click(object sender, EventArgs e)
        {
            if (dgvThucDon.SelectedRows.Count > 0)
            {
                string tenMonAn = dgvThucDon.SelectedRows[0].Cells["tenMonAn"].Value.ToString();
                SuaMonAn form = new SuaMonAn(tenMonAn);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            ThemMonAn form = new ThemMonAn();
            form.ShowDialog();
            LoadData();
        }

        private void pnControlFoodQL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvThucDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
