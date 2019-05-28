using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;
using System;
using System.Windows.Forms;

namespace InhospitalIndicators.Service.Views.FilterItems
{
    public partial class UcBaseFilter : UserControl, ICanGetFilter,ICanSetFilterInfo
    {
        public string ParamName { get; set; }

        public decimal OrderNo  { get; set; }

        public UcBaseFilter()
        {
            InitializeComponent();
        }

        public virtual FilterValueObject GetFilter()
        {
            throw new Exception("未实现");
        }

        public virtual void DoSetFilterInfo(FilterEntity entity)
        {
            lb_text.Text = entity.ParamLabel;
            ParamName = entity.ParamName;
            OrderNo = entity.OrderNo;
        }
    }
}
