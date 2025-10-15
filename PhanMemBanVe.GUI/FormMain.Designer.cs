namespace PhanMemBanVe.GUI
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTicketManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewRevenue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.chứcNăngToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(1154, 43);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.menuExit});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(133, 39);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(227, 40);
            this.mnuLogin.Text = "Đăng nhập";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(227, 40);
            this.menuExit.Text = "Thoát";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTicketManagement,
            this.mnuCustomers,
            this.mnuViewRevenue,
            this.mnuReportStatistics});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(148, 39);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // mnuTicketManagement
            // 
            this.mnuTicketManagement.Name = "mnuTicketManagement";
            this.mnuTicketManagement.Size = new System.Drawing.Size(298, 40);
            this.mnuTicketManagement.Text = "Bán vé";
            this.mnuTicketManagement.Click += new System.EventHandler(this.mnuTicketManagement_Click);
            // 
            // mnuCustomers
            // 
            this.mnuCustomers.Name = "mnuCustomers";
            this.mnuCustomers.Size = new System.Drawing.Size(298, 40);
            this.mnuCustomers.Text = "Khách hàng";
            this.mnuCustomers.Click += new System.EventHandler(this.mnuCustomers_Click);
            // 
            // mnuViewRevenue
            // 
            this.mnuViewRevenue.Name = "mnuViewRevenue";
            this.mnuViewRevenue.Size = new System.Drawing.Size(298, 40);
            this.mnuViewRevenue.Text = "Xem doanh thu";
            this.mnuViewRevenue.Click += new System.EventHandler(this.mnuViewRevenue_Click);
            // 
            // mnuReportStatistics
            // 
            this.mnuReportStatistics.Name = "mnuReportStatistics";
            this.mnuReportStatistics.Size = new System.Drawing.Size(298, 40);
            this.mnuReportStatistics.Text = "Báo cáo thống kê";
            this.mnuReportStatistics.Click += new System.EventHandler(this.MnuReportStatistics_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 660);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FormMain";
            this.Text = "Phần mềm bán vé phim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTicketManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomers;
        private System.Windows.Forms.ToolStripMenuItem mnuViewRevenue;
        private System.Windows.Forms.ToolStripMenuItem mnuReportStatistics;
    }
}

