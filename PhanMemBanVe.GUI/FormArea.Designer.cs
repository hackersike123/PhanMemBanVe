namespace PhanMemBanVe.GUI
{
    partial class frmArea
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
            this.btnSaveArea = new System.Windows.Forms.Button();
            this.txtAreaId = new System.Windows.Forms.TextBox();
            this.txtAreaName = new System.Windows.Forms.TextBox();
            this.btnExitArea = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveArea
            // 
            this.btnSaveArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSaveArea.Location = new System.Drawing.Point(181, 194);
            this.btnSaveArea.Name = "btnSaveArea";
            this.btnSaveArea.Size = new System.Drawing.Size(130, 48);
            this.btnSaveArea.TabIndex = 0;
            this.btnSaveArea.Text = "Luu";
            this.btnSaveArea.UseVisualStyleBackColor = true;
            this.btnSaveArea.Click += new System.EventHandler(this.btnSaveArea_Click);
            // 
            // txtAreaId
            // 
            this.txtAreaId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtAreaId.Location = new System.Drawing.Point(181, 71);
            this.txtAreaId.Name = "txtAreaId";
            this.txtAreaId.Size = new System.Drawing.Size(375, 36);
            this.txtAreaId.TabIndex = 1;
            // 
            // txtAreaName
            // 
            this.txtAreaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtAreaName.Location = new System.Drawing.Point(181, 133);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(375, 36);
            this.txtAreaName.TabIndex = 1;
            // 
            // btnExitArea
            // 
            this.btnExitArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExitArea.Location = new System.Drawing.Point(426, 194);
            this.btnExitArea.Name = "btnExitArea";
            this.btnExitArea.Size = new System.Drawing.Size(130, 48);
            this.btnExitArea.TabIndex = 0;
            this.btnExitArea.Text = "Thoat";
            this.btnExitArea.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(67, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ma so";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(67, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ten";
            // 
            // frmArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 332);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAreaName);
            this.Controls.Add(this.txtAreaId);
            this.Controls.Add(this.btnExitArea);
            this.Controls.Add(this.btnSaveArea);
            this.Name = "frmArea";
            this.Text = "Them Khu Vuc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveArea;
        private System.Windows.Forms.TextBox txtAreaId;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Button btnExitArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}