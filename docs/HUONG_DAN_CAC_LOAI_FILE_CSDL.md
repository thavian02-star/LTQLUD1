# Hướng Dẫn Chi Tiết Các Loại File Cơ Sở Dữ Liệu (MS SQL Server)

Tài liệu này tổng kết toàn bộ kiến thức về 4 loại file CSDL cốt lõi trong đồ án, vai trò của từng file, vị trí lưu trữ trong Docker, và cách xuất (export) bằng **DBeaver** hoặc **SSMS** để phục vụ việc nộp bài và chấm điểm.

---

## 1. Bảng Tổng Kết 4 Loại File CSDL Cốt Lõi

| STT | Loại File | Đuôi Mở Rộng | Vị Trí Lưu Trữ Hiện Tại | Vai Trò & Mục Đích Khi Nộp Bài |
|:---:|:---|:---:|:---|:---|
| **1** | **File Script SQL Gốc / Tái Hiện** | `.sql` | `database/docker-mssql/create-database.sql` | Chứa toàn bộ câu lệnh mã nguồn SQL (`CREATE TABLE`, `INSERT INTO`...). Dùng để chạy tái hiện lại cấu trúc và dữ liệu CSDL từ con số 0 trên bất kỳ máy nào. |
| **2** | **Cặp File Dữ Liệu Sống** | `.mdf` & `.ldf` | Bên trong Volume `mssql_data`<br>(`/var/opt/mssql/data/`) | **`.mdf`** lưu trữ dữ liệu thật của các bảng; **`.ldf`** lưu nhật ký giao dịch. Do SQL Server tự động tạo ra và đọc/ghi liên tục khi phần mềm hoạt động. Thầy cô có thể dùng tính năng **Attach Database** để nạp. |
| **3** | **File Sao Lưu (Backup)** | `.bak` | Xuất từ DBeaver / SSMS vào `/var/opt/mssql/data/` | Đóng gói nguyên khối toàn bộ CSDL (bảng, dữ liệu, phân quyền, thủ tục). Giảng viên thích file này nhất vì chỉ cần 1 click **Restore Database** là có ngay CSDL giống hệt 100% máy sinh viên. |
| **4** | **File Sơ Đồ Quan Hệ (ERD)** | `.png` / `.pdf` | Thư mục báo cáo đồ án | Hình ảnh trực quan thể hiện mối quan hệ giữa các bảng (khóa chính, khóa ngoại, quan hệ 1-N, N-N). Phục vụ chấm điểm thiết kế CSDL và chèn vào báo cáo. |

---

## 2. Chi Tiết Từng Loại File & Cách Thao Tác

### 1. File Script SQL (`.sql`)
- **Nội dung:** Văn bản thuần túy (plain text) chứa các câu lệnh T-SQL.
- **Cách xuất từ DBeaver:**
  - *Xuất cấu trúc bảng (DDL):* Chuột phải vào tên Database `QuanLyQuanAnDB` $\rightarrow$ **Generate SQL** $\rightarrow$ **DDL**.
  - *Xuất toàn bộ dữ liệu mẫu:* Chuột phải vào **Tables** $\rightarrow$ **Export Data** $\rightarrow$ Chọn định dạng **SQL** $\rightarrow$ Lưu file.
- **Cách xuất từ SSMS:**
  - Chuột phải vào Database $\rightarrow$ **Tasks** $\rightarrow$ **Generate Scripts...**
  - Ở bước chọn tùy chọn nâng cao (Advanced), tìm dòng **Types of data to script** $\rightarrow$ chọn **`Schema and data`**.

---

### 2. File Sao Lưu Backup (`.bak`)
- **Nội dung:** File nhị phân được nén và đóng gói chuẩn của Microsoft SQL Server.
- **Cách tạo bằng DBeaver (Dùng lệnh T-SQL):**
  Mở SQL Editor trong DBeaver và chạy lệnh sau:
  ```sql
  BACKUP DATABASE QuanLyQuanAnDB 
  TO DISK = '/var/opt/mssql/data/QuanLyQuanAnDB.bak'
  WITH FORMAT, INIT, NAME = 'QuanLyQuanAnDB-Full Backup';
  ```
- **Cách tạo bằng SSMS (Giao diện đồ họa):**
  - Chuột phải vào Database `QuanLyQuanAnDB` $\rightarrow$ **Tasks** $\rightarrow$ **Back Up...**
  - Chọn kiểu backup: **Full** $\rightarrow$ Chọn đường dẫn lưu file `.bak` $\rightarrow$ Bấm **OK**.

---

### 3. Cặp File Dữ Liệu Vật Lý (`.mdf` và `.ldf`)
- **Tên file mặc định:** `QuanLyQuanAnDB.mdf` và `QuanLyQuanAnDB_log.ldf`.
- **Đặc điểm:** Không cần phần mềm nào "export" vì SQL Server tự tạo khi chạy.
- **Cách lấy file ra khỏi Docker về máy Mac:**
  Chạy lệnh sau trên Terminal máy Mac:
  ```bash
  docker cp sqlserver-quanan:/var/opt/mssql/data/QuanLyQuanAnDB.mdf ./
  docker cp sqlserver-quanan:/var/opt/mssql/data/QuanLyQuanAnDB_log.ldf ./
  ```

---

### 4. File Sơ Đồ Quan Hệ (ER Diagram)
- **Cách xuất bằng DBeaver:**
  1. Trong DBeaver, click đúp vào Schema **`dbo`** (hoặc tên Database `QuanLyQuanAnDB`).
  2. Bấm sang tab **ER Diagram** ở khung bên phải (DBeaver tự động sắp xếp sơ đồ).
  3. Chuột phải vào nền sơ đồ $\rightarrow$ chọn **Save diagram as image...** $\rightarrow$ lưu thành file `.png`.

---

## 3. Bộ Hồ Sơ CSDL Tiêu Chuẩn Khi Nộp Bài Đồ Án

Khi nộp bài cho Giảng viên môn học, sinh viên nên nén thư mục CSDL với cấu trúc chuẩn sau:

```text
📁 database_submission/
   ├── QuanLyQuanAnDB.bak                  <-- Dùng cho thầy cô muốn Restore nhanh
   ├── QuanLyQuanAnDB_Full_Script.sql      <-- Script tạo bảng và dữ liệu đầy đủ
   ├── Database_Diagram.png                <-- Sơ đồ quan hệ thực thể (ERD)
   ├── HUONG_DAN_CAI_DAT.txt               <-- Thông tin kết nối & thứ tự chạy file
   └── (Tuy chon) QuanLyQuanAnDB.mdf/.ldf  <-- Dành cho trường hợp yêu cầu Attach DB
```

