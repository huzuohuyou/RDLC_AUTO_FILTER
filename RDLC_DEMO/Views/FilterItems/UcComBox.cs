using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;

namespace InhospitalIndicators.Service.Views.FilterItems
{
    public partial class UcComBox : UcBaseFilter, ICanSetGetFilterInfo, ICanExportMyValue
    {
        public UcComBox()
        {
            InitializeComponent();
        }

        public string DoExportMyValue()
        {
            return cmb_value.Text;
        }

        public override void SetFilterInfo(FilterEntity entity)
        {
            base.SetFilterInfo(entity);

        }

        

        public override FilterValueObject GetFilter()
        {
            return new FilterValueObject { Key = ParamName,Value=cmb_value.Text };
        }
    }
}
