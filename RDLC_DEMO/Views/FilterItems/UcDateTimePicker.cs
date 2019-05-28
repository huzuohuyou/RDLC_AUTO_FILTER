using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;

namespace InhospitalIndicators.Service.Views.FilterItems
{
    public partial class UcDateTimePicker : UcBaseFilter, ICanSetFilterInfo, ICanExportMyValue
    {

        public UcDateTimePicker()
        {
            InitializeComponent();
        }

        public string DoExportMyValue()
        {
            return dtp_value.Text;
        }

        public override void DoSetFilterInfo(FilterEntity entity)
        {
            base.DoSetFilterInfo(entity);

        }

        public override FilterValueObject GetFilter()
        {
            return new FilterValueObject { Key = ParamName, Value = dtp_value.Text };
        }
    }
}
