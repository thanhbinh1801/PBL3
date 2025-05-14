using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    public class Nguoidung_Service
    {
        private QLNHDB db = new QLNHDB();

        // CREATE
        public bool AddUser(Nguoidung user)
        {
            if (db.nguoidungs.Any(u => u.tenTaiKhoan == user.tenTaiKhoan))
                return false;

            user.matKhau = HashPassword.HashPW(user.matKhau);
            db.nguoidungs.Add(user);
            db.SaveChanges();
            return true;
        }

        // READ
        public List<Nguoidung> GetAllUsers()
        {
            return db.nguoidungs.ToList();
        }

        public Nguoidung GetUserById(int id)
        {
            return db.nguoidungs.Find(id);
        }

        public Nguoidung GetUserByUsername(string username)
        {
            return db.nguoidungs.FirstOrDefault(u => u.tenTaiKhoan == username);
        }

        // UPDATE mật khẩu
        public bool UpdatePassword(int id, string newPassword)
        {
            var user = db.nguoidungs.Find(id);
            if (user == null) return false;

            user.matKhau = HashPassword.HashPW(newPassword);
            db.SaveChanges();
            return true;
        }

        // DELETE
        public bool DeleteUser(int id)
        {
            var user = db.nguoidungs.Find(id);
            if (user == null) return false;

            db.nguoidungs.Remove(user);
            db.SaveChanges();
            return true;
        }

        // LOGIN
        public Nguoidung Login(string username, string password)
        {
            var user = db.nguoidungs.FirstOrDefault(u => u.tenTaiKhoan == username);
            if (user != null && HashPassword.VerifyPW(password, user.matKhau))
            {
                return user;
            }
            return null;
        }
    }
}
