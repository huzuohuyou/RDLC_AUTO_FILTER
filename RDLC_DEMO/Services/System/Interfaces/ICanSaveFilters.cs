using InhospitalIndicators.Service.Entitys;
using System.Collections.Generic;

namespace InhospitalIndicators.Service.Services.System.Interfaces
{

    public interface ICanSaveFilters
    {
        void SaveFilter(List<FilterEntity> list, string fileName);
    }
}
