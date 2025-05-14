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
        public int ID { get; set; }

        public int IDMonAn { get; set; }
        public int IDNguyenLieu { get; set; }
        public int soLuong { get; set; }
        public string donVi { get; set; }
    }

}
