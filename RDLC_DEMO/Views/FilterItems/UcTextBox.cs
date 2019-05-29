using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;

namespace InhospitalIndicators.Service.Views.FilterItems
{
    public partial class UcTextBox : UcBaseFilter, ICanSetGetFilterInfo, ICanExportMyValue
    {
        public UcTextBox()
        {
            InitializeComponent();
        }

        public string DoExportMyValue()
        {
            return tb_value.Text;
        }

        public override void SetFilterInfo(FilterEntity entity)
        {
            base.SetFilterInfo(entity);

        }

        public override FilterValueObject GetFilter()
        {
            return new FilterValueObject { Key = ParamName, Value = tb_value.Text };
        }
    }
}
