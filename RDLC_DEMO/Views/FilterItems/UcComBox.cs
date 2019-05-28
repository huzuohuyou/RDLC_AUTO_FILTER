using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;

namespace InhospitalIndicators.Service.Views.FilterItems
{
    public partial class UcComBox : UcBaseFilter, ICanSetFilterInfo, ICanExportMyValue
    {
        public UcComBox()
        {
            InitializeComponent();
        }

        public string DoExportMyValue()
        {
            return cmb_value.Text;
        }

        public override void DoSetFilterInfo(FilterEntity entity)
        {
            base.DoSetFilterInfo(entity);

        }

        public override FilterValueObject GetFilter()
        {
            return new FilterValueObject { Key = ParamName,Value=cmb_value.Text };
        }
    }
}
