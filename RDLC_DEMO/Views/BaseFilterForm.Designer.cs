namespace InhospitalIndicators.Service.Views
{
    partial class BaseFilterForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_filter = new System.Windows.Forms.Panel();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn_query = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_filter_setting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel_filter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer2);
            this.splitContainer1.Size = new System.Drawing.Size(996, 535);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel_filter
            // 
            this.panel_filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_filter.Location = new System.Drawing.Point(0, 0);
            this.panel_filter.Name = "panel_filter";
            this.panel_filter.Size = new System.Drawing.Size(996, 89);
            this.panel_filter.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "InhospitalIndicators.Service.Reports.CurrentPeriod.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(996, 442);
            this.reportViewer2.TabIndex = 1;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_query.Location = new System.Drawing.Point(837, 555);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(137, 46);
            this.btn_query.TabIndex = 1;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Location = new System.Drawing.Point(674, 555);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(137, 46);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_filter_setting
            // 
            this.btn_filter_setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_filter_setting.Location = new System.Drawing.Point(508, 555);
            this.btn_filter_setting.Name = "btn_filter_setting";
            this.btn_filter_setting.Size = new System.Drawing.Size(137, 46);
            this.btn_filter_setting.TabIndex = 1;
            this.btn_filter_setting.Text = "过滤条件";
            this.btn_filter_setting.UseVisualStyleBackColor = true;
            this.btn_filter_setting.Click += new System.EventHandler(this.btn_filter_setting_Click);
            // 
            // BaseFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_filter_setting);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BaseFilterForm";
            this.Text = "BaseFilterForm";
            this.Load += new System.EventHandler(this.BaseFilterForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Panel panel_filter;
        private System.Windows.Forms.Button btn_close;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Button btn_filter_setting;
    }
}