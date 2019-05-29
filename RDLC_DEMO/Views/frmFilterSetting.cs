using Framework.Win.Base;
using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Services.System;
using InhospitalIndicators.Service.Services.System.Interfaces;
using InhospitalIndicators.Service.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InhospitalIndicators.Service.Views
{
    public partial class FrmFilterSetting : PageForm, ICanAddRemoveUc
    {
        ICanSaveFilters service =new ICanSaveFiltersImplemet();
        int xIndex = 0,yIndex=0;

        public FrmFilterSetting()
        {
            InitializeComponent();
        }

        public void DoAdd(IamUc uc)
        {
            if (panel_filter.Controls.Count>=14)
            {
                MessageBox.Show("最多14个过滤条件");
                return;
            }
            var control = uc as Control;
            control.Top = yIndex * 200 + 15;
            control.Left = xIndex * 410 + 5;
            panel_filter.Controls.Add(control);
            xIndex++;
            if (xIndex % 2 == 0 && xIndex != 0)
            {
                yIndex++;
                xIndex = 0;
            }
        }

        public void DoRemove(IamUc uc)
        {
            var control = uc as Control;
            panel_filter.Controls.Remove(control);
        }

        private void frmFilterSetting_Load(object sender, EventArgs e)
        {
            if (panel_filter.Controls.Count==0)
            {
                DoAdd(new ucFilter(this));
            }
        }

        private void btn_save_filter_Click(object sender, EventArgs e)
        {
            var list = new List<FilterEntity>();
            foreach (var item in panel_filter.Controls)
            {
                list.Add((item as ucFilter).Item);
            }
            service.SaveFilter(list,"demo");
        }

        public void ReFreshUc()
        {
            throw new NotImplementedException();
        }
    }
}
