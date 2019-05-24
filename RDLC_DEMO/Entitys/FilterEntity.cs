using InhospitalIndicators.Service.ValueObject;
using System.Collections.Generic;

namespace InhospitalIndicators.Service.Entitys
{

    public class FilterEntity
    {
        public FilterEntity(decimal orderNo, string paramLabel, string paramName, EnumDataType dataType, EnumControlType control)
        {
            OrderNo = orderNo;
            ParamName = paramName;
            ParamLabel = paramLabel;
            DataType = dataType;
            ControlType = control;
        }

        public decimal OrderNo { get; set; }

        public string ParamLabel { get; set; }

        public string ParamName { get; set; }

        public EnumDataType DataType { get; set; }

        public EnumControlType ControlType { get; set; }

        public List<ListItem> Items { get; set; }

      
    }
}
