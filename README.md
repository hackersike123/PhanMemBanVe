# 🎫 PHẦN MỀM BÁN VÉ (Ticket Management System)

## 📋 TỔNG QUAN DỰ ÁN

Hệ thống quản lý bán vé với các chức năng:
- ✅ Đăng ký / Đăng nhập người dùng
- ✅ Quản lý khách hàng
- ✅ Quản lý bán vé (VIP/Standard)
- ✅ Báo cáo doanh thu chi tiết
- ✅ Xuất báo cáo PDF/Excel/Word

---

## 🏗️ CẤU TRÚC DỰ ÁN

```
PhanMemBanVe/
├── PhanMemBanVe.DAL/        # Data Access Layer
│   ├── Data/                # DbContext
│   ├── Entities/            # User, Area
│   ├── Models/              # Customer, TicketSale, DTOs
│   └── Migrations/          # EF Migrations
├── PhanMemBanVe.BUS/        # Business Logic Layer
│   └── Utils/               # Helpers, Seed Data
└── PhanMemBanVe.GUI/        # Presentation Layer
    ├── Forms/               # Windows Forms
    ├── Reports/             # RDLC Report Files
    └── Utils/               # UI Helpers
```

---

## 🚀 BẮT ĐẦU NHANH

### Bước 1: Cài đặt Requirements
- Visual Studio 2019/2022
- .NET Framework 4.7.2
- SQL Server LocalDB (đã có sẵn với VS)

### Bước 2: Clone Repository
```bash
git clone https://github.com/hackersike123/PhanMemBanVe
cd PhanMemBanVe
```

### Bước 3: Cài đặt NuGet Packages
```powershell
# Mở Package Manager Console trong Visual Studio
Install-Package EntityFramework -Version 6.4.4
Install-Package Microsoft.ReportingServices.ReportViewerControl.Winforms -Version 150.1484.0 -ProjectName PhanMemBanVe.GUI
```

### Bước 4: Build & Run
```
1. Build → Rebuild Solution
2. Debug → Start Debugging (F5)
3. Database tự động tạo và seed dữ liệu mẫu
```

---

## 📊 CHỨC NĂNG CHI TIẾT

### 1. Quản lý người dùng
- **Đăng ký**: Tạo tài khoản mới với mã hóa password
- **Đăng nhập**: Xác thực và phân quyền
- **Roles**: Admin, User

### 2. Quản lý khách hàng
- Thêm/Sửa/Xóa thông tin khách hàng
- Mã khách hàng, Họ tên, SĐT
- Tìm kiếm nhanh

### 3. Quản lý bán vé
- Bán vé theo khu vực (VIP/Standard)
- Chọn ghế ngồi
- Giá vé: VIP 150,000đ, Standard 75,000đ
- Hoàn vé (Refund)

### 4. Báo cáo doanh thu ⭐
- Lọc theo khoảng ngày
- Lọc theo khu vực
- Hiển thị chi tiết vé bán
- Tổng doanh thu tự động
- Xuất PDF/Excel/Word

---

## 🗄️ DATABASE

### Connection String
```xml
Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=TicketManagementDb;
Integrated Security=True;
MultipleActiveResultSets=True
```

### Tables
- **Users**: Id, UserName, Password (hashed), Role
- **Customers**: CustomerId, CustomerCode, FullName, Phone, CreatedAt
- **TicketSales**: TicketId, TicketCode, CustomerId, SaleDate, SeatNumber, AreaName, Price, IsRefunded

### Seed Data (Tự động)
- 1 Admin user (username: `admin`, password: `admin`)
- 5 Khách hàng mẫu (C001-C005)
- 50 Vé bán trong 30 ngày gần đây

---

## 🔧 TROUBLESHOOTING

### ❌ Lỗi: "context.Users" is null
**Đã fix:** Thêm `virtual` keyword vào DbSet properties

### ❌ Lỗi: "Unable to update database" (AutomaticMigrationsDisabledException)
**Đã fix:** Enable automatic migrations

### ❌ Lỗi: "The definition of the report is invalid" (RDLC 2008)
**Giải pháp:** Xem file `FIX_ALL_SOLUTIONS.md` ⭐

---

## 📚 HƯỚNG DẪN CHI TIẾT

| File | Mô tả |
|------|-------|
| **`QUICK_START.md`** ⭐ | Cài đặt nhanh 3 bước |
| **`README_BAO_CAO.md`** | Hướng dẫn đầy đủ về báo cáo |
| **`FIX_ALL_SOLUTIONS.md`** | Fix lỗi RDLC (4 giải pháp) |
| **`POST_BUILD_EVENT.md`** | Tự động copy RDLC file |
| **`MANUAL_FIX_RDLC.md`** | Fix RDLC thủ công |
| **`FIX_RDLC_COMPLETE.md`** | Chi tiết về file RDLC mới |

---

## 🛠️ CÔNG NGHỆ SỬ DỤNG

- **Framework**: .NET Framework 4.7.2
- **UI**: Windows Forms
- **ORM**: Entity Framework 6.4.4
- **Database**: SQL Server LocalDB
- **Reporting**: Microsoft ReportViewer 15.0
- **Security**: SHA-256 Password Hashing

---

## 📦 NUGET PACKAGES

```xml
<package id="EntityFramework" version="6.4.4" />
<package id="Microsoft.ReportingServices.ReportViewerControl.Winforms" version="150.1484.0" />
```

---

## 🎨 SCREENSHOTS

### Màn hình chính
- Menu: Login, Quản lý vé, Khách hàng, Báo cáo

### Form đăng ký
- Username, Password, Confirm Password
- Validation và check duplicate

### Form quản lý vé
- Danh sách vé
- Thêm/Sửa/Xóa/Tìm kiếm

### Báo cáo doanh thu
- Bảng chi tiết vé bán
- Tổng doanh thu
- Export PDF/Excel/Word

---

## 🔐 THÔNG TIN ĐĂNG NHẬP MẶC ĐỊNH

**Admin Account:**
- Username: `admin`
- Password: `admin`

---

## 📝 CHANGELOG

### Version 1.0.0 (2024-12-31)
- ✅ Fix Entity Framework DbSet null issue
- ✅ Enable automatic migrations
- ✅ Add seed data (50 tickets, 5 customers)
- ✅ Create Revenue Report form
- ✅ Update RDLC to 2016 format
- ✅ Add Post-Build Event solution
- ✅ Complete documentation

---

## 🤝 ĐÓNG GÓP

Contributions are welcome! Please:
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push and create a Pull Request

---

## 📄 LICENSE

This project is for educational purposes.

---

## 👥 TÁC GIẢ

- GitHub: [@hackersike123](https://github.com/hackersike123)

---

## 📞 HỖ TRỢ

Nếu gặp vấn đề:
1. Xem các file hướng dẫn trong thư mục gốc
2. Check Issues trên GitHub
3. Tạo Issue mới với label phù hợp

---

## ⭐ GETTING STARTED - 3 BƯỚC

```powershell
# 1. Clone
git clone https://github.com/hackersike123/PhanMemBanVe

# 2. Cài packages
Install-Package Microsoft.ReportingServices.ReportViewerControl.Winforms -Version 150.1484.0 -ProjectName PhanMemBanVe.GUI

# 3. Build & Run
dotnet build
# Nhấn F5 trong Visual Studio
```

**ĐƠN GIẢN VÀ DỄ DÀNG! 🚀**

---

## 🎯 ROADMAP

- [ ] Add more report types
- [ ] Dashboard with charts
- [ ] Mobile responsive design
- [ ] Email notifications
- [ ] Multi-language support
- [ ] API for external integration

---

**CHÚC BẠN SỬ DỤNG THÀNH CÔNG! 🎉**
