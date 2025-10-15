namespace PhanMemBanVe.GUI
{
    partial class FormActivityStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboGroupBy = new System.Windows.Forms.ComboBox();
            this.lblGroupBy = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblAvgPriceValue = new System.Windows.Forms.Label();
            this.lblAvgPrice = new System.Windows.Forms.Label();
            this.lblRefundedValue = new System.Windows.Forms.Label();
            this.lblRefunded = new System.Windows.Forms.Label();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tabByPeriod = new System.Windows.Forms.TabPage();
            this.dgvPeriod = new System.Windows.Forms.DataGridView();
            this.tabByArea = new System.Windows.Forms.TabPage();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.tabByPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriod)).BeginInit();
            this.tabByArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.cboGroupBy);
            this.panelTop.Controls.Add(this.lblGroupBy);
            this.panelTop.Controls.Add(this.dtpTo);
            this.panelTop.Controls.Add(this.lblTo);
            this.panelTop.Controls.Add(this.dtpFrom);
            this.panelTop.Controls.Add(this.lblFrom);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(750, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // cboGroupBy
            // 
            this.cboGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroupBy.FormattingEnabled = true;
            this.cboGroupBy.Items.AddRange(new object[] {
            "Ngày",
            "Tuần",
            "Tháng"});
            this.cboGroupBy.Location = new System.Drawing.Point(600, 28);
            this.cboGroupBy.Name = "cboGroupBy";
            this.cboGroupBy.Size = new System.Drawing.Size(120, 24);
            this.cboGroupBy.TabIndex = 5;
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.AutoSize = true;
            this.lblGroupBy.Location = new System.Drawing.Point(520, 31);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(68, 16);
            this.lblGroupBy.TabIndex = 4;
            this.lblGroupBy.Text = "Nhóm theo:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(360, 28);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 22);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(290, 31);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(60, 16);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Đến ngày:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(120, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 22);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(30, 31);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(56, 16);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOverview);
            this.tabControl1.Controls.Add(this.tabByPeriod);
            this.tabControl1.Controls.Add(this.tabByArea);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 520);
            this.tabControl1.TabIndex = 1;
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.panelSummary);
            this.tabOverview.Location = new System.Drawing.Point(4, 25);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabOverview.Size = new System.Drawing.Size(992, 491);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Tổng quan";
            this.tabOverview.UseVisualStyleBackColor = true;
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelSummary.Controls.Add(this.lblAvgPriceValue);
            this.panelSummary.Controls.Add(this.lblAvgPrice);
            this.panelSummary.Controls.Add(this.lblRefundedValue);
            this.panelSummary.Controls.Add(this.lblRefunded);
            this.panelSummary.Controls.Add(this.lblRevenueValue);
            this.panelSummary.Controls.Add(this.lblRevenue);
            this.panelSummary.Controls.Add(this.lblTotalValue);
            this.panelSummary.Controls.Add(this.lblTotal);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSummary.Location = new System.Drawing.Point(3, 3);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(986, 485);
            this.panelSummary.TabIndex = 0;
            // 
            // lblAvgPriceValue
            // 
            this.lblAvgPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblAvgPriceValue.ForeColor = System.Drawing.Color.Green;
            this.lblAvgPriceValue.Location = new System.Drawing.Point(500, 250);
            this.lblAvgPriceValue.Name = "lblAvgPriceValue";
            this.lblAvgPriceValue.Size = new System.Drawing.Size(400, 50);
            this.lblAvgPriceValue.TabIndex = 7;
            this.lblAvgPriceValue.Text = "0 VNĐ";
            this.lblAvgPriceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgPrice
            // 
            this.lblAvgPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAvgPrice.Location = new System.Drawing.Point(500, 200);
            this.lblAvgPrice.Name = "lblAvgPrice";
            this.lblAvgPrice.Size = new System.Drawing.Size(400, 40);
            this.lblAvgPrice.TabIndex = 6;
            this.lblAvgPrice.Text = "GIÁ TRUNG BÌNH";
            this.lblAvgPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRefundedValue
            // 
            this.lblRefundedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblRefundedValue.ForeColor = System.Drawing.Color.Red;
            this.lblRefundedValue.Location = new System.Drawing.Point(80, 250);
            this.lblRefundedValue.Name = "lblRefundedValue";
            this.lblRefundedValue.Size = new System.Drawing.Size(400, 50);
            this.lblRefundedValue.TabIndex = 5;
            this.lblRefundedValue.Text = "0";
            this.lblRefundedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRefunded
            // 
            this.lblRefunded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRefunded.Location = new System.Drawing.Point(80, 200);
            this.lblRefunded.Name = "lblRefunded";
            this.lblRefunded.Size = new System.Drawing.Size(400, 40);
            this.lblRefunded.TabIndex = 4;
            this.lblRefunded.Text = "VÉ ĐÃ HOÀN";
            this.lblRefunded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblRevenueValue.Location = new System.Drawing.Point(500, 100);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(400, 60);
            this.lblRevenueValue.TabIndex = 3;
            this.lblRevenueValue.Text = "0 VNĐ";
            this.lblRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRevenue
            // 
            this.lblRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblRevenue.Location = new System.Drawing.Point(500, 40);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(400, 50);
            this.lblRevenue.TabIndex = 2;
            this.lblRevenue.Text = "TỔNG DOANH THU";
            this.lblRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalValue.Location = new System.Drawing.Point(80, 100);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(400, 60);
            this.lblTotalValue.TabIndex = 1;
            this.lblTotalValue.Text = "0";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(80, 40);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(400, 50);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TỔNG SỐ VÉ ĐÃ BÁN";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabByPeriod
            // 
            this.tabByPeriod.Controls.Add(this.dgvPeriod);
            this.tabByPeriod.Location = new System.Drawing.Point(4, 25);
            this.tabByPeriod.Name = "tabByPeriod";
            this.tabByPeriod.Padding = new System.Windows.Forms.Padding(3);
            this.tabByPeriod.Size = new System.Drawing.Size(992, 491);
            this.tabByPeriod.TabIndex = 1;
            this.tabByPeriod.Text = "Theo thời gian";
            this.tabByPeriod.UseVisualStyleBackColor = true;
            // 
            // dgvPeriod
            // 
            this.dgvPeriod.AllowUserToAddRows = false;
            this.dgvPeriod.AllowUserToDeleteRows = false;
            this.dgvPeriod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeriod.Location = new System.Drawing.Point(3, 3);
            this.dgvPeriod.Name = "dgvPeriod";
            this.dgvPeriod.ReadOnly = true;
            this.dgvPeriod.RowHeadersWidth = 51;
            this.dgvPeriod.RowTemplate.Height = 24;
            this.dgvPeriod.Size = new System.Drawing.Size(986, 485);
            this.dgvPeriod.TabIndex = 0;
            // 
            // tabByArea
            // 
            this.tabByArea.Controls.Add(this.dgvArea);
            this.tabByArea.Location = new System.Drawing.Point(4, 25);
            this.tabByArea.Name = "tabByArea";
            this.tabByArea.Size = new System.Drawing.Size(992, 491);
            this.tabByArea.TabIndex = 2;
            this.tabByArea.Text = "Theo khu vực";
            this.tabByArea.UseVisualStyleBackColor = true;
            // 
            // dgvArea
            // 
            this.dgvArea.AllowUserToAddRows = false;
            this.dgvArea.AllowUserToDeleteRows = false;
            this.dgvArea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArea.Location = new System.Drawing.Point(0, 0);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.ReadOnly = true;
            this.dgvArea.RowHeadersWidth = 51;
            this.dgvArea.RowTemplate.Height = 24;
            this.dgvArea.Size = new System.Drawing.Size(992, 491);
            this.dgvArea.TabIndex = 0;
            // 
            // FormActivityStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelTop);
            this.Name = "FormActivityStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo thống kê hoạt động";
            this.Load += new System.EventHandler(this.FormActivityStatistics_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.panelSummary.ResumeLayout(false);
            this.tabByPeriod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriod)).EndInit();
            this.tabByArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cboGroupBy;
        private System.Windows.Forms.Label lblGroupBy;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.TabPage tabByPeriod;
        private System.Windows.Forms.TabPage tabByArea;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblRefunded;
        private System.Windows.Forms.Label lblRefundedValue;
        private System.Windows.Forms.Label lblAvgPrice;
        private System.Windows.Forms.Label lblAvgPriceValue;
        private System.Windows.Forms.DataGridView dgvPeriod;
        private System.Windows.Forms.DataGridView dgvArea;
    }
}
