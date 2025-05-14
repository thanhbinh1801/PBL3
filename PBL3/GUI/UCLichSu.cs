using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3
{
    public partial class UCLichSu : UserControl
    {
        private QLNHDB db = new QLNHDB();
        public UCLichSu()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            var donHangs = db.donHang.ToList();
            var displayData = donHangs.Select(d => new
            {
                IDDonHang = d.IDDonHang,
                moTa = d.moTa,
                nguoiTao = d.nguoiTao.tenNguoiDung,  
                nguoiNhan = d.nguoiNhan.tenNguoiDung, 
                thoiGianTao = d.thoiGianTao.ToString("dd/MM/yyyy HH:mm"), 
                trangThai = d.trangThai.ToString()
            }).ToList();
            dgvLichSu.DataSource = displayData;
            dgvLichSu.Columns["IDDonHang"].HeaderText = "Mã Đơn Hàng";
            dgvLichSu.Columns["moTa"].HeaderText = "Mô Tả";
            dgvLichSu.Columns["nguoiTao"].HeaderText = "Người Tạo";
            dgvLichSu.Columns["nguoiNhan"].HeaderText = "Người Nhận";
            dgvLichSu.Columns["thoiGianTao"].HeaderText = "Thời Gian Tạo";
            dgvLichSu.Columns["trangThai"].HeaderText = "Trạng Thái";
        }
    }
}
