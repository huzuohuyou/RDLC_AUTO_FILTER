using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Entitys
{
    /// <summary>
    /// 收入同期比实体
    /// </summary>
    public class SamePeriodIncomRatio
    {
        private string SumCurrent { get; set; }

        private string SumPeriod { get; set; }

        public Double OrderNo { get; set; }

        public SamePeriodIncomRatio() { }

        public SamePeriodIncomRatio(string _SumCurrent, string _SumPeriod)
        {
            SumCurrent = _SumCurrent;
            SumPeriod = _SumPeriod;
        }

        public string Project { get; set; }

        private string _current;

        public string Current
        {
            get
            {
                if (Project.Contains("指标分析"))
                {
                    return "--";
                }
                var _value = 0.0d;
                if (_current == null || !double.TryParse(_current, out _value))
                {
                    return "0";
                }
                else if(Project.Contains("占比"))
                {
                    double.TryParse(_current, out _value);
                    return Math.Round(_value * 100, 2).ToString();
                }
                return _current;
            }
            set
            {
                _current = value;
            }
        }

        public string _period;

        public string Period {
            get
            {
                if (Project.Contains("指标分析"))
                {
                    return "--";
                }
                var _value = 0.0d;
                if (_period == null || !double.TryParse(_period, out _value))
                {
                    return "0";
                }
                else if (Project.Contains("占比"))
                {
                    double.TryParse(_period, out _value);
                    return Math.Round(_value * 100, 2).ToString();
                }
                return _period;
            }
            set
            {
                _period = value;
            }
        }

        private string _changeRate;

        public string ChangeRate
        {
            get
            {
                if (Project.Contains("指标分析"))
                {
                    return "--";
                }
                var value1 = 0.0d;
                var ok1 = double.TryParse(Current, out value1);
                var value2 = 0.0d;
                var ok2 = double.TryParse(Period, out value2);
                if (ok1 && ok2)
                {
                    return (Math.Round( value1 - value2,2)).ToString();
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
                    return Math.Round((value1 *100/ value2),2).ToString();
                }

                return "-";
            }
        }

        public string Weight_2019
        {
            get
            {
                if (Project.Contains("指标分析"))
                {
                    return "--";
                }
                var value1 = 0.0d;
                var ok1 = double.TryParse(Current, out value1);
                var value2 = 0.0d;
                var ok2 = double.TryParse(SumCurrent, out value2);
                if (ok1 && ok2 && value2 != 0)
                {
                    return Math.Round((value1 / value2),2).ToString();
                }

                return "-";
            }
        }

        public string Weight_2018
        {
            get
            {
                if (Project.Contains("指标分析"))
                {
                    return "--";
                }
                var value1 = 0.0d;
                var ok1 = double.TryParse(Period, out value1);
                var value2 = 0.0d;
                var ok2 = double.TryParse(SumPeriod, out value2);
                if (ok1 && ok2 && value2 != 0)
                {
                    return Math.Round((value1 / value2),2).ToString();
                }

                return "-";
            }
        }

        public string WeightChange
        {
            get
            {
                if (Project.Contains("指标分析"))
                {
                    return "--";
                }
                var value1 = 0.0d;
                var ok1 = double.TryParse(Weight_2019, out value1);
                var value2 = 0.0d;
                var ok2 = double.TryParse(Weight_2018, out value2);
                if (ok2 && ok1)
                {
                    return (Math.Round( value1 - value2,2)).ToString();
                }
                return "-";
            }
        }


    }




  
}
