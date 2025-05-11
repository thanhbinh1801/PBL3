using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class MonAnNguyenLieu
    {
        [Key]
        public int IDMonAn { get; set; }
        public MonAn monAn { get; set; }
        public int IDNguyenLieu { get; set; }
        public NguyenLieu nguyenLieu { get; set; }
        public int soLuong { get; set; }
        public string donVi { get; set; }

    }
}
