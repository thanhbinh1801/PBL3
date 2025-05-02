using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class DonHang
    {
        [Key]
        [Required]
        public int IDDonHang { get; set; }
        public string moTa { get; set; }
        public int IDNguoiTao { get; set; }
        public virtual Nguoidung nguoiTao { get; set; }
        public int IDNguoiNhan { get; set; }
        public virtual Nguoidung nguoiNhan { get; set; }
        public DateTime thoiGianTao { get; set; }
        public TrangThaiDonHang trangThai { get; set; }
        public virtual ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
    }
}
