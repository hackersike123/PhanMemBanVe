using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PhanMemBanVe
{
    partial class FormTicketSalesReport : Form
    {
        private System.ComponentModel.IContainer components = null;
        private ReportViewer reportViewer1;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblFrom;
        private Label lblTo;
        private TextBox txtArea;
        private Label lblArea;
        private Button btnRun;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.reportViewer1 = new ReportViewer();
            this.dtpFrom = new DateTimePicker();
            this.dtpTo = new DateTimePicker();
            this.lblFrom = new Label();
            this.lblTo = new Label();
            this.txtArea = new TextBox();
            this.lblArea = new Label();
            this.btnRun = new Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                                   | AnchorStyles.Left)
                                   | AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(12, 50);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(960, 540);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(60, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(195, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(12, 15);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(43, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "Từ ngày";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(166, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "đến";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(355, 12);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(120, 20);
            this.txtArea.TabIndex = 5;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(310, 15);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(43, 13);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Khu vực";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(490, 10);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Xem";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new EventHandler(this.btnRun_Click);
            // 
            // FormTicketSalesReport
            // 
            this.ClientSize = new System.Drawing.Size(984, 602);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormTicketSalesReport";
            this.Text = "Báo cáo bán vé";
            this.Load += new EventHandler(this.FormTicketSalesReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}