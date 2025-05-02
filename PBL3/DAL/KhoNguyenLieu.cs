using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class KhoNguyenLieu
    {
        [Key]
        public int IDKho { get; set; }
        public string tenKho { get; set; }
        public virtual ICollection<NguyenLieu> NguyenLieus { get; set; }    
    }
}
