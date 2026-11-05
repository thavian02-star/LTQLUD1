# PHÂN HỆ MÀN HÌNH CHÍNH (MAIN DASHBOARD FEATURE)

Thư mục tài liệu chi tiết và Mockup theo từng phiên bản cho phân hệ Màn hình chính (`Features/Main/`):

## 1. Phiên bản `v1.1` (Sửa lỗi Z-Order đè chữ & Tối ưu bố cục Responsive 60% : 40% — Thư mục [`v1_1/`](v1_1/))
- **[`v1_1/MAIN_UI_FIX_V1_1_SPRINT.md`](v1_1/MAIN_UI_FIX_V1_1_SPRINT.md):** Phân tích nguyên nhân gốc rễ từ ảnh chụp của PO (`BUG-MAIN-01` & `BUG-MAIN-02`), đặc tả kỹ thuật sửa Z-Order trong `pnlActivity`, chuyển `pnlDashboardRow` sang `TableLayoutPanel` (60% : 40%) và kế hoạch Sprint 5 bước.
- **[`v1_1/frmMain_mockup_v1_1.html`](v1_1/frmMain_mockup_v1_1.html):** Bản HTML Mockup tương tác `v1.1` có thanh công cụ cho phép PO chuyển đổi trực tiếp giữa **🟢 Bản sửa lỗi (`v1.1 Fix`)**, **🔴 Tái hiện lỗi hiện tại (`v1.0 Bug`)** và **🔀 So sánh song song (Before vs After)**.

## 2. Phiên bản gốc `v1.0` (Khởi tạo App Shell & RBAC 4 Vai trò)
- **[`MAIN_DASHBOARD.md`](MAIN_DASHBOARD.md):** Kế hoạch Sprint 5 bước khởi tạo `frmMain`, cấu trúc component, ma trận `Tag` phân quyền và kịch bản nghiệm thu đa vai trò.
- **[`MAIN_UI_VA_PHAN_QUYEN.md`](MAIN_UI_VA_PHAN_QUYEN.md):** Tài liệu đặc tả chi tiết bố cục giao diện, bảng thông số Control và cơ chế nhúng Form con (`MoFormCon`).
- **[`frmMain_mockup.html`](frmMain_mockup.html):** Bản HTML Mockup gốc `v1.0` của màn hình `frmMain`.
