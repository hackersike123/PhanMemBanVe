# GIẢI PHÁP NHANH - THÊM POST-BUILD EVENT

## 🚀 Fix lỗi RDLC bằng Post-Build Event (TỰ ĐỘNG COPY)

### Bước 1: Mở Project Properties
1. Trong **Solution Explorer**, click phải vào **PhanMemBanVe.GUI**
2. Chọn **Properties** (cuối cùng trong menu)

### Bước 2: Thêm Post-Build Event
1. Click tab **Build Events** (bên trái)
2. Trong ô **Post-build event command line**, paste đoạn code sau:

```batch
echo === Copying RDLC files ===
if not exist "$(TargetDir)Reports\" mkdir "$(TargetDir)Reports\"
copy /Y "$(ProjectDir)Reports\TicketSalesReport.rdlc" "$(TargetDir)Reports\TicketSalesReport.rdlc"
if %ERRORLEVEL% EQU 0 (
    echo ✓ RDLC file copied successfully
) else (
    echo ✗ Failed to copy RDLC file
)
```

### Bước 3: Lưu và Build
1. Nhấn **Ctrl+S** để lưu
2. **Build → Rebuild Solution**
3. Xem **Output window** sẽ thấy:
   ```
   === Copying RDLC files ===
   ✓ RDLC file copied successfully
   ```

### Bước 4: Test
1. **F5** để chạy
2. Vào menu **Báo cáo**
3. Xem báo cáo → **HOÀN TẤT!** ✅

---

## 📸 Screenshot minh họa:

```
┌─────────────────────────────────────────────┐
│ PhanMemBanVe.GUI - Properties               │
├─────────────────────────────────────────────┤
│ ☐ Application                               │
│ ☐ Build                                     │
│ ☑ Build Events          ◄── CHỌN MỤC NÀY   │
│ ☐ Debug                                     │
│ ☐ Resources                                 │
│ ☐ Settings                                  │
│ ☐ Reference Paths                           │
│ ☐ Signing                                   │
├─────────────────────────────────────────────┤
│ Pre-build event command line:               │
│ ┌─────────────────────────────────────────┐ │
│ │                                         │ │
│ └─────────────────────────────────────────┘ │
│                                             │
│ Post-build event command line:              │
│ ┌─────────────────────────────────────────┐ │
│ │ echo === Copying RDLC files ===        │ │ ◄── PASTE VÀO ĐÂY
│ │ if not exist "$(TargetDir)Reports\" ...│ │
│ │ copy /Y "$(ProjectDir)Reports\Ticket...│ │
│ └─────────────────────────────────────────┘ │
│                                             │
│ Run the post-build event: ▼ On successful  │
│                              build          │
│                                             │
│         [ OK ]        [ Cancel ]            │
└─────────────────────────────────────────────┘
```

---

## ✨ LỢI ÍCH:
- ✅ **Tự động copy** file RDLC mỗi lần build
- ✅ **Không cần** chỉnh Properties của file RDLC
- ✅ **Không cần** sửa file .csproj
- ✅ **Luôn dùng** file RDLC mới nhất
- ✅ **Thấy log** trong Output window

---

## 🔍 XEM LOG:
Sau khi build, mở **View → Output** (hoặc Ctrl+W, O), chọn **Build** trong dropdown, sẽ thấy:
```
------ Build started: Project: PhanMemBanVe.GUI ------
  PhanMemBanVe.GUI -> C:\...\bin\Debug\PhanMemBanVe.GUI.exe
  === Copying RDLC files ===
  1 file(s) copied.
  ✓ RDLC file copied successfully
========== Build: 1 succeeded, 0 failed ==========
```

---

## ⚡ NHANH HƠN: CHẠY SCRIPT

Hoặc chạy script PowerShell tự động thêm Post-Build Event:

```powershell
# Chạy script này trong PowerShell tại thư mục solution
.\Add-PostBuildEvent.ps1
```

---

**ĐƠN GIẢN VÀ HIỆU QUẢ! 🎉**
