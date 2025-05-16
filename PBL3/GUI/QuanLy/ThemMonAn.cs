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
    public partial class ThemMonAn : Form
    {
        private List<MonAnNguyenLieu> nguyenLieus = new List<MonAnNguyenLieu>();
        private MonAn_Service service = new MonAn_Service();
        private NguyenLieu_Service nguyenlieuservice = new NguyenLieu_Service();
        public ThemMonAn()
        {
            InitializeComponent();
            ThemMonAn_Load();
        }
        private void ThemMonAn_Load()
        {
            ccbDVi .Items.Add("KG");
            ccbDVi.Items.Add("G");
            ccbDVi.SelectedIndex = 0;
            List<NguyenLieu> kho = nguyenlieuservice.GetAllNguyenLieu();
            foreach(NguyenLieu i in kho)
            {
                ccbNL.Items.Add(i.tenNguyenLieu);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
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
            MonAn newMonAn = new MonAn
            {
                tenMonAn = tenMonAn,
                giaBan = giaBan, 
                trangThai = TrangThaiMonAn.Con
            };

            if (service.AddMonAn(newMonAn ))
            {
                foreach (MonAnNguyenLieu i in nguyenLieus)
                {
                    i.IDMonAn = newMonAn.IDMonAn;
                    service.AddMonAnNguyenLieu(i);
                }
               
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 

            }
            else
            {
                MessageBox.Show("Thêm món ăn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btn_themNL_Click(object sender, EventArgs e)
        {
            NguyenLieu nguyenLieu = new NguyenLieu
            {
                tenNguyenLieu = ccbNL.Text,
                donViTinh = ccbDVi.Text
            };
            int soLuong;
            if (int.TryParse(txtSL.Text, out soLuong))
            {
                nguyenLieu.soLuong = soLuong;
            }
            else
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

            int IDNguyenLieu = nguyenLieuData[0].IDNguyenLieu;

            MonAnNguyenLieu nguyenlieu_new = new MonAnNguyenLieu
            {
                IDNguyenLieu = IDNguyenLieu,
                donVi = ccbDVi.Text,
                soLuong = soLuong
            };

            var existingItem = nguyenLieus.FirstOrDefault(nl => nl.IDNguyenLieu == nguyenlieu_new.IDNguyenLieu);

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
                tenNguyenLieu = nguyenlieuservice.GetNguyenLieuById(nl.IDNguyenLieu).tenNguyenLieu,
                soLuong = nl.soLuong,
                donVi = nl.donVi
            }).ToList();

            dgvNguyenLieu.DataSource = displayData;
            dgvNguyenLieu.Columns["tenNguyenLieu"].HeaderText = "Tên nguyên liệu";
            dgvNguyenLieu.Columns["soLuong"].HeaderText = "Số lượng";
            dgvNguyenLieu.Columns["donVi"].HeaderText = "Đơn vị";
        }

    }
}
