CREATE DATABASE QL_BANHANG
GO
USE QL_BANHANG
GO

CREATE TABLE NHASANXUAT
(
	MANSX INT NOT NULL,
	TENNSX NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_NHASANXUAT PRIMARY KEY(MANSX)
)

CREATE TABLE LOAI
(
	MALOAI INT NOT NULL,
	TENLOAI NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_LOAI PRIMARY KEY(MALOAI)
)

CREATE TABLE SANPHAM
(
	MASP INT NOT NULL,
	TENSP NVARCHAR(50) NOT NULL,
	MALOAI INT NOT NULL,
	MANSX INT NOT NULL,
	GIA DECIMAL(18, 2) NOT NULL,
	GHICHU NVARCHAR(80) NOT NULL,
	HINH VARCHAR(200) NOT NULL,
	CONSTRAINT PK_SANPHAM PRIMARY KEY(MASP),
	CONSTRAINT FK_SANPHAM_NHASANXUAT FOREIGN KEY(MANSX) REFERENCES NHASANXUAT(MANSX),
	CONSTRAINT FK_SANPHAM_LOAI FOREIGN KEY(MALOAI) REFERENCES LOAI(MALOAI)
)

CREATE TABLE KHACHHANG
(
	MAKHACHHANG INT NOT NULL,
	TENKHACHHANG NVARCHAR(50) NOT NULL,
	SODIENTHOAI VARCHAR(11) NOT NULL,
	MATKHAU VARCHAR(50) NOT NULL,
	CONSTRAINT PK_KHACHHANG PRIMARY KEY(MAKHACHHANG)
)

CREATE TABLE HOADON
(
	MAHD INT NOT NULL,
	NGAYTAO DATE NOT NULL,
	MAKHACHHANG INT NOT NULL,
	CONSTRAINT PK_HOADON PRIMARY KEY(MAHD)
)

CREATE TABLE CHITIETHD
(
	MAHD INT NOT NULL,
	MASP INT NOT NULL,
	SOLUONG INT NOT NULL,
	CONSTRAINT PK_CHITIETHD PRIMARY KEY(MAHD, MASP),
	CONSTRAINT FK_CHITIETHD_HOADON FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD),
	CONSTRAINT FK_CHITIETHD_SANPHAM FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP)
)

INSERT INTO NHASANXUAT VALUES
	(1, N'NXB Trẻ'),
	(2, N'NXB Kim Đồng'),
	(3, N'NXB Giáo Dục'),
	(4, N'NXB Văn Học'),
	(5, N'NXB Lao Động')

INSERT INTO LOAI VALUES
	(1, N'Tiểu thuyết'),
	(2, N'Truyện tranh'),
	(3, N'Sách giáo khoa'),
	(4, N'Sách kỹ năng sống'),
	(5, N'Sách tham khảo')

INSERT INTO SANPHAM VALUES
    (1, N'Đắc Nhân Tâm', 4, 5, 85000, N'Sách kỹ năng sống nổi tiếng', 'https://images.unsplash.com/photo-1524995997946-a1c2e315a42f'),
    (2, N'Tôi Thấy Hoa Vàng Trên Cỏ Xanh', 1, 1, 99000, N'Tiểu thuyết của Nguyễn Nhật Ánh', 'https://giaibaisgk.com/wp-content/uploads/2020/06/toi-thay-hoa-vang-tren-co-xanh-4.jpg'),
    (3, N'One Piece Tập 105', 2, 2, 25000, N'Truyện tranh phiêu lưu nổi tiếng', 'https://www.simonandschuster.com/books/One-Piece-Vol-105/Eiichiro-Oda/One-Piece/9781974743278'),
    (4, N'Doraemon Tập 50', 2, 2, 20000, N'Truyện tranh dành cho thiếu nhi', 'https://animesweet.com/wp-content/uploads/2020/04/Doraemon-Volume-50.jpg'),
    (5, N'Toán 12 Cơ Bản', 3, 3, 45000, N'Sách giáo khoa cấp 3', 'https://kenhgiaovien.com/wp-content/uploads/2023/04/toan-12-tap-1.jpg'),
    (6, N'Ngữ Văn 11 Tập 2', 3, 3, 40000, N'Sách giáo khoa cấp 3', 'https://hieusach24h.com/wp-content/uploads/2021/04/ngu-van-11-tap-2.jpg'),
    (7, N'Harry Potter Và Hòn Đá Phù Thủy', 1, 4, 120000, N'Tiểu thuyết kỳ ảo', 'https://kr.pinterest.com/pin/harry-potter-mini-book-cover-in-2023--2392606045315643/'),
    (8, N'Trên Đường Băng', 4, 5, 75000, N'Sách kỹ năng và truyền cảm hứng', 'https://images.unsplash.com/photo-1588776814546-0b76ffae3995'),
    (9, N'Lược Sử Thời Gian', 5, 4, 130000, N'Sách khoa học nổi tiếng của Stephen Hawking', 'https://images.unsplash.com/photo-1551029506-080a7b1a2349'),
    (10, N'Nhà Giả Kim', 1, 4, 98000, N'Tác phẩm triết lý sống nổi tiếng', 'https://images.unsplash.com/photo-1516979187457-637abb4f9353');

INSERT INTO KHACHHANG VALUES
	(1, N'Nguyễn Văn An', '0912345678', 'an123'),
	(2, N'Trần Thị Bình', '0987654321', 'binh123'),
	(3, N'Lê Hoàng Nam', '0905123456', 'nam123'),
	(4, N'Phạm Thúy Hằng', '0978123123', 'hang123'),
	(5, N'Đỗ Minh Quân', '0933334444', 'quan123')

INSERT INTO HOADON VALUES
	(1, '2025-10-01', 1),
	(2, '2025-10-02', 2),
	(3, '2025-10-03', 3),
	(4, '2025-10-04', 4),
	(5, '2025-10-05', 5)

INSERT INTO CHITIETHD VALUES
	(1, 1, 1),
	(1, 10, 1),
	(2, 3, 2),
	(2, 4, 1),
	(3, 7, 1),
	(3, 2, 1),
	(4, 5, 1),
	(4, 6, 1),
	(5, 8, 1),
	(5, 9, 1)
