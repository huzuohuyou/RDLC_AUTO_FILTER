namespace InhospitalIndicators.Service.Views.FilterItems
{
    partial class UcBaseFilter
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_text
            // 
            this.lb_text.Location = new System.Drawing.Point(13, 10);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(100, 23);
            this.lb_text.TabIndex = 2;
            this.lb_text.Text = "参数标识：";
            // 
            // UcBaseFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.lb_text);
            this.Name = "UcBaseFilter";
            this.Size = new System.Drawing.Size(360, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_text;
    }
}
