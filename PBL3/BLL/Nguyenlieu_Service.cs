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

        // CREATE
        public bool AddNguyenLieu(NguyenLieu nguyenLieu)
        {
            try
            {
                db.nguyenLieu .Add(nguyenLieu);  
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
            var existingNguyenLieu = db.nguyenLieu .Find(id);
            if (existingNguyenLieu == null) return false;

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
    }
}
