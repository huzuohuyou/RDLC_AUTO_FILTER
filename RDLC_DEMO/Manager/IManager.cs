using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Services.CurrentPeriod
{
    interface IManager<T>
    {
        Tuple<string, List<T>> GetData();
    }
}
