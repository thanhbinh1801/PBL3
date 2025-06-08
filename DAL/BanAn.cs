using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public  class BanAn
    {
        [Key]
        public int IDBan { get; set; }  
        public TrangThaiBanAn trangThaiBanAn { get; set; }
    }
}
