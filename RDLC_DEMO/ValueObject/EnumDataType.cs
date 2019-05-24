using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.ValueObject
{

    public enum EnumDataType
    {
        [Description("整型")]
        _Int=1,
        [Description("布尔")]
        _Bool=2,
        [Description("字符串")]
        _String=3,
        [Description("日期")]
        _DateTime=4,
    }
}
