namespace InhospitalIndicators.Service.Views
{
    partial class FrmFilterSetting
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
            this.panel_filter = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_save_filter = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_save_sql = new System.Windows.Forms.Button();
            this.btn_prevew = new System.Windows.Forms.Button();
            this.dgv_preview = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bnt_save_rdlc = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofd_rdlc = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_preview)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_filter
            // 
            this.panel_filter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filter.Location = new System.Drawing.Point(0, 0);
            this.panel_filter.Name = "panel_filter";
            this.panel_filter.Size = new System.Drawing.Size(954, 1800);
            this.panel_filter.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(994, 614);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(986, 579);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "过滤条件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_save_filter);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.panel_filter);
            this.splitContainer2.Size = new System.Drawing.Size(980, 573);
            this.splitContainer2.SplitterDistance = 51;
            this.splitContainer2.TabIndex = 1;
            // 
            // btn_save_filter
            // 
            this.btn_save_filter.Location = new System.Drawing.Point(5, 12);
            this.btn_save_filter.Name = "btn_save_filter";
            this.btn_save_filter.Size = new System.Drawing.Size(75, 31);
            this.btn_save_filter.TabIndex = 3;
            this.btn_save_filter.Text = "保存";
            this.btn_save_filter.UseVisualStyleBackColor = true;
            this.btn_save_filter.Click += new System.EventHandler(this.btn_save_filter_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_save_sql);
            this.tabPage2.Controls.Add(this.btn_prevew);
            this.tabPage2.Controls.Add(this.dgv_preview);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(986, 579);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据源";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_save_sql
            // 
            this.btn_save_sql.Location = new System.Drawing.Point(783, 236);
            this.btn_save_sql.Name = "btn_save_sql";
            this.btn_save_sql.Size = new System.Drawing.Size(75, 31);
            this.btn_save_sql.TabIndex = 2;
            this.btn_save_sql.Text = "保存";
            this.btn_save_sql.UseVisualStyleBackColor = true;
            // 
            // btn_prevew
            // 
            this.btn_prevew.Location = new System.Drawing.Point(896, 236);
            this.btn_prevew.Name = "btn_prevew";
            this.btn_prevew.Size = new System.Drawing.Size(75, 31);
            this.btn_prevew.TabIndex = 2;
            this.btn_prevew.Text = "预览";
            this.btn_prevew.UseVisualStyleBackColor = true;
            // 
            // dgv_preview
            // 
            this.dgv_preview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_preview.Location = new System.Drawing.Point(6, 283);
            this.dgv_preview.Name = "dgv_preview";
            this.dgv_preview.RowTemplate.Height = 30;
            this.dgv_preview.Size = new System.Drawing.Size(974, 256);
            this.dgv_preview.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(980, 218);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bnt_save_rdlc);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(986, 579);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "RDLC文件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bnt_save_rdlc
            // 
            this.bnt_save_rdlc.Location = new System.Drawing.Point(357, 16);
            this.bnt_save_rdlc.Name = "bnt_save_rdlc";
            this.bnt_save_rdlc.Size = new System.Drawing.Size(75, 31);
            this.bnt_save_rdlc.TabIndex = 2;
            this.bnt_save_rdlc.Text = "保存";
            this.bnt_save_rdlc.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 31);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件名：";
            // 
            // ofd_rdlc
            // 
            this.ofd_rdlc.Filter = "报表文件|*.rdlc";
            // 
            // FrmFilterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmFilterSetting";
            this.ShowSideBar = false;
            this.Text = "过滤条件设计期";
            this.Load += new System.EventHandler(this.frmFilterSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_preview)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_prevew;
        private System.Windows.Forms.DataGridView dgv_preview;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_save_sql;
        private System.Windows.Forms.Button bnt_save_rdlc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_save_filter;
        private System.Windows.Forms.OpenFileDialog ofd_rdlc;
    }
}