# 🔧 FIX LỖI RDLC - HƯỚNG DẪN THỦ CÔNG

## ⚠️ VẤN ĐỀ:
File RDLC mới chưa được copy vào thư mục output, vẫn dùng file cũ bị lỗi.

---

## 🚀 GIẢI PHÁP NHANH (3 BƯỚC)

### CÁCH 1: Chạy PowerShell Script (NHANH NHẤT)

1. **Mở PowerShell** trong thư mục solution
2. **Chạy lệnh:**
   ```powershell
   .\Fix-RDLC-Error.ps1
   ```
3. **Follow hướng dẫn** trong script

---

### CÁCH 2: Fix thủ công trong Visual Studio

#### Bước 1: Xóa file RDLC cũ
1. Mở **File Explorer**
2. Đi đến: `PhanMemBanVe.GUI\bin\Debug\Reports\`
3. **XÓA** file `TicketSalesReport.rdlc` (nếu có)
4. **XÓA** toàn bộ thư mục `bin` và `obj` nếu muốn chắc chắn

#### Bước 2: Cấu hình file properties
1. Trong **Solution Explorer**, mở rộng `PhanMemBanVe.GUI` → `Reports`
2. **Click phải** vào `TicketSalesReport.rdlc`
3. Chọn **Properties** (hoặc nhấn F4)
4. Thay đổi các settings:
   - **Build Action**: Đổi từ `Embedded Resource` → **`Content`**
   - **Copy to Output Directory**: Đổi sang **`Copy if newer`** hoặc **`Copy always`**

#### Bước 3: Clean & Rebuild
1. **Build** → **Clean Solution**
2. **Build** → **Rebuild Solution**
3. **Debug** → **Start Debugging** (F5)

---

### CÁCH 3: Sửa trực tiếp file .csproj (CHO DEV)

1. **Đóng Visual Studio**
2. Mở file `PhanMemBanVe.GUI\PhanMemBanVe.GUI.csproj` bằng Notepad
3. Tìm dòng:
   ```xml
   <EmbeddedResource Include="Reports\TicketSalesReport.rdlc" />
   ```
4. **Thay thế** bằng:
   ```xml
   <Content Include="Reports\TicketSalesReport.rdlc">
     <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
   </Content>
   ```
5. **Lưu file**
6. **Mở lại Visual Studio**
7. **Clean & Rebuild**

---

## ✅ KIỂM TRA SAU KHI FIX

### Kiểm tra file đã được copy chưa:
1. Build solution
2. Mở thư mục: `PhanMemBanVe.GUI\bin\Debug\Reports\`
3. Kiểm tra file `TicketSalesReport.rdlc` có tồn tại không
4. Mở file bằng Notepad, kiểm tra dòng đầu:
   ```xml
   <Report xmlns="http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition"
   ```
   → Phải là **2016** chứ KHÔNG phải 2008!

### Chạy ứng dụng:
1. **F5** để debug
2. Vào menu **Báo cáo**
3. Nếu vẫn lỗi, xem phần **Troubleshooting** bên dưới

---

## 🔍 TROUBLESHOOTING

### Lỗi: "The element 'Textbox' in namespace .../2008/01/..." 
**Nguyên nhân:** Vẫn dùng file RDLC cũ (2008)  
**Giải pháp:**
1. Xóa toàn bộ thư mục `bin` và `obj`
2. Clean Solution
3. Rebuild Solution
4. Kiểm tra file trong `bin\Debug\Reports\` có đúng version 2016 không

### Lỗi: "Không tìm thấy file RDLC"
**Nguyên nhân:** File không được copy  
**Giải pháp:**
1. Kiểm tra Properties của file RDLC (Build Action = Content)
2. Hoặc copy thủ công:
   ```powershell
   Copy-Item "PhanMemBanVe.GUI\Reports\TicketSalesReport.rdlc" "PhanMemBanVe.GUI\bin\Debug\Reports\" -Force
   ```

### Lỗi: "The definition of the report is invalid"
**Nguyên nhân:** File RDLC bị corrupt hoặc cache cũ  
**Giải pháp:**
1. Đóng Visual Studio
2. Xóa thư mục `.vs` (hidden folder)
3. Xóa `bin` và `obj`
4. Mở lại VS và rebuild

### Báo cáo vẫn trống (không có lỗi)
**Nguyên nhân:** Database chưa có dữ liệu  
**Giải pháp:**
- Database tự động seed 50 vé lần đầu chạy
- Kiểm tra khoảng ngày: chọn 30 ngày trước đến hôm nay
- Thử để trống "Khu vực" để xem tất cả

---

## 📝 CHECKLIST FIX

- [ ] Xóa file RDLC cũ trong `bin\Debug\Reports\`
- [ ] File RDLC Properties: Build Action = **Content**
- [ ] File RDLC Properties: Copy to Output = **Copy if newer**
- [ ] Clean Solution
- [ ] Rebuild Solution
- [ ] Kiểm tra file mới trong output (namespace 2016)
- [ ] Chạy app và test báo cáo

---

## 🎯 NẾU VẪN KHÔNG ĐƯỢC

### Option A: Copy file thủ công mỗi lần build
```powershell
# Chạy sau mỗi lần build
Copy-Item "PhanMemBanVe.GUI\Reports\TicketSalesReport.rdlc" "PhanMemBanVe.GUI\bin\Debug\Reports\" -Force
```

### Option B: Thêm Post-Build Event
1. Click phải vào project **PhanMemBanVe.GUI**
2. **Properties**
3. **Build Events** → **Post-build event command line**
4. Thêm:
   ```
   if not exist "$(TargetDir)Reports\" mkdir "$(TargetDir)Reports\"
   copy /Y "$(ProjectDir)Reports\TicketSalesReport.rdlc" "$(TargetDir)Reports\"
   ```
5. **OK** và rebuild

---

## 📞 HỖ TRỢ THÊM

Nếu vẫn gặp vấn đề, gửi thông tin:
1. Visual Studio version
2. ReportViewer package version
3. Nội dung file RDLC (10 dòng đầu)
4. Screenshot lỗi
5. Kiểm tra: File trong `bin\Debug\Reports\` có namespace 2016 không?

---

## ✅ KẾT QUẢ MONG ĐỢI

Sau khi fix:
- ✅ File RDLC được copy tự động mỗi lần build
- ✅ Báo cáo load thành công
- ✅ Hiển thị dữ liệu đầy đủ
- ✅ Không còn lỗi XML namespace

**CHÚC THÀNH CÔNG! 🚀**
