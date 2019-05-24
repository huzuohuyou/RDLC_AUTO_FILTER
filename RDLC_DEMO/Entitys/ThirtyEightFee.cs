using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Entitys
{

    public class ThirtyEightFee
    {
        public string Project { get; set; }

        public string Current { get; set; }

        public string Period { get; set; }

        private string _changeRate;

        public string ChangeRate
        {
            get
            {
                
                var value1 = 0.0d;
                var ok1 = double.TryParse(Current, out value1);
                var value2 = 0.0d;
                var ok2 = double.TryParse(Period, out value2);
                if (ok1 && ok2)
                {
                    return (Math.Round(value1 - value2, 2)).ToString();
                }

                return "-";
            }
        }

        private string _variationAmount;

        public string VariationAmount
        {
            get
            {
                if (Project.Contains("指标分析"))
                {
                    return "--";
                }
                var value1 = 0.0d;
                var ok1 = double.TryParse(ChangeRate, out value1);
                var value2 = 0.0d;
                var ok2 = double.TryParse(Period, out value2);
                if (ok1 && ok2 && value2 != 0)
                {
                    return Math.Round((value1 * 100 / value2), 2).ToString();
                }

                return "-";
            }
        }
    }
}
