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
    public partial class UCQuanLiTK : UserControl
    {
        private Nguoidung_Service service = new Nguoidung_Service();
        private List<Nguoidung> _filterUsers = new List<Nguoidung>(); 
        public UCQuanLiTK()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            _filterUsers = service.GetAllUsers()
                .Where(u => u.phanQuyen != PhanQuyen.User)//cmt lại
                .ToList();
            var displayData = _filterUsers
                .Select(u => new
                {
                    ID = u.IDUser,
                    tenTK = u.tenTaiKhoan,
                    tenUser = u.tenNguoiDung,
                    Email = u.email,
                    role = u.phanQuyen.ToString()
                }).ToList();
            dgvTK.DataSource = displayData;
            dgvTK.Columns["ID"].Visible = false;
            dgvTK.Columns["tenTK"].HeaderText = "Tên tài khoản";
            dgvTK.Columns["tenUser"].HeaderText = "Tên người dùng";
            dgvTK.Columns["Email"].HeaderText = "Email";
            dgvTK.Columns["role"].HeaderText = "Phân quyền";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower().Trim();

            var result = _filterUsers
                .Where(u => u.tenTaiKhoan.ToLower().Contains(keyword))
                .Select(u => new
                {
                    ID = u.IDUser,
                    tenTK = u.tenTaiKhoan,
                    tenUser = u.tenNguoiDung,
                    Email = u.email,
                    role = u.phanQuyen.ToString()
                }).ToList();

            dgvTK.DataSource = result;
        }
        
        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (dgvTK.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTK.SelectedRows[0].Cells["ID"].Value);
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (service.DeleteUser(id))
                    {
                        MessageBox.Show("Xoá thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xoá.");
            }
        }
    }
}
