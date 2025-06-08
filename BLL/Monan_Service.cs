using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.BLL
{
    public class MonAn_Service
    {
        private QLNHDB db = new QLNHDB(); 

        // CREATE
        public bool AddMonAn(MonAn monAn)
        {
            if (db.MonAns.Any(m => m.tenMonAn == monAn.tenMonAn))
                return false;

            db.MonAns.Add(monAn);  
            db.SaveChanges(); 
            return true;
        }
        public bool AddMonAnNguyenLieu(MonAnNguyenLieu monAnNguyenLieu)
        {
            try
            {
                db.MonAnNguyenLieux.Add(monAnNguyenLieu);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Inner Exception: " + ex.InnerException.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        public List<MonAnNguyenLieu> GetMonAnNguyenLieuByMonAnId(int idMonAn)
        {
            try
            {
                var result = db.MonAnNguyenLieux
                                .Where(mnl => mnl.IDMonAn == idMonAn)
                                .ToList(); 
                return result; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy nguyên liệu: " + ex.Message);
                return new List<MonAnNguyenLieu>(); 
            }
        }
        public MonAnNguyenLieu GetMonAnNguyenLieuByNameMonAnandNL(string tenMonAn, string tenNguyenLieu)
        {
            try
            {
                var monAn = db.MonAns.FirstOrDefault(m => m.tenMonAn == tenMonAn);
                if (monAn != null)
                {
                    var monAnNguyenLieu = db.MonAnNguyenLieux
                                            .Where(mnl => mnl.IDMonAn == monAn.IDMonAn && mnl.tenNguyenLieu == tenNguyenLieu)
                                            .SingleOrDefault(); 
                    if (monAnNguyenLieu != null)
                    {
                        return monAnNguyenLieu; 
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy nguyên liệu cho món ăn này.");
                    }
                }
                else
                {
                    throw new Exception("Món ăn không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy nguyên liệu của món ăn: " + ex.Message);
                throw; 
            }
        }




        // READ
        public List<MonAn> GetAllMonAn()
        {
            return db.MonAns.ToList(); 
        }

        public MonAn GetMonAnById(int id)
        {
            return db.MonAns.Find(id); 
        }

        public List<MonAn> GetMonAnByName(string name)
        {
            return db.MonAns.Where(m => m.tenMonAn.Contains(name)).ToList();  
        }

        // UPDATE
        public bool UpdateMonAn(int id, MonAn updatedMonAn)
        {
            try
            {
                var existingMonAn = db.MonAns.Find(id);
                if (existingMonAn == null) return false;

                // Cập nhật thông tin món ăn
                existingMonAn.tenMonAn = updatedMonAn.tenMonAn; 
                existingMonAn.giaBan = updatedMonAn.giaBan; 
                existingMonAn.trangThai = updatedMonAn.trangThai;  

                // Xóa tất cả các nguyên liệu cũ của món ăn
                var oldIngredients = db.MonAnNguyenLieux.Where(m => m.IDMonAn == id);
                db.MonAnNguyenLieux.RemoveRange(oldIngredients);

                db.SaveChanges();  
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật món ăn: " + ex.Message);
                return false;
            }
        }
        public bool UpdateMonAnNguyenLieu(MonAnNguyenLieu monAnNguyenLieu)
        {
            try
            {
                // Tìm nguyên liệu cần cập nhật trong bảng MonAnNguyenLieu
                var existingRecord = db.MonAnNguyenLieux
                                        .FirstOrDefault(mnl => mnl.IDMonAn == monAnNguyenLieu.IDMonAn && 
                                                             mnl.tenNguyenLieu == monAnNguyenLieu.tenNguyenLieu);

                if (existingRecord != null)
                {
                    existingRecord.soLuong = monAnNguyenLieu.soLuong;
                    existingRecord.donVi = monAnNguyenLieu.donVi;

                    db.SaveChanges();
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật nguyên liệu: " + ex.Message);
                return false; 
            }
        }

        // DELETE
        public bool DeleteMonAn(int id)
        {
            var monAn = db.MonAns.Find(id);  
            if (monAn == null) return false;

            db.MonAns.Remove(monAn);  
            db.SaveChanges();
            return true;
        }
    }
}
