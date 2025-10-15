# ✅ HOÀN TẤT CẤU HÌNH BÁO CÁO DOANH THU

## 🎉 Đã hoàn thành

### 1. ✅ Fix lỗi Entity Framework
- Thêm `virtual` keyword vào DbSet properties
- Enable automatic migrations
- Cấu hình database initializer
- Thêm seed data cho demo

### 2. ✅ Tạo Form Báo Cáo
- `FormTicketSalesReport.cs` - Form hiển thị báo cáo
- `FormTicketSalesReport.Designer.cs` - UI designer
- `ReportFileLocator.cs` - Helper class tìm file RDLC
- Tích hợp vào menu chính

### 3. ✅ Cấu hình RDLC Report
- File: `PhanMemBanVe.GUI\Reports\TicketSalesReport.rdlc`
- DataSet: `TicketSalesDataSet`
- Fields: TicketCode, CustomerCode, FullName, Phone, SaleDate, SeatNumber, AreaName, Price, IsRefunded

### 4. ✅ Sample Data
- 5 khách hàng mẫu
- 50 vé bán trong 30 ngày gần đây
- Mix giữa VIP (150,000đ) và Standard (75,000đ)
- Một số vé đã hoàn tiền

## 🚀 BƯỚC CUỐI CÙNG: Cài đặt Microsoft ReportViewer

### Tùy chọn A: Sử dụng Package Manager Console (KHUYẾN NGHỊ)

1. Mở Visual Studio
2. **Tools** → **NuGet Package Manager** → **Package Manager Console**
3. Chạy lệnh:

```powershell
Install-Package Microsoft.ReportingServices.ReportViewerControl.Winforms -Version 150.1484.0 -ProjectName PhanMemBanVe.GUI
```

### Tùy chọn B: Sử dụng PowerShell Script

1. Mở PowerShell trong thư mục solution
2. Chạy:
```powershell
.\Install-ReportViewer.ps1
```

### Tùy chọn C: Sử dụng NuGet Package Manager UI

1. Click phải vào **PhanMemBanVe.GUI** trong Solution Explorer
2. **Manage NuGet Packages...**
3. Tab **Browse**
4. Tìm: `Microsoft.ReportingServices.ReportViewerControl.Winforms`
5. Chọn version **150.1484.0**
6. Click **Install**

## 📋 Sau khi cài đặt package

### 1. Xóa Stub Files (Nếu có)
```
PhanMemBanVe\Stubs\ReportViewerStubs.cs
PhanMemBanVe.GUI\Stubs\ReportViewerStubs.cs (nếu tồn tại)
```

### 2. Clean & Rebuild
```
Build → Clean Solution
Build → Rebuild Solution
```

### 3. Chạy ứng dụng
```
Debug → Start Debugging (F5)
hoặc
Debug → Start Without Debugging (Ctrl+F5)
```

## 🎯 Sử dụng chức năng Báo cáo

### Truy cập báo cáo:
1. Chạy ứng dụng
2. Vào menu **Báo cáo** hoặc **Xem doanh thu**
3. Form báo cáo sẽ mở

### Tùy chọn lọc:
- **Từ ngày**: Ngày bắt đầu
- **Đến ngày**: Ngày kết thúc
- **Khu vực**: Lọc theo VIP, Standard, hoặc để trống để xem tất cả
- **Xem báo cáo**: Click để refresh dữ liệu

### Báo cáo hiển thị:
- Mã vé
- Mã khách hàng
- Tên khách hàng
- Số điện thoại
- Ngày bán
- Số ghế
- Khu vực (VIP/Standard)
- Giá tiền
- Trạng thái hoàn tiền

### Xuất báo cáo:
- Click icon **Export** trên toolbar ReportViewer
- Chọn định dạng: PDF, Excel, Word
- Save file

## 🔧 Nếu gặp lỗi

### Lỗi: "The type or namespace name 'Reporting' does not exist"
**Nguyên nhân**: Package chưa cài đúng  
**Giải pháp**: Cài lại package bằng Package Manager Console (Tùy chọn A)

### Lỗi: "Could not load file or assembly 'Microsoft.ReportViewer'"
**Nguyên nhân**: DLL chưa được copy vào output  
**Giải pháp**: Clean → Rebuild solution

### Lỗi: "Không tìm thấy file RDLC"
**Nguyên nhân**: File RDLC không được copy  
**Giải pháp**: 
1. Click phải vào `Reports\TicketSalesReport.rdlc`
2. Properties
3. **Build Action** = **Content**
4. **Copy to Output Directory** = **Copy if newer**

### Lỗi Database: "Unable to update database"
**Đã fix**: Automatic migrations đã được enable

### Báo cáo trống (không có dữ liệu)
**Giải pháp**: 
- Database sẽ tự động seed 50 vé mẫu lần đầu chạy
- Nếu vẫn trống, xóa database và chạy lại
- Database location: `(localdb)\MSSQLLocalDB` - `TicketManagementDb`

## 📊 Dữ liệu mẫu đã seed

| Loại | Số lượng | Chi tiết |
|------|----------|----------|
| Khách hàng | 5 | C001-C005 |
| Vé bán | 50 | T10000-T10049 |
| Thời gian | 30 ngày | Từ 30 ngày trước đến hôm nay |
| Khu vực | 2 loại | VIP (30%), Standard (70%) |
| Giá vé | 2 mức | VIP: 150,000đ, Standard: 75,000đ |
| Hoàn tiền | ~5% | Ngẫu nhiên |

## 📁 Files đã tạo/sửa

### Files mới:
- ✅ `PhanMemBanVe.GUI\FormTicketSalesReport.cs`
- ✅ `PhanMemBanVe.GUI\FormTicketSalesReport.Designer.cs`
- ✅ `HUONG_DAN_CAI_REPORTVIEWER.md`
- ✅ `Install-ReportViewer.ps1`
- ✅ `README_BAO_CAO.md` (file này)

### Files đã cập nhật:
- ✅ `PhanMemBanVe.DAL\Data\TicketManagementContext.cs` (thêm virtual)
- ✅ `PhanMemBanVe.DAL\Migrations\Configuration.cs` (seed data)
- ✅ `PhanMemBanVe.GUI\Program.cs` (database initializer)
- ✅ `PhanMemBanVe.GUI\FormMain.cs` (enable báo cáo)
- ✅ `PhanMemBanVe.GUI\App.config` (connection string)

### Files đã xóa:
- ❌ `PhanMemBanVe.GUI\FormTicketSalesReport.cs` (cũ - đã tạo lại)
- ❌ `PhanMemBanVe.GUI\FormTicketSalesReport.Designer.cs` (cũ - đã tạo lại)

## 🎓 Kiến thức bổ sung

### Entity Framework Virtual Properties
Từ khóa `virtual` cho phép EF tạo lazy loading proxies:
```csharp
public virtual DbSet<User> Users { get; set; }
```

### Automatic Migrations
Enable để tự động cập nhật database schema:
```csharp
AutomaticMigrationsEnabled = true;
AutomaticMigrationDataLossAllowed = true;
```

### Database Initializer
Tự động migrate khi app start:
```csharp
Database.SetInitializer(
    new MigrateDatabaseToLatestVersion<TicketManagementContext, Configuration>()
);
```

## 🎉 KẾT QUẢ

Sau khi cài đặt Microsoft ReportViewer package, bạn sẽ có:
- ✅ Báo cáo doanh thu bán vé đầy đủ chức năng
- ✅ Lọc theo ngày và khu vực
- ✅ Xuất báo cáo ra PDF/Excel/Word
- ✅ Hiển thị thông tin khách hàng và vé
- ✅ Tính toán tổng doanh thu tự động
- ✅ Dữ liệu mẫu để test ngay

---

**Chúc bạn thành công! 🚀**

Nếu có vấn đề gì, hãy kiểm tra lại từng bước trong hướng dẫn này.
