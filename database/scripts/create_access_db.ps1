$ErrorActionPreference = "Stop"
$dbPath = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot "..\QuanLyQuanAn.mdb"))
if (Test-Path $dbPath) { Remove-Item $dbPath -Force }

# 1. Khoi tao Access (.mdb)
$adox = New-Object -ComObject ADOX.Catalog
$connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=$dbPath;"
$adox.Create($connStr)

# 2. Mo ket noi ADODB
$conn = New-Object -ComObject ADODB.Connection
$conn.Open($connStr)

# Bang TrinhDoViTinh
$conn.Execute("CREATE TABLE TrinhDoViTinh (MaTD AUTOINCREMENT PRIMARY KEY, TenTrinhDo TEXT(50) NOT NULL, DaXoa YESNO DEFAULT FALSE);")

# Bang DungCuTrangPhuc
$conn.Execute("CREATE TABLE DungCuTrangPhuc (MaDC AUTOINCREMENT PRIMARY KEY, TenDungCu TEXT(100) NOT NULL, SoLuongTong INT DEFAULT 0, GhiChu TEXT(255), DaXoa YESNO DEFAULT FALSE);")

# Bang NhanVien
$conn.Execute("CREATE TABLE NhanVien (MaNV AUTOINCREMENT PRIMARY KEY, HoTen TEXT(100) NOT NULL, GioiTinh TEXT(10), NgaySinh DATETIME, ViTri TEXT(50) NOT NULL, DienThoai TEXT(20), DiaChi TEXT(255), CMND TEXT(20), NgayBatDauLam DATETIME, TenDangNhap TEXT(50), MatKhau TEXT(100), TrangThai TEXT(30) DEFAULT 'Dang lam viec', DaXoa YESNO DEFAULT FALSE);")

# Bang NhanVien_ViTinh
$conn.Execute("CREATE TABLE NhanVien_ViTinh (ID AUTOINCREMENT PRIMARY KEY, MaNV INT, MaTD INT);")

# Bang NhanVien_DungCu
$conn.Execute("CREATE TABLE NhanVien_DungCu (MaPhieu AUTOINCREMENT PRIMARY KEY, MaNV INT, MaDC INT, SoLuong INT DEFAULT 1, NgayNhan DATETIME, DaTra YESNO DEFAULT FALSE, NgayTra DATETIME, GhiChu TEXT(255));")

# Bang CaLamViec
$conn.Execute("CREATE TABLE CaLamViec (MaCa AUTOINCREMENT PRIMARY KEY, TenCa TEXT(50) NOT NULL, GioBatDau TEXT(10), GioKetThuc TEXT(10), LuongMoiCa DOUBLE DEFAULT 0, DaXoa YESNO DEFAULT FALSE);")

# Data TrinhDoViTinh
$conn.Execute("INSERT INTO TrinhDoViTinh (TenTrinhDo) VALUES ('Word');")
$conn.Execute("INSERT INTO TrinhDoViTinh (TenTrinhDo) VALUES ('Excel');")
$conn.Execute("INSERT INTO TrinhDoViTinh (TenTrinhDo) VALUES ('Cai phan mem');")
$conn.Execute("INSERT INTO TrinhDoViTinh (TenTrinhDo) VALUES ('Khac');")

# Data DungCuTrangPhuc
$conn.Execute("INSERT INTO DungCuTrangPhuc (TenDungCu, SoLuongTong, GhiChu) VALUES ('Ao dong phuc quan', 50, 'Size M, L, XL');")
$conn.Execute("INSERT INTO DungCuTrangPhuc (TenDungCu, SoLuongTong, GhiChu) VALUES ('Tap de phuc vu', 30, 'Mau den');")
$conn.Execute("INSERT INTO DungCuTrangPhuc (TenDungCu, SoLuongTong, GhiChu) VALUES ('The nhan vien', 50, 'The tu cham cong');")

# Data CaLamViec
$conn.Execute("INSERT INTO CaLamViec (TenCa, GioBatDau, GioKetThuc, LuongMoiCa) VALUES ('Ca sang', '08:00', '13:00', 150000);")
$conn.Execute("INSERT INTO CaLamViec (TenCa, GioBatDau, GioKetThuc, LuongMoiCa) VALUES ('Ca chieu', '12:00', '17:00', 150000);")
$conn.Execute("INSERT INTO CaLamViec (TenCa, GioBatDau, GioKetThuc, LuongMoiCa) VALUES ('Ca toi', '17:00', '22:00', 170000);")

# Data NhanVien
$conn.Execute("INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, ViTri, DienThoai, DiaChi, CMND, NgayBatDauLam, TenDangNhap, MatKhau, TrangThai) VALUES ('Nguyen Van Chu', 'Nam', #1985-05-15#, 'Chu quan', '0901234567', 'TP. Ho Chi Minh', '079085001234', #2024-01-01#, 'chuquan', '123456', 'Dang lam viec');")
$conn.Execute("INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, ViTri, DienThoai, DiaChi, CMND, NgayBatDauLam, TenDangNhap, MatKhau, TrangThai) VALUES ('Tran Thi Quan Ly', 'Nu', #1992-08-20#, 'Nhan vien quan ly', '0912345678', 'TP. Ho Chi Minh', '079192005678', #2024-02-01#, 'quanly', '123456', 'Dang lam viec');")
$conn.Execute("INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, ViTri, DienThoai, DiaChi, CMND, NgayBatDauLam, TenDangNhap, MatKhau, TrangThai) VALUES ('Le Van Phuc Vu', 'Nam', #2002-11-10#, 'Nhan vien phuc vu', '0987654321', 'TP. Ho Chi Minh', '079202009876', #2024-06-15#, 'phucvu', '123456', 'Dang lam viec');")
$conn.Execute("INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, ViTri, DienThoai, DiaChi, CMND, NgayBatDauLam, TenDangNhap, MatKhau, TrangThai) VALUES ('Pham Van Bep', 'Nam', #1995-03-25#, 'Nhan vien pha che', '0933445566', 'TP. Ho Chi Minh', '079195004321', #2024-03-01#, 'nhabep', '123456', 'Dang lam viec');")

# Data NhanVien_ViTinh
$conn.Execute("INSERT INTO NhanVien_ViTinh (MaNV, MaTD) VALUES (1, 1);")
$conn.Execute("INSERT INTO NhanVien_ViTinh (MaNV, MaTD) VALUES (1, 2);")
$conn.Execute("INSERT INTO NhanVien_ViTinh (MaNV, MaTD) VALUES (2, 1);")
$conn.Execute("INSERT INTO NhanVien_ViTinh (MaNV, MaTD) VALUES (2, 2);")
$conn.Execute("INSERT INTO NhanVien_ViTinh (MaNV, MaTD) VALUES (3, 4);")

# Data NhanVien_DungCu
$conn.Execute("INSERT INTO NhanVien_DungCu (MaNV, MaDC, SoLuong, NgayNhan, DaTra) VALUES (3, 1, 2, #2024-06-15#, FALSE);")
$conn.Execute("INSERT INTO NhanVien_DungCu (MaNV, MaDC, SoLuong, NgayNhan, DaTra) VALUES (3, 2, 1, #2024-06-15#, FALSE);")
$conn.Execute("INSERT INTO NhanVien_DungCu (MaNV, MaDC, SoLuong, NgayNhan, DaTra) VALUES (3, 3, 1, #2024-06-15#, FALSE);")

$conn.Close()
Write-Output "SUCCESS: QuanLyQuanAn.mdb created successfully!"