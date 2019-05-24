using InhospitalIndicators.Service.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace InhospitalIndicators.Service.Manager.WorkloadWeight
{

    class AllItem : BaseManager<FeeItem>
    {
        public override List<FeeItem> GetData()
        {
            return new InItem
            {
                CurrentStart = CurrentStart,
                CurrentEnd = CurrentStart,
                PeriodStart = CurrentStart,
                PeriodEnd = CurrentStart,
            }.GetData().Union(new OutItem
            {
                CurrentStart = CurrentStart,
                CurrentEnd = CurrentStart,
                PeriodStart = CurrentStart,
                PeriodEnd = CurrentStart,
            }.GetData()).ToList();
        }
    }
}
