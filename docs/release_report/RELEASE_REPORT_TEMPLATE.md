# 📋 Hướng Dẫn & Prompt Mẫu: Tạo HTML Release Report Trực Quan (Before/After)

> **Thư mục lưu trữ report:** `docs/release_report/`  
> **Quy ước đặt tên file:** `docs/release_report/report_<version>.html` (ví dụ: version `v0.2.0` $\rightarrow$ `report_0_2_0.html`)

---

## 1. MỤC ĐÍCH & Ý NGHĨA

Release Report là báo cáo phát hành phiên bản trực quan dưới dạng **file HTML độc lập (Self-contained)**. File này có thể mở trực tiếp trên bất kỳ trình duyệt nào mà không cần kết nối mạng hay cài đặt thêm thư viện, giúp:
- Giảng viên / Người chấm đồ án nắm bắt ngay lập tức những tính năng mới của phiên bản.
- So sánh trực quan trạng thái **TRƯỚC (Before)** và **SAU (After)** về cả Giao diện (UI Mockup), Luồng xử lý (Flow Diagram), Mã nguồn (Code Diff) và Cấu trúc CSDL (Data Model).
- Đảm bảo tính minh bạch, chuyên nghiệp và có thể đính kèm trực tiếp vào báo cáo nghiệm thu đồ án.

---

## 2. PROMPT CHUẨN ĐỂ YÊU CẦU TẠO REPORT

Mỗi khi hoàn thành một Sprint hoặc phát hành một phiên bản mới, bạn chỉ cần copy prompt dưới đây gửi cho Agent:

````markdown
Tôi cần bạn phân tích git history và tạo một file HTML Release Report trực quan
so sánh TRƯỚC/SAU (Before/After) cho lần release này của dự án Quản Lý Quán Ăn.

─── THÔNG TIN RELEASE ────────────────────────────────────────────
- Tên dự án    : Hệ Thống Quản Lý Quán Ăn (Quanlyquanan)
- Công nghệ    : VB.NET Windows Forms (.NET 10.0) + Microsoft SQL Server 2022 (Docker)
- Release trước: [Commit hash hoặc version cũ, ví dụ: c8e831b hoặc v0.1.0]
- Release hiện : [HEAD trên branch main | v0.2.0]
- Thời gian    : [dd/mm/yyyy]

─── BƯỚC 1 — Thu thập dữ liệu Git ────────────────────────────────
Chạy tuần tự trong PowerShell:
  git log <base>..<head> --format="%ci|%s"          ← danh sách commits
  git diff <base>..<head> --stat                     ← thống kê file
  git diff <base>..<head> --name-only                ← danh sách file
  git diff <base>..<head> -- <file>                  ← diff chi tiết các file quan trọng

─── BƯỚC 2 — Phân loại thay đổi ──────────────────────────────────
Phân loại mỗi thay đổi vào một trong các nhóm:
  ✨ FEATURE   — Tính năng mới (Auth, Main Dashboard, Bàn ăn, Bếp...)
  🐛 FIX       — Sửa lỗi kết nối, null safety, logic phân quyền...
  🎨 UX/UI     — Cải thiện giao diện WinForms, mockup, bố cục co giãn...
  🔧 REFACTOR  — Tái cấu trúc (Package-by-Feature, tối ưu Session, Helper...)
  📦 BUILD     — Cấu hình .vbproj, Docker compose, seed-data...
  🗄️ MODEL/DB  — Schema bảng SQL Server, DTO, DAO...

─── BƯỚC 3 — Xác định Before/After ───────────────────────────────
Với mỗi thay đổi quan trọng, xác định rõ:
  a) TRƯỚC: trạng thái cũ / chưa có màn hình / lỗi cũ là gì
  b) SAU: tính năng mới / giao diện mới / cơ chế xử lý mới là gì
  c) File và commit liên quan
  d) Điều kiện phân quyền hoặc logic áp dụng (RBAC, Session)
  e) Impact: ảnh hưởng đến phân hệ nào

─── BƯỚC 4 — Tạo file HTML Self-Contained ─────────────────────────
Cấu trúc file HTML (inline CSS, không dùng CDN, không dùng JS ngoài):
  [1] HEADER: Tên project, version cũ → mới, thời gian, số liệu tổng quan (commits, files, +lines/-lines)
  [2] STATS BAR: Đếm số lượng theo badge (Feature | Fix | UX | Refactor | Build)
  [3] TABLE OF CONTENTS: Thanh pill links anchor đến từng card thay đổi
  [4] CHANGE CARDS: Một card cho mỗi thay đổi lớn, có so sánh Before/After:
      • Desktop Window Mockup (CSS thuần) cho thay đổi giao diện WinForms
      • Code Diff Block (+line xanh, -line đỏ) cho thay đổi logic nghiệp vụ
      • Sequence / Flow Box cho luồng dữ liệu
      • Bảng so sánh cho cấu trúc DTO / Database
  [5] FILE SUMMARY TABLE: Danh sách file, phân hệ, loại thay đổi, số dòng thêm/bớt
  [6] FOOTER: Thông tin dự án, ngày tạo, base → head commit hash

⚠️ ĐỊNH DẠNG FILE ĐẦU RA:
Lưu file tại: docs/release_report/report_<version>.html
Ví dụ: docs/release_report/report_0_2_0.html (dùng dấu _ thay vì . và +)
````

---

## 3. QUY CHUẨN THIẾT KẾ & BẢNG MÀU GIAO DIỆN REPORT

- **Font chữ:** `'Segoe UI', -apple-system, BlinkMacSystemFont, sans-serif` (cho văn bản) và `'JetBrains Mono', 'Consolas', monospace` (cho code diff).
- **Header Gradient:** Xanh dương đậm sang trọng `#0F172A` $\rightarrow$ `#1E3A8A` $\rightarrow$ `#1D4ED8`.
- **Thẻ Card:** Bo góc `16px`, viền `#E2E8F0`, đổ bóng mềm mại, hiệu ứng hover nổi nhẹ.
- **Khung cửa sổ Windows Desktop (CSS thuần):** Giả lập thanh Title bar 3 nút tròn (`#F1C40F`, `#2ECC71`, `#E74C3C`), thanh Header màu xanh `#2980B9` và thân cửa sổ đúng tỉ lệ.
- **Code Diff Block:** Header xám đậm `#1E293B`, dòng thêm `+` nền xanh `#F0FDF4` viền `#BBF7D0`, dòng bớt `-` nền đỏ `#FEF2F2` viền `#FECDD3`.
- **Màu sắc Semantic:**
  - 🔵 Blue (Feature): `#0066FF` / Nền `#EBF2FF`
  - 🟢 Green (UX / Thành công): `#16A34A` / Nền `#DCFCE7`
  - 🔴 Red (Fix / Cảnh báo): `#DC2626` / Nền `#FEE2E2`
  - 🟠 Orange (Model / DB): `#EA580C` / Nền `#FFF7ED`
  - 🟣 Purple (Refactor): `#7C3AED` / Nền `#EDE9FE`
  - ⚫ Slate (Nền & Text): `#0F172A`, `#334155`, `#64748B`, `#F8FAFC`

---

## 4. CẤU TRÚC THƯ MỤC LƯU TRỮ

```
docs/
└── release_report/
    ├── RELEASE_REPORT_TEMPLATE.md      ← Tài liệu mẫu & Prompt hướng dẫn (file này)
    ├── report_0_2_0.html               ← Báo cáo phát hành phiên bản v0.2.0 (Auth & Main Dashboard)
    ├── report_0_2_1.html               ← Báo cáo phát hành phiên bản v0.2.1 (Đổi Mật Khẩu & Kiểm thử Đa Vai trò)
    ├── report_0_2_2.html               ← Báo cáo phát hành phiên bản v0.2.2 (Sửa lỗi Z-Order & Tối ưu Responsive 60:40 trên frmMain v1.1)
    ├── report_0_2_3.html               ← Báo cáo phát hành phiên bản v0.2.3 (Màn hình 1/5: Quản lý Danh mục Thực đơn - frmDanhMuc v1.0)
    ├── report_0_2_4.html               ← Báo cáo phát hành phiên bản v0.2.4 (Màn hình 2/5: Quản lý Món ăn & Thức uống - frmMonAn v1.0)
    ├── report_0_2_5.html               ← Báo cáo phát hành phiên bản v0.2.5 (Màn hình 3/5: Quản lý Danh sách Ca làm việc - frmCaLamViec v1.0)
    ├── report_0_3_0.html               ← (Dự kiến: Sơ đồ bàn & Gọi món)
    └── ...
```
