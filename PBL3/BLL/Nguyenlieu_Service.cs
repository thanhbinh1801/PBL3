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
                ChuanHoaDonVi(nguyenLieu);
                db.nguyenLieu.Add(nguyenLieu);  
                db.SaveChanges(); 
                return true;  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;  
            }
        }

        // READ
        public List<NguyenLieu> GetAllNguyenLieu()
        {
            return db.nguyenLieu.ToList();
        }

        // READ
        public NguyenLieu GetNguyenLieuById(int id)
        {
            return db.nguyenLieu.Find(id);
        }

        public List<NguyenLieu> GetNguyenLieuByName(string name)
        {
            return db.nguyenLieu
                    .Where(nl => nl.tenNguyenLieu.Contains(name))
                    .ToList(); 
        }

        // UPDATE
        public bool UpdateNguyenLieu(int id, NguyenLieu updatedNguyenLieu)
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

        // DELETE
        public bool DeleteNguyenLieu(int id)
        {
            var nguyenLieu = db.nguyenLieu.Find(id);
            if (nguyenLieu == null) return false;

            db.nguyenLieu.Remove(nguyenLieu);  
            db.SaveChanges();  
            return true;
        }

        // Kiểm tra đủ nguyên liệu cho món ăn
        public (bool DuNguyenLieu, string ThieuNguyenLieu) KiemTraDuNguyenLieu(int idMonAn, int soPhan)
        {
            var monAnNguyenLieus = db.MonAnNguyenLieux.Where(m => m.IDMonAn == idMonAn).ToList();
            StringBuilder thieu = new StringBuilder();

            foreach (var manl in monAnNguyenLieus)
            {
                var nguyenLieu = db.nguyenLieu.Find(manl.IDNguyenLieu);
                if (nguyenLieu == null) continue;

                // Chuẩn hóa đơn vị của MonAnNguyenLieu
                int soLuongCan = manl.soLuong;
                if (manl.donVi.ToUpper() == "KG")
                {
                    soLuongCan *= 1000;
                }

                if (nguyenLieu.soLuong < soLuongCan * soPhan)
                {
                    thieu.AppendLine($"- {nguyenLieu.tenNguyenLieu} (còn {nguyenLieu.soLuong}g, cần thêm {(soLuongCan * soPhan) - nguyenLieu.soLuong}g)");
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
                    var nguyenLieu = db.nguyenLieu.Find(manl.IDNguyenLieu);
                    if (nguyenLieu == null) continue;

                    // Chuẩn hóa đơn vị của MonAnNguyenLieu
                    int soLuongTru = manl.soLuong;
                    if (manl.donVi.ToUpper() == "KG")
                    {
                        soLuongTru *= 1000;
                    }

                    nguyenLieu.soLuong -= soLuongTru * soPhan;
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
    }
}
