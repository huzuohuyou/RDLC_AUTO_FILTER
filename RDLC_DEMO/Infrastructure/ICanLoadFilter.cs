using InhospitalIndicators.Service.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Infrastructure
{
    interface ICanLoadFilter
    {
        void AddFilterControls(List<FilterEntity> list);
    }
}
