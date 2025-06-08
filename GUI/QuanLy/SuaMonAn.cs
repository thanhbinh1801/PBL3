using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PBL3.GUI.QuanLy
{
    public partial class SuaMonAn : Form
    {
        private List<MonAnNguyenLieu> nguyenLieus = new List<MonAnNguyenLieu>();
        private MonAn_Service service = new MonAn_Service();
        private NguyenLieu_Service nguyenlieuservice = new NguyenLieu_Service();
        private int IDMonAnToEdit;
        private string tenmon;
        private QLNHDB db = new QLNHDB();
        public SuaMonAn(string tenMonAn)
        {
            InitializeComponent();
            MonAn currentMonAn = service.GetMonAnByName(tenMonAn).FirstOrDefault();
            if (currentMonAn != null)
            {
                IDMonAnToEdit = currentMonAn.IDMonAn;
                txtTenMonAn.Text = currentMonAn.tenMonAn;
                txtGiaBan.Text = currentMonAn.giaBan.ToString();
                tenmon = tenMonAn;
            }

            LoadData();
        }

        private void LoadData()
        {
            ccbDVi.Items.Add("G");
            ccbDVi.Items.Add("KG");
            ccbDVi.SelectedIndex = 0;
            List<NguyenLieu> kho = nguyenlieuservice.GetAllNguyenLieu();
            foreach (NguyenLieu i in kho)
            {
                ccbNL.Items.Add(i.tenNguyenLieu);
            }
            nguyenLieus = service.GetMonAnNguyenLieuByMonAnId(IDMonAnToEdit);
            var displayData = nguyenLieus.Select(nl => new
            {
                tenNguyenLieu = nl.tenNguyenLieu,
                soLuong = nl.soLuong,
                donVi = nl.donVi
            }).ToList();

            dgvNguyenLieu.DataSource = displayData;
            dgvNguyenLieu.Columns["tenNguyenLieu"].HeaderText = "Tên nguyên liệu";
            dgvNguyenLieu.Columns["soLuong"].HeaderText = "Số lượng";
            dgvNguyenLieu.Columns["donVi"].HeaderText = "Đơn vị";
        }

        private void btn_themNL_Click(object sender, EventArgs e)
        {
            int soLuong;
            if (!int.TryParse(txtSL.Text, out soLuong))
            {
                MessageBox.Show("Nhập số lượng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nguyenLieuData = nguyenlieuservice.GetNguyenLieuByName(ccbNL.Text);
            if (nguyenLieuData.Count == 0)
            {
                MessageBox.Show("Nguyên liệu không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonAnNguyenLieu nguyenlieu_new = new MonAnNguyenLieu
            {
                tenNguyenLieu = ccbNL.Text,
                donVi = ccbDVi.Text,
                soLuong = soLuong,
                IDMonAn = IDMonAnToEdit
            };

            var existingItem = nguyenLieus.FirstOrDefault(nl => nl.tenNguyenLieu == nguyenlieu_new.tenNguyenLieu);

            if (existingItem != null)
            {
                if (existingItem.donVi == nguyenlieu_new.donVi)
                {
                    existingItem.soLuong += soLuong;
                }
                else
                {
                    MessageBox.Show("Không thể cộng số lượng do đơn vị khác nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                nguyenLieus.Add(nguyenlieu_new);
            }

            var displayData = nguyenLieus.Select(nl => new
            {
                tenNguyenLieu = nl.tenNguyenLieu,
                soLuong = nl.soLuong,
                donVi = nl.donVi
            }).ToList();

            dgvNguyenLieu.DataSource = displayData;
            dgvNguyenLieu.Columns["tenNguyenLieu"].HeaderText = "Tên nguyên liệu";
            dgvNguyenLieu.Columns["soLuong"].HeaderText = "Số lượng";
            dgvNguyenLieu.Columns["donVi"].HeaderText = "Đơn vị";
        }

        private void btnSuaMonAn_Click_1(object sender, EventArgs e)
        {
            string tenMonAn = txtTenMonAn.Text.Trim();
            int giaBan;

            if (string.IsNullOrEmpty(tenMonAn))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtGiaBan.Text) || !int.TryParse(txtGiaBan.Text, out giaBan))
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonAn updatedMonAn = new MonAn
            {
                tenMonAn = tenMonAn,
                giaBan = giaBan,
                trangThai = TrangThaiMonAn.Con
            };

            if (service.UpdateMonAn(IDMonAnToEdit, updatedMonAn))
            {
                // Xóa tất cả nguyên liệu cũ
                var oldIngredients = db.MonAnNguyenLieux.Where(m => m.IDMonAn == IDMonAnToEdit);
                db.MonAnNguyenLieux.RemoveRange(oldIngredients);
                db.SaveChanges();

                // Thêm lại các nguyên liệu mới
                foreach (var nl in nguyenLieus)
                {
                    nl.IDMonAn = IDMonAnToEdit;
                    service.AddMonAnNguyenLieu(nl);
                }

                MessageBox.Show("Cập nhật món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Cập nhật món ăn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi click vào header hoặc dòng không hợp lệ
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa nguyên liệu này?", "Xác nhận",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Lấy tên nguyên liệu từ dòng được chọn
            string tenNguyenLieu = dgvNguyenLieu.Rows[e.RowIndex].Cells["tenNguyenLieu"].Value?.ToString();
            if (string.IsNullOrEmpty(tenNguyenLieu)) return;

            // Thực hiện xóa
            var nguyenLieu = nguyenlieuservice.GetNguyenLieuByName(tenNguyenLieu).FirstOrDefault();
            if (nguyenLieu != null)
            {
                nguyenLieus.RemoveAll(nl => nl.tenNguyenLieu == nguyenLieu.tenNguyenLieu);
                UpdateDataGridView(); // Gọi hàm cập nhật
            }
        }

        // Hàm riêng để cập nhật DataGridView
        private void UpdateDataGridView()
        {
            dgvNguyenLieu.DataSource = nguyenLieus.Select(nl => new
            {
                tenNguyenLieu = nl.tenNguyenLieu,
                soLuong = nl.soLuong,
                donVi = nl.donVi
            }).ToList();
        }

        private void dgvNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
