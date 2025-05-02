using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class Nguoidung
    {
        [Key]
        [Required]
        public int IDUser { get; set; }
        [Required]
        public string tenTaiKhoan { get; set; }
        [Required]
        public string tenNguoiDung { get; set; }
        [Required]
        public string matKhau { get; set; }
        [Required]
        public string email { get; set; }
        public PhanQuyen phanQuyen { get; set; }
        public virtual ICollection<DonHang> DonHangsTao { get; set; } 
        public virtual ICollection<DonHang> DonHangsNhan { get; set; }

    }
}
