using InhospitalIndicators.Service.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Views.FilterItems.Interfaces
{
    public interface ICanSetFilterInfo
    {
        void DoSetFilterInfo(FilterEntity entity);
    }
}
