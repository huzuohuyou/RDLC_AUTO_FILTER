using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;
using System;
using System.Windows.Forms;

namespace InhospitalIndicators.Service.Views.FilterItems
{
    public partial class UcBaseFilter : UserControl, ICanGetFilter,ICanSetGetFilterInfo
    {
        FilterEntity entity;
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

        public virtual void SetFilterInfo(FilterEntity _entity)
        {
            entity = _entity;
            lb_text.Text = entity.ParamLabel;
            ParamName = entity.ParamName;
            OrderNo = entity.OrderNo;
        }

        //public virtual FilterEntity GetFilterInfo()
        //{
        //    return entity;
        //}
    }
}
