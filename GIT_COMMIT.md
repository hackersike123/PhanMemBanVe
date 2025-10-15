# Git Commit Message

```bash
git add .
git commit -m "feat: Enable Microsoft ReportViewer for revenue reports

✨ New Features:
- Add FormTicketSalesReport with full reporting functionality
- Add ReportFileLocator utility class
- Integrate report viewer into main menu

🔧 Fixes:
- Add virtual keyword to DbSet properties (fix null DbSet issue)
- Enable automatic migrations
- Configure MigrateDatabaseToLatestVersion initializer
- Fix connection string configuration

📊 Data:
- Add seed data: 5 sample customers
- Add seed data: 50 ticket sales over 30 days
- Mix of VIP (150k) and Standard (75k) tickets

📝 Documentation:
- Add QUICK_START.md for quick setup
- Add README_BAO_CAO.md for detailed guide
- Add HUONG_DAN_CAI_REPORTVIEWER.md
- Add Install-ReportViewer.ps1 script

⚠️ Breaking Changes:
- Removed old FormTicketSalesReport files (recreated with correct namespace)
- AutomaticMigrationDataLossAllowed = true (may lose data on schema changes)

📦 Dependencies:
- Requires: Microsoft.ReportingServices.ReportViewerControl.Winforms 150.1484.0
- See QUICK_START.md for installation

🎯 Next Steps:
1. Install ReportViewer package via Package Manager Console
2. Rebuild solution
3. Run application and test report functionality
"
```

## Hoặc commit từng phần:

```bash
# Commit 1: Fix Entity Framework issues
git add PhanMemBanVe.DAL/Data/TicketManagementContext.cs
git add PhanMemBanVe.DAL/Migrations/Configuration.cs
git add PhanMemBanVe.GUI/Program.cs
git add PhanMemBanVe.GUI/App.config
git commit -m "fix: Fix Entity Framework DbSet null issue and enable auto migrations"

# Commit 2: Add report functionality
git add PhanMemBanVe.GUI/FormTicketSalesReport.cs
git add PhanMemBanVe.GUI/FormTicketSalesReport.Designer.cs
git add PhanMemBanVe.GUI/FormMain.cs
git add PhanMemBanVe.GUI/Utils/ReportFileLocator.cs
git commit -m "feat: Add revenue report form with Microsoft ReportViewer"

# Commit 3: Add documentation
git add *.md
git add *.ps1
git commit -m "docs: Add setup guides and installation scripts"
```
