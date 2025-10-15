# Script để cài đặt Microsoft ReportViewer cho PhanMemBanVe.GUI
# Chạy script này trong PowerShell hoặc PowerShell ISE

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "CÀI ĐẶT MICROSOFT REPORTVIEWER" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Kiểm tra nuget.exe
$nugetPath = ".\nuget.exe"
if (-not (Test-Path $nugetPath)) {
    Write-Host "Đang tải NuGet.exe..." -ForegroundColor Yellow
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetPath
    Write-Host "✓ Đã tải NuGet.exe" -ForegroundColor Green
}

Write-Host ""
Write-Host "Đang cài đặt Microsoft.ReportingServices.ReportViewerControl.Winforms..." -ForegroundColor Yellow
Write-Host ""

# Cài package cho PhanMemBanVe.GUI
& $nugetPath install Microsoft.ReportingServices.ReportViewerControl.Winforms -Version 150.1484.0 -OutputDirectory packages -Source https://api.nuget.org/v3/index.json

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "✓ Cài đặt thành công!" -ForegroundColor Green
    Write-Host ""
    Write-Host "BƯỚC TIẾP THEO:" -ForegroundColor Cyan
    Write-Host "1. Mở Visual Studio" -ForegroundColor White
    Write-Host "2. Click phải vào project PhanMemBanVe.GUI" -ForegroundColor White
    Write-Host "3. Chọn 'Manage NuGet Packages'" -ForegroundColor White
    Write-Host "4. Click tab 'Installed' để verify package đã cài" -ForegroundColor White
    Write-Host "5. Rebuild solution: Build → Rebuild Solution" -ForegroundColor White
    Write-Host "6. Chạy ứng dụng và test chức năng báo cáo" -ForegroundColor White
    Write-Host ""
} else {
    Write-Host ""
    Write-Host "✗ Lỗi khi cài đặt package!" -ForegroundColor Red
    Write-Host ""
    Write-Host "Hãy sử dụng Visual Studio Package Manager Console:" -ForegroundColor Yellow
    Write-Host "Install-Package Microsoft.ReportingServices.ReportViewerControl.Winforms -Version 150.1484.0 -ProjectName PhanMemBanVe.GUI" -ForegroundColor White
    Write-Host ""
}

Write-Host "========================================" -ForegroundColor Cyan
pause
