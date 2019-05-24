using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using Newtonsoft.Json;

namespace InhospitalIndicators.Service.Views
{
    internal class Demo : BaseFilterForm
    {
        public Demo() 
        { }

        public override List<FilterEntity> readFilters()
        {
            var json = JsonConvert.SerializeObject(new List<FilterEntity>
            {
               
                new FilterEntity(1,"开始日期1：","name",EnumDataType._String,EnumControlType._DateTimepicker),
                new FilterEntity(1,"结束日期1：","name",EnumDataType._String,EnumControlType._DateTimepicker),
                new FilterEntity(1,"开始日期2：","name",EnumDataType._String,EnumControlType._DateTimepicker),
                new FilterEntity(1,"结束日期2：","name",EnumDataType._String,EnumControlType._DateTimepicker),
                 new FilterEntity(1,"姓名：","name",EnumDataType._String,EnumControlType._TextBox),
            });
            return JsonConvert.DeserializeObject<List<FilterEntity>>(json); ;
        }
    }
}
