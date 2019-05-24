using InhospitalIndicators.Service.Services;
using InhospitalIndicators.Service.Services.CurrentPeriod;
using System;
using System.Collections.Generic;

namespace InhospitalIndicators.Service.Manager
{
    public abstract class BaseManager<T> : DbContext<T>, IManager<T>
    {
        public string CurrentStart { get; set; }
        public string CurrentEnd { get; set; }
        public string PeriodStart { get; set; }
        public string PeriodEnd { get; set; }

        public abstract List<T> GetData();
    }
}
