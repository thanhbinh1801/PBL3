using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class  NguyenLieu
    {
        [Key]
        [Required]
        public int IDNguyenLieu { get; set; }
        public string tenNguyenLieu { get; set; }
        public string donViTinh { get; set; }
        public int soLuong { get; set; }
        public double giaNhap { get; set; }
        public DateTime ngaynhap { get; set; }  
        public DateTime hanSuDung { get; set; }
        public int IDKho { get; set; }
        public virtual KhoNguyenLieu khoNguyenLieu { get; set; }
        public virtual ICollection<MonAnNguyenLieu> MonAnNguyenLieus { get; set; }
    }
}
