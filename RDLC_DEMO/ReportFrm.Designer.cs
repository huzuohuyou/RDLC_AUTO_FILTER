namespace InhospitalIndicators.Service
{
    partial class ReportFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.同期费用比ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项费用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检验项目比ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同期费用比ToolStripMenuItem,
            this.项费用ToolStripMenuItem,
            this.检验项目比ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(796, 32);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 同期费用比ToolStripMenuItem
            // 
            this.同期费用比ToolStripMenuItem.Name = "同期费用比ToolStripMenuItem";
            this.同期费用比ToolStripMenuItem.Size = new System.Drawing.Size(112, 28);
            this.同期费用比ToolStripMenuItem.Text = "同期费用比";
            // 
            // 项费用ToolStripMenuItem
            // 
            this.项费用ToolStripMenuItem.Name = "项费用ToolStripMenuItem";
            this.项费用ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.项费用ToolStripMenuItem.Text = "38项费用";
            // 
            // 检验项目比ToolStripMenuItem
            // 
            this.检验项目比ToolStripMenuItem.Name = "检验项目比ToolStripMenuItem";
            this.检验项目比ToolStripMenuItem.Size = new System.Drawing.Size(112, 28);
            this.检验项目比ToolStripMenuItem.Text = "检验项目比";
            // 
            // ReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = true;
            this.Name = "ReportFrm";
            this.Text = "ReportFrm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 同期费用比ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 项费用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检验项目比ToolStripMenuItem;
    }
}