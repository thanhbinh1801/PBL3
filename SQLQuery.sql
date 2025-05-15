use [PBL3.QLNHDB]

select * from Nguoidungs;
delete from Nguoidungs;
SET IDENTITY_INSERT NguoiDungs OFF;
INSERT INTO Nguoidungs( IDUser, tenTaiKhoan, tenNguoiDung, matKhau, email, phanQuyen)
VALUES
(103, 'quanli', 'Quản lí Kim', '123465', 'quanli@gmail.com', 0),
(101, 'nhanvien', 'Thanh Bình', '123456', 'nhanvien@gmail.com', 2),
(102, 'daubep', 'Thanh Tùng db', '123456', 'daubep@gmail.com', 1);


select * from BanAns;
SET IDENTITY_INSERT BanAns ON;
delete from BanAns;
INSERT INTO BanAns (IDBan, trangThaiBanAn)
VALUES 
(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0), (10, 0), (11, 0), (12, 0);

select * from DonHangs;
delete from DonHangs;


select * from DonHangChiTiets;
delete from DonHangChiTiets;
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


select * from MonAnNguyenLieux;
delete from MonAnNguyenLieux;
INSERT INTO MonAnNguyenLieux (IDMonAn, IDNguyenLieu, soLuong, donVi)
VALUES 
(1, 1, 1000, 'g'),
(1, 2, 200, 'g'),
	
(2, 2, 500, 'g'),
(2, 6, 100, 'g'),

(3, 3, 800, 'g'),
(3, 2, 200, 'g'),

(4, 4, 500, 'g'),
(4, 2, 200, 'g'),

(5, 5, 600, 'g'),
(5, 2, 300, 'g'),

(6, 1, 500, 'g'),
(6, 6, 300, 'g');



select * from MonAns;
delete from MonAns;
set identity_insert MonAns OFF;
INSERT INTO MonAns (IDMonAn, tenMonAn, giaBan, trangThai)
VALUES 
(1, N'Gà luộc', 150000, 0),
(2, N'Canh cải', 40000, 0),
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

