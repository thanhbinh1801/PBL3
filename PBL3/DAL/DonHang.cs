using PBL3.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

public class DonHang
{
    [Key]
    [Required]
    public int IDDonHang { get; set; }
    public string moTa { get; set; }
    public int IDBan { get; set; }
    public virtual BanAn banAn { get; set; }

    public int IDNguoiTao { get; set; }
    [ForeignKey("IDNguoiTao")]
    public virtual Nguoidung nguoiTao { get; set; } 

    public int IDNguoiNhan { get; set; }
    [ForeignKey("IDNguoiNhan")]
    public virtual Nguoidung nguoiNhan { get; set; } 

    public DateTime thoiGianTao { get; set; }
    public TrangThaiDonHang trangThai { get; set; }
    public virtual ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
}