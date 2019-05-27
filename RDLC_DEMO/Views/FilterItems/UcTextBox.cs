using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;

namespace InhospitalIndicators.Service.Views.FilterItems
{
    public partial class UcTextBox : UcBaseFilter, ICanSetFilterInfo, ICanExportMyValue
    {
        public UcTextBox()
        {
            InitializeComponent();
        }

        public string DoExportMyValue()
        {
            return tb_value.Text;
        }

        public override void DoSetFilterInfo(FilterEntity entity)
        {
            base.DoSetFilterInfo(entity);

        }
    }
}
