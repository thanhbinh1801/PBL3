﻿use [PBL3.QLNHDB]

select * from Nguoidungs;
SET IDENTITY_INSERT NguoiDungs OFF;
INSERT INTO Nguoidungs(  tenTaiKhoan, tenNguoiDung, matKhau, email, phanQuyen)
VALUES
( 'nhanvien', 'Thanh Bình', '123456', 'nhanvien@gmail.com', 2),
( 'daubep', 'Thanh Tùng db', '123456', 'daubep@gmail.com', 1);


select * from BanAns;
SET IDENTITY_INSERT BanAns OFF;
INSERT INTO BanAns (IDBan, trangThaiBanAn)
VALUES 
(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0), (10, 0), (11, 0), (12, 0);

select * from DonHangs;
delete from DonHangs;
INSERT INTO DonHangs (IDDonHang, moTa, IDNguoiTao, IDNguoiNhan, thoiGianTao, trangThai)
VALUES 
(1, N'Khách gọi 2 món', 1, 2, '2025-05-02 10:00:00', 1),
(2, N'Khách gọi món đặc biệt', 3, 2, '2025-05-02 10:30:00', 0),
(3, N'Hủy đơn do hết món', 3, 2, '2025-05-02 11:00:00', 2);


select * from DonHangChiTiets;
INSERT INTO DonHangChiTiets (IDDonHangChiTiet, IDDonHang, IDMonAn, soLuong)
VALUES 
(1, 1, 1, 1),
(2, 1, 2, 2),
(3, 2, 3, 1),
(4, 2, 4, 1),
(5, 3, 6, 1);


select * from KhoNguyenLieux;
SET IDENTITY_INSERT KhoNguyenLieux OFF;
INSERT INTO KhoNguyenLieux (IDKho, tenKho)
VALUES 
(1, N'Kho chính'),
(2, N'Kho đông lạnh');

delete from KhoNguyenLieux;


select * from MonAnNguyenLieux;

select * from MonAns;
set identity_insert MonAns OFF;
INSERT INTO MonAns (IDMonAn, tenMonAn, giaBan, trangThai)
VALUES 
(1, N'Gà luộc', 150000, 0),
(2, N'Canh cải', 40000, 1),
(3, N'Cá hồi áp chảo', 200000, 0),
(4, N'Tôm chiên xù', 180000, 0),
(5, N'Bò xào hành cần', 160000, 0),
(6, N'Miến gà', 60000, 1);


select * from NguyenLieux;
set identity_insert NguyenLieux OFF;
INSERT INTO NguyenLieux (IDNguyenLieu, tenNguyenLieu, donViTinh, soLuong, giaNhap, hanSuDung, IDKho)
VALUES 
(1, N'Thịt gà', 'kg', 50, 75000, '2025-05-12', 1),
(2, N'Rau cải', 'kg', 30, 30000, '2025-05-07', 1),
(3, N'Cá hồi', 'kg', 20, 150000, '2025-05-15', 2),
(4, N'Tôm sú', 'kg', 15, 180000, '2025-05-13', 2),
(5, N'Thịt bò', 'kg', 40, 120000, '2025-05-14', 1),
(6, N'Miến dong', 'kg', 25, 20000, '2025-05-20', 1);
