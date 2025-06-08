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
using System.Globalization;
using System.Data.Entity;

namespace PBL3.GUI.QuanLy
{
    public partial class UCQLKho : UserControl
    {
        private NguyenLieu_Service nguyenLieuService = new NguyenLieu_Service();  // thao tác với dữ liệu
        private List<NguyenLieu> _nguyenLieus = new List<NguyenLieu>(); //lưu trữ danh sách nglieu đã lọc
        private QLNHDB db = new QLNHDB();
        private List<string> _nguyenLieuThieu = new List<string>(); // Lưu danh sách nguyên liệu thiếu
        private Color EXPIRED_COLOR = Color.Red;
        private Color WARNING_COLOR = Color.Orange;
        private Color NORMAL_COLOR = Color.Green;
        private const string DATE_FORMAT = "dd/MM/yyyy";

        private DateTime ParseDate(string dateStr)
        {
            try
            {
                return DateTime.ParseExact(dateStr, DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public UCQLKho()
        {
            InitializeComponent();
            Load_data();
            LoadKho();
            KiemTraVaHienThiCanhBao();
            SetupDataGridView();
        }

        private void KiemTraVaCapNhatNguyenLieuQuaHan()
        {
            var ngayHienTai = DateTime.Now.Date;
            var nguyenLieuQuaHan = db.nguyenLieu
                .Where(nl => DbFunctions.TruncateTime(nl.hanSuDung) < ngayHienTai && nl.soLuong > 0)
                .ToList();


            if (nguyenLieuQuaHan.Any())
            {
                StringBuilder thongBao = new StringBuilder();
                thongBao.AppendLine("Các nguyên liệu sau đã quá hạn và sẽ được set số lượng về 0:");
                thongBao.AppendLine();

                foreach (var nl in nguyenLieuQuaHan)
                {
                    int soNgayQuaHan = (ngayHienTai - nl.hanSuDung.Date).Days;
                    thongBao.AppendLine($"- {nl.tenNguyenLieu}: quá hạn {soNgayQuaHan} ngày");
                    nl.soLuong = 0;
                }

                db.SaveChanges();
                MessageBox.Show(thongBao.ToString(), "Cảnh báo nguyên liệu quá hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupDataGridView()
        {
            // Thêm sự kiện click cho dgv
            dgvKhoNguyenLieu.CellClick += DgvKhoNguyenLieu_CellClick;
        }

        private void DgvKhoNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var hanSuDungStr = dgvKhoNguyenLieu.Rows[e.RowIndex].Cells["HanSuDung"].Value?.ToString();
                    if (string.IsNullOrEmpty(hanSuDungStr)) return;

                    var hanSuDung = ParseDate(hanSuDungStr);
                    if (hanSuDung == DateTime.MinValue) return;

                    var tenNguyenLieu = dgvKhoNguyenLieu.Rows[e.RowIndex].Cells["TenNguyenLieu"].Value?.ToString();
                    if (string.IsNullOrEmpty(tenNguyenLieu)) return;

                    var soLuongObj = dgvKhoNguyenLieu.Rows[e.RowIndex].Cells["SoLuong"].Value;
                    if (soLuongObj == null || !int.TryParse(soLuongObj.ToString(), out int soLuong)) return;

                    var idObj = dgvKhoNguyenLieu.Rows[e.RowIndex].Cells["ID"].Value;
                    if (idObj == null || !int.TryParse(idObj.ToString(), out int id)) return;

                    if (hanSuDung.Date < DateTime.Now.Date && soLuong > 0)
                    {
                        var soNgayQuaHan = (DateTime.Now.Date - hanSuDung.Date).Days;
                        var message = $"Nguyên liệu '{tenNguyenLieu}' đã quá hạn {soNgayQuaHan} ngày!\nBạn có muốn hủy bỏ nguyên liệu này không?";
                        var result = MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            var nguyenLieu = db.nguyenLieu.Find(id);
                            if (nguyenLieu != null)
                            {
                                nguyenLieu.soLuong = 0;
                                db.SaveChanges();
                                Load_data();
                                MessageBox.Show("Đã hủy bỏ nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void KiemTraVaHienThiCanhBao()
        {
            var danhSachThieu = nguyenLieuService.KiemTraVaDeXuatNguyenLieu();
            _nguyenLieuThieu.Clear();
            
            if (danhSachThieu.Any())
            {
                StringBuilder thongBao = new StringBuilder();
                thongBao.AppendLine("Cần bổ sung thêm nguyên liệu sau vào kho:");
                thongBao.AppendLine();

                foreach (var item in danhSachThieu)
                {
                    double soLuongHienThi = item.SoLuongThieu;
                    if (item.DonVi == "kg")
                    {
                        soLuongHienThi = Math.Round(item.SoLuongThieu / 1000.0, 2);
                    }
                    thongBao.AppendLine($"- {item.TenNguyenLieu}: cần thêm {soLuongHienThi} {item.DonVi}");
                    _nguyenLieuThieu.Add(item.TenNguyenLieu);
                }
                thongBao.AppendLine();
                thongBao.AppendLine("Các nguyên liệu thiếu sẽ được đánh dấu màu đỏ trong bảng.");

                MessageBox.Show(thongBao.ToString(), "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadKho()
        {
            cbbKho.Items.Clear();
            cbbKho.Items.Add("Tất cả");
            
            var khos = db.khoNguyenLieu.ToList();
            foreach (var kho in khos)
            {
                cbbKho.Items.Add(kho.tenKho);
            }
            
            cbbKho.SelectedIndex = 0;
        }

        private void KiemTraVaXoaNguyenLieuTrung()
        {
            // Lấy tất cả nguyên liệu có số lượng = 0
            var nguyenLieuHet = db.nguyenLieu
                .Where(nl => nl.soLuong == 0)
                .GroupBy(nl => nl.tenNguyenLieu)
                .ToList();

            foreach (var group in nguyenLieuHet)
            {
                string tenNguyenLieu = group.Key;
                
                // Kiểm tra xem có nguyên liệu cùng tên còn số lượng không
                var nguyenLieuCon = db.nguyenLieu
                    .Where(nl => nl.tenNguyenLieu == tenNguyenLieu && nl.soLuong > 0)
                    .ToList();

                if (nguyenLieuCon.Any())
                {
                    // Nếu có nguyên liệu cùng tên còn số lượng, xóa các dòng có số lượng = 0
                    foreach (var nl in group)
                    {
                        db.nguyenLieu.Remove(nl);
                    }
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nguyên liệu trùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_data()
        {
            KiemTraVaCapNhatNguyenLieuQuaHan(); // Kiểm tra và cập nhật nguyên liệu quá hạn
            KiemTraVaXoaNguyenLieuTrung(); // Kiểm tra và xóa nguyên liệu trùng
            _nguyenLieus = nguyenLieuService.GetAllNguyenLieu();  
            LoadDataToGridView(_nguyenLieus);
        }

        private void LoadDataToGridView(List<NguyenLieu> nguyenLieus)
        {
            var displayData = nguyenLieus.Select(nl => new
            {
                ID = nl.IDNguyenLieu,
                TenNguyenLieu = nl.tenNguyenLieu,
                DonViTinh = nl.donViTinh,
                SoLuong = nl.soLuong,
                GiaNhap = nl.giaNhap,
                NgayNhap = nl.ngaynhap.ToString(DATE_FORMAT),
                HanSuDung = nl.hanSuDung.ToString(DATE_FORMAT),
                Kho = nl.khoNguyenLieu?.tenKho
            }).ToList();

            dgvKhoNguyenLieu.DataSource = displayData;  
            dgvKhoNguyenLieu.Columns["ID"].Visible = false;  
            dgvKhoNguyenLieu.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dgvKhoNguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
            dgvKhoNguyenLieu.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvKhoNguyenLieu.Columns["GiaNhap"].HeaderText = "Giá Nhập";
            dgvKhoNguyenLieu.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvKhoNguyenLieu.Columns["HanSuDung"].HeaderText = "Hạn Sử Dụng";
            dgvKhoNguyenLieu.Columns["Kho"].HeaderText = "Kho Nguyên Liệu";

            // Xử lý màu sắc cho cột hạn sử dụng
            dgvKhoNguyenLieu.CellFormatting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvKhoNguyenLieu.Columns["HanSuDung"].Index)
                {
                    try
                    {
                        var hanSuDungStr = dgvKhoNguyenLieu.Rows[e.RowIndex].Cells["HanSuDung"].Value?.ToString();
                        if (string.IsNullOrEmpty(hanSuDungStr)) return;

                        var hanSuDung = ParseDate(hanSuDungStr);
                        if (hanSuDung == DateTime.MinValue) return;

                        var soLuongObj = dgvKhoNguyenLieu.Rows[e.RowIndex].Cells["SoLuong"].Value;
                        if (soLuongObj == null || !int.TryParse(soLuongObj.ToString(), out int soLuong)) return;

                        if (soLuong > 0) // Chỉ đánh dấu màu cho nguyên liệu còn tồn kho
                        {
                            var ngayConLai = (hanSuDung.Date - DateTime.Now.Date).Days;

                            if (ngayConLai < 0) // Đã quá hạn
                            {
                                e.CellStyle.ForeColor = EXPIRED_COLOR;
                                e.CellStyle.SelectionForeColor = EXPIRED_COLOR;
                            }
                            else if (ngayConLai <= 3) // Sắp hết hạn (còn 3 ngày hoặc ít hơn)
                            {
                                e.CellStyle.ForeColor = WARNING_COLOR;
                                e.CellStyle.SelectionForeColor = WARNING_COLOR;
                            }
                            else // Bình thường
                            {
                                e.CellStyle.ForeColor = NORMAL_COLOR;
                                e.CellStyle.SelectionForeColor = NORMAL_COLOR;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi định dạng ngày: {ex.Message}");
                    }
                }
            };

            // Xử lý màu cho nguyên liệu thiếu
            dgvKhoNguyenLieu.CellFormatting += DgvKhoNguyenLieu_CellFormatting;
        }

        private void DgvKhoNguyenLieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var tenNguyenLieu = dgvKhoNguyenLieu.Rows[e.RowIndex].Cells["TenNguyenLieu"].Value?.ToString();
                if (_nguyenLieuThieu.Contains(tenNguyenLieu))
                {
                    dgvKhoNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    dgvKhoNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            string selectedKho = cbbKho.SelectedItem?.ToString();

            var filteredList = _nguyenLieus.Where(nl => 
                nl.tenNguyenLieu.ToLower().Contains(keyword) && 
                (selectedKho == "Tất cả" || nl.khoNguyenLieu?.tenKho == selectedKho)
            ).ToList();

            LoadDataToGridView(filteredList);
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            ThemNguyenLieu form = new ThemNguyenLieu(); 
            form.ShowDialog();
            Load_data();
            _nguyenLieuThieu.Clear();
            KiemTraVaHienThiCanhBao();
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (dgvKhoNguyenLieu.SelectedRows.Count > 0)
            {
                string tenNguyenLieu = dgvKhoNguyenLieu.SelectedRows[0].Cells["TenNguyenLieu"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá nguyên liệu này?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var (thanhCong, thongBao) = nguyenLieuService.DeleteNguyenLieu(tenNguyenLieu);
                    if (thanhCong)
                    {
                        MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_data();
                        _nguyenLieuThieu.Clear();
                        KiemTraVaHienThiCanhBao();
                    }
                    else
                    {
                        MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
    }
}
