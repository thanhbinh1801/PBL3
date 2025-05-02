using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class DonHangChiTiet
    {
        [Key]
        public int IDDonHangChiTiet { get; set; }
        public int IDDonHang { get; set; }
        public DonHang donHang { get; set; }
        public int IDMonAn { get; set; }
        public MonAn monAn { get; set; }
        public int soLuong { get; set; }
    }
}
