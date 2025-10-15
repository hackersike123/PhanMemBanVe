# ⚡ ONE COMMAND TO RULE THEM ALL - PUSH LÊN GITHUB

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "AUTO PUSH TO GITHUB - ALL IN ONE" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Confirm
$confirm = Read-Host "Bạn có muốn dọn dẹp và push lên GitHub? (y/n)"
if ($confirm -ne 'y') {
    Write-Host "Đã hủy." -ForegroundColor Yellow
    exit
}

Write-Host ""
Write-Host "BƯỚC 1: Dọn dẹp files thừa..." -ForegroundColor Yellow

# Files to delete
$patterns = @(
    "Debug-*.ps1", "Fix-*.ps1", "Add-*.ps1",
    "FIX_*.md", "DEBUG_*.md", "TONG_KET_*.md",
    "BAT_DAU_*.md", "CHECKLIST.md", "GIAI_PHAP_*.md",
    "HUONG_DAN_*.md", "MOT_LENH_*.md", "PUSH_*.md"
)

$deleted = 0
foreach ($pattern in $patterns) {
    $files = Get-ChildItem -Filter $pattern -ErrorAction SilentlyContinue
    foreach ($file in $files) {
        Remove-Item $file.FullName -Force
        Write-Host "  ✓ Xóa: $($file.Name)" -ForegroundColor Green
        $deleted++
    }
}

Write-Host "  → Đã xóa $deleted files" -ForegroundColor Green
Write-Host ""

Write-Host "BƯỚC 2: Kiểm tra git status..." -ForegroundColor Yellow
git status
Write-Host ""

Write-Host "BƯỚC 3: Git add..." -ForegroundColor Yellow
git add .
Write-Host "  ✓ Đã add tất cả changes" -ForegroundColor Green
Write-Host ""

Write-Host "BƯỚC 4: Git commit..." -ForegroundColor Yellow
$commitMsg = @"
Add reporting and statistics features

Features:
- Ticket sales report with RDLC viewer
- Activity statistics with data analysis
- Database seed data (50 tickets, 5 customers)

Bug fixes:
- Entity Framework DbSet initialization
- RDLC file format upgrade (2008 → 2016)
- DataGridView AutoSizeColumnsMode conflicts

Documentation:
- Add comprehensive README files
- Add quick start guides
"@

git commit -m $commitMsg
Write-Host "  ✓ Đã commit" -ForegroundColor Green
Write-Host ""

Write-Host "BƯỚC 5: Git push..." -ForegroundColor Yellow
git push origin master

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host "✅ THÀNH CÔNG!" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Repository: https://github.com/hackersike123/PhanMemBanVe" -ForegroundColor White
    Write-Host ""
    Write-Host "Kiểm tra trên GitHub ngay!" -ForegroundColor Yellow
} else {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "❌ LỖI KHI PUSH!" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host ""
    Write-Host "Thử:" -ForegroundColor Yellow
    Write-Host "  git pull origin master --rebase" -ForegroundColor White
    Write-Host "  git push origin master" -ForegroundColor White
}

Write-Host ""
pause
