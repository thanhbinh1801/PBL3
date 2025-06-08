using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class MonAn
    {
        [Key]
        [Required]
        public int IDMonAn { get; set; } 
        public string tenMonAn { get; set; }
        public double giaBan { get; set; }
        public TrangThaiMonAn trangThai { get; set; }
        public virtual ICollection<MonAnNguyenLieu> MonAnNguyenLieus { get; set; }
        public virtual ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
    }
}
