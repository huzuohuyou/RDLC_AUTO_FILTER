using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;

namespace InhospitalIndicators.Service.Views.FilterItems.Interfaces
{
    public interface ICanGetFilter
    {
        FilterValueObject GetFilter();
    }
}
