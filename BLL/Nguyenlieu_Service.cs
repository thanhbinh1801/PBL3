using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DAL;

namespace PBL3.BLL
{
    public class NguyenLieu_Service
    {
        private QLNHDB db = new QLNHDB();  

        // Chuẩn hóa tất cả nguyên liệu trong database về gram
        public void ChuanHoaTatCaNguyenLieu()
        {
            try
            {
                var allNguyenLieu = db.nguyenLieu.ToList();
                bool coThayDoi = false;

                foreach (var nl in allNguyenLieu)
                {
                    if (nl.donViTinh.ToUpper() == "KG")
                    {
                        nl.soLuong *= 1000;
                        nl.donViTinh = "g";
                        coThayDoi = true;
                    }
                    else if (nl.donViTinh.ToUpper() == "G")
                    {
                        nl.donViTinh = "g";
                        coThayDoi = true;
                    }
                }

                if (coThayDoi)
                {
                    db.SaveChanges();
                }

                // Chuẩn hóa MonAnNguyenLieu
                var allMonAnNL = db.MonAnNguyenLieux.ToList();
                coThayDoi = false;

                foreach (var manl in allMonAnNL)
                {
                    if (manl.donVi.ToUpper() == "KG")
                    {
                        manl.soLuong *= 1000;
                        manl.donVi = "g";
                        coThayDoi = true;
                    }
                    else if (manl.donVi.ToUpper() == "G")
                    {
                        manl.donVi = "g";
                        coThayDoi = true;
                    }
                }

                if (coThayDoi)
                {
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi chuẩn hóa nguyên liệu: {ex.Message}");
                throw; // Ném lại exception để Program.cs có thể bắt và hiển thị
            }
        }

        // Chuẩn hóa đơn vị về gram và số lượng tương ứng
        private void ChuanHoaDonVi(NguyenLieu nguyenLieu)
        {
            if (nguyenLieu.donViTinh.ToUpper() == "KG")
            {
                nguyenLieu.soLuong *= 1000;
                nguyenLieu.donViTinh = "g";
            }
            else if (nguyenLieu.donViTinh.ToUpper() == "G")
            {
                nguyenLieu.donViTinh = "g";
            }
        }

        // CREATE
        public bool AddNguyenLieu(NguyenLieu nguyenLieu)
        {
            try
            {
                // Chuẩn hóa đơn vị trước khi thêm
                ChuanHoaDonVi(nguyenLieu);
                db.nguyenLieu.Add(nguyenLieu);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm nguyên liệu: {ex.Message}");
                return false;
            }
        }

        // READ
        public List<NguyenLieu> GetAllNguyenLieu()
        {
            return db.nguyenLieu.ToList();
        }

        public List<NguyenLieu> GetNguyenLieuByName(string name)
        {
            return db.nguyenLieu.Where(nl => nl.tenNguyenLieu.Contains(name)).ToList();
        }

        public List<NguyenLieu> GetNguyenLieuByExactName(string name)
        {
            return db.nguyenLieu.Where(nl => nl.tenNguyenLieu == name).ToList();
        }

        // UPDATE
        public bool UpdateNguyenLieu(int id, NguyenLieu updatedNguyenLieu)
        {
            try
            {
                var existingNguyenLieu = db.nguyenLieu.Find(id);
                if (existingNguyenLieu == null) return false;

                // Chuẩn hóa đơn vị của nguyên liệu mới
                ChuanHoaDonVi(updatedNguyenLieu);

                existingNguyenLieu.tenNguyenLieu = updatedNguyenLieu.tenNguyenLieu;
                existingNguyenLieu.donViTinh = updatedNguyenLieu.donViTinh;
                existingNguyenLieu.soLuong = updatedNguyenLieu.soLuong;
                existingNguyenLieu.giaNhap = updatedNguyenLieu.giaNhap;
                existingNguyenLieu.hanSuDung = updatedNguyenLieu.hanSuDung;
                existingNguyenLieu.IDKho = updatedNguyenLieu.IDKho;

                db.SaveChanges();  
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật nguyên liệu: {ex.Message}");
                return false;
            }
        }

        // DELETE
        public (bool ThanhCong, string ThongBao) DeleteNguyenLieu(string tenNguyenLieu)
        {
            var nguyenLieus = db.nguyenLieu.Where(nl => nl.tenNguyenLieu == tenNguyenLieu).ToList();
            if (!nguyenLieus.Any()) return (false, "Không tìm thấy nguyên liệu");

            // Kiểm tra xem nguyên liệu có đang được sử dụng trong món ăn nào không
            var monAnSuDung = db.MonAnNguyenLieux
                .Where(m => m.tenNguyenLieu == tenNguyenLieu)
                .Select(m => m.MonAn.tenMonAn)
                .ToList();

            if (monAnSuDung.Any())
            {
                string danhSachMon = string.Join(", ", monAnSuDung);
                return (false, $"Không thể xóa nguyên liệu '{tenNguyenLieu}' vì đang được sử dụng trong các món ăn: {danhSachMon}");
            }

            try
            {
                // Xóa tất cả các bản ghi nguyên liệu có cùng tên
                db.nguyenLieu.RemoveRange(nguyenLieus);
                db.SaveChanges();  
                return (true, "Xóa nguyên liệu thành công");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi khi xóa nguyên liệu: {ex.Message}");
            }
        }

        // Kiểm tra đủ nguyên liệu cho món ăn
        public (bool DuNguyenLieu, string ThieuNguyenLieu) KiemTraDuNguyenLieu(int idMonAn, int soPhan)
        {
            var monAnNguyenLieus = db.MonAnNguyenLieux.Where(m => m.IDMonAn == idMonAn).ToList();
            StringBuilder thieu = new StringBuilder();

            foreach (var manl in monAnNguyenLieus)
            {
                // Lấy tất cả nguyên liệu cùng tên, sắp xếp theo hạn sử dụng gần nhất
                var nguyenLieus = db.nguyenLieu
                    .Where(nl => nl.tenNguyenLieu == manl.tenNguyenLieu)
                    .OrderBy(nl => nl.hanSuDung)
                    .ToList();

                if (!nguyenLieus.Any())
                {
                    thieu.AppendLine($"- {manl.tenNguyenLieu} (không có trong kho)");
                    continue;
                }

                // Tính tổng số lượng cần
                int soLuongCan = manl.soLuong;
                if (manl.donVi.ToUpper() == "KG")
                {
                    soLuongCan *= 1000;
                }
                soLuongCan *= soPhan;

                // Tính tổng số lượng có
                int tongSoLuongCo = nguyenLieus.Sum(nl => nl.soLuong);

                if (tongSoLuongCo < soLuongCan)
                {
                    thieu.AppendLine($"- {manl.tenNguyenLieu} (còn {tongSoLuongCo}g, cần thêm {soLuongCan - tongSoLuongCo}g)");
                }
            }

            return (thieu.Length == 0, thieu.ToString());
        }

        // Trừ nguyên liệu trong kho
        public bool TruNguyenLieu(int idMonAn, int soPhan)
        {
            try
            {
                var monAnNguyenLieus = db.MonAnNguyenLieux.Where(m => m.IDMonAn == idMonAn).ToList();
                
                foreach (var manl in monAnNguyenLieus)
                {
                    // Lấy tất cả nguyên liệu cùng tên, sắp xếp theo hạn sử dụng gần nhất
                    var nguyenLieus = db.nguyenLieu
                        .Where(nl => nl.tenNguyenLieu == manl.tenNguyenLieu)
                        .OrderBy(nl => nl.hanSuDung)
                        .ToList();

                    if (!nguyenLieus.Any()) continue;

                    // Tính số lượng cần trừ
                    int soLuongTru = manl.soLuong;
                    if (manl.donVi.ToUpper() == "KG")
                    {
                        soLuongTru *= 1000;
                    }
                    soLuongTru *= soPhan;

                    // Trừ dần từng nguyên liệu theo thứ tự hạn sử dụng
                    foreach (var nl in nguyenLieus)
                    {
                        if (soLuongTru <= 0) break;

                        if (nl.soLuong >= soLuongTru)
                        {
                            nl.soLuong -= soLuongTru;
                            soLuongTru = 0;
                        }
                        else
                        {
                            soLuongTru -= nl.soLuong;
                            nl.soLuong = 0;
                        }
                    }
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi trừ nguyên liệu: {ex.Message}");
                return false;
            }
        }

        // Kiểm tra và đề xuất số lượng nguyên liệu cần thêm
        public List<(string TenNguyenLieu, int SoLuongThieu, string DonVi, double GiaNhapDuKien)> KiemTraVaDeXuatNguyenLieu(int soPhanToiThieu = 5)
        {
            // Dictionary để tổng hợp số lượng nguyên liệu cần cho mỗi loại
            Dictionary<string, (int SoLuongCan, int SoLuongHienCo, string DonVi, double GiaNhap)> nguyenLieuThieu = new Dictionary<string, (int, int, string, double)>();

            // Lấy tất cả món ăn
            var monAns = db.MonAns.ToList();

            foreach (var monAn in monAns)
            {
                // Lấy công thức của món ăn
                var congThuc = db.MonAnNguyenLieux.Where(m => m.IDMonAn == monAn.IDMonAn).ToList();

                foreach (var thanhPhan in congThuc)
                {
                    // Lấy tất cả nguyên liệu cùng tên, sắp xếp theo hạn sử dụng gần nhất
                    var nguyenLieus = db.nguyenLieu
                        .Where(nl => nl.tenNguyenLieu == thanhPhan.tenNguyenLieu)
                        .OrderBy(nl => nl.hanSuDung)
                        .ToList();

                    if (!nguyenLieus.Any()) continue;

                    // Chuẩn hóa về gram
                    int soLuongCanChoMotMon = thanhPhan.soLuong;
                    if (thanhPhan.donVi.ToUpper() == "KG")
                    {
                        soLuongCanChoMotMon *= 1000;
                    }

                    // Tính tổng số lượng cần cho số phần tối thiểu
                    int tongSoLuongCan = soLuongCanChoMotMon * soPhanToiThieu;

                    // Tính tổng số lượng có
                    int tongSoLuongCo = nguyenLieus.Sum(nl => nl.soLuong);

                    // Lấy giá nhập từ nguyên liệu có hạn sử dụng gần nhất
                    double giaNhap = nguyenLieus.First().giaNhap;

                    // Cập nhật vào dictionary
                    if (!nguyenLieuThieu.ContainsKey(thanhPhan.tenNguyenLieu))
                    {
                        nguyenLieuThieu[thanhPhan.tenNguyenLieu] = (
                            tongSoLuongCan,
                            tongSoLuongCo,
                            "g",
                            giaNhap
                        );
                    }
                    else
                    {
                        var current = nguyenLieuThieu[thanhPhan.tenNguyenLieu];
                        nguyenLieuThieu[thanhPhan.tenNguyenLieu] = (
                            Math.Max(current.SoLuongCan, tongSoLuongCan),
                            current.SoLuongHienCo,
                            current.DonVi,
                            current.GiaNhap
                        );
                    }
                }
            }

            // Chuyển đổi kết quả sang danh sách các nguyên liệu thiếu
            var ketQua = new List<(string TenNguyenLieu, int SoLuongThieu, string DonVi, double GiaNhapDuKien)>();

            foreach (var item in nguyenLieuThieu)
            {
                int soLuongThieu = item.Value.SoLuongCan - item.Value.SoLuongHienCo;
                if (soLuongThieu > 0)
                {
                    // Nếu số lượng thiếu > 1000g, chuyển sang kg
                    string donVi = item.Value.DonVi;
                    double soLuongHienThi = soLuongThieu;
                    double giaNhapDuKien = item.Value.GiaNhap;

                    if (soLuongThieu >= 1000)
                    {
                        soLuongHienThi = Math.Round(soLuongThieu / 1000.0, 2);
                        donVi = "kg";
                        // Điều chỉnh giá nhập theo kg
                        giaNhapDuKien = item.Value.GiaNhap * (soLuongHienThi);
                    }

                    ketQua.Add((
                        item.Key,
                        soLuongThieu,
                        donVi,
                        giaNhapDuKien
                    ));
                }
            }

            return ketQua;
        }

        // Kiểm tra nguyên liệu quá hạn sử dụng
        public List<(string TenNguyenLieu, DateTime HanSuDung, int SoNgayQuaHan, double GiaTri)> KiemTraNguyenLieuQuaHan()
        {
            var ketQua = new List<(string TenNguyenLieu, DateTime HanSuDung, int SoNgayQuaHan, double GiaTri)>();
            var ngayHienTai = DateTime.Now.Date;

            var nguyenLieuQuaHan = db.nguyenLieu
                .Where(nl => nl.hanSuDung.Date < ngayHienTai && nl.soLuong > 0)
                .ToList();

            foreach (var nl in nguyenLieuQuaHan)
            {
                int soNgayQuaHan = (ngayHienTai - nl.hanSuDung.Date).Days;
                // Tính giá trị thiệt hại
                double giaTri = nl.soLuong * nl.giaNhap;

                ketQua.Add((
                    nl.tenNguyenLieu,
                    nl.hanSuDung,
                    soNgayQuaHan,
                    giaTri
                ));
            }

            // Sắp xếp theo số ngày quá hạn (giảm dần)
            return ketQua.OrderByDescending(x => x.SoNgayQuaHan).ToList();
        }

        // Kiểm tra nguyên liệu sắp hết hạn
        public List<(string TenNguyenLieu, DateTime HanSuDung, int SoNgayConLai, double GiaTri)> KiemTraNguyenLieuSapHetHan(int soNgayCanh = 7)
        {
            var ketQua = new List<(string TenNguyenLieu, DateTime HanSuDung, int SoNgayConLai, double GiaTri)>();
            var ngayHienTai = DateTime.Now.Date;
            var ngayCanhBao = ngayHienTai.AddDays(soNgayCanh);

            var nguyenLieuSapHet = db.nguyenLieu
                .Where(nl => 
                    nl.hanSuDung.Date >= ngayHienTai && 
                    nl.hanSuDung.Date <= ngayCanhBao && 
                    nl.soLuong > 0)
                .ToList();

            foreach (var nl in nguyenLieuSapHet)
            {
                int soNgayConLai = (nl.hanSuDung.Date - ngayHienTai).Days;
                // Tính giá trị có thể bị ảnh hưởng
                double giaTri = nl.soLuong * nl.giaNhap;

                ketQua.Add((
                    nl.tenNguyenLieu,
                    nl.hanSuDung,
                    soNgayConLai,
                    giaTri
                ));
            }

            // Sắp xếp theo số ngày còn lại (tăng dần)
            return ketQua.OrderBy(x => x.SoNgayConLai).ToList();
        }
    }
}
