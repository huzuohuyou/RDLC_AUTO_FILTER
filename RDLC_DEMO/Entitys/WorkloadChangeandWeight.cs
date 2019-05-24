using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Entitys
{

    public class WorkloadChangeandWeight
    {
        public string Project { get; set; }

        private string sumCurrentWorkload { get; set; }

        private string sumCurrentFee { get; set; }

        private string sumPeriodWorkload { get; set; }

        private string sumPeriodFee { get; set; }

        public WorkloadChangeandWeight(string _sumWorkload, string _sumFee,string _sumPeriodWorkload,string _sumPeriodFee)
        {
            sumCurrentFee = _sumFee;
            sumCurrentWorkload = _sumWorkload;
            sumPeriodWorkload = _sumPeriodWorkload;
            sumPeriodFee = _sumPeriodFee;
        }

        /// <summary>
        /// 当期工作量
        /// </summary>
        public string CurrentWorkload { get; set; }

        /// <summary>
        /// 当期占比
        /// </summary>
        public string CurrentProportion
        {
            get
            {
                var value1 = CurrentWorkload.ToDouble();
                var value2 = sumCurrentWorkload.ToDouble();
                if (value2 != 0)
                    return Math.Round((value1 * 100 / value2), 2).ToString();
                return "-";
            }
        }

        /// <summary>
        /// 当期金额
        /// </summary>
        public string CurrentFee { get; set; }

        /// <summary>
        /// 当期权重
        /// </summary>
        public string CurrentWeight {
            get
            {
                var value1 = CurrentFee.ToDouble();
                var value2 = sumCurrentFee.ToDouble();
                if ( value2 != 0)
                    return Math.Round((value1 * 100 / value2), 2).ToString();
                return "-";
            }
        }

        /// <summary>
        /// 同期工作量
        /// </summary>
        public string PeriodWorkload { get; set; }

        /// <summary>
        /// 同期占比
        /// </summary>
        public string PeriodProportion
        {
            get
            {
                var value1 = PeriodWorkload.ToDouble();
                var value2 = sumPeriodWorkload.ToDouble();
                if (value2 != 0)
                    return Math.Round((value1 * 100 / value2), 2).ToString();
                return "-";
            }
        }

        /// <summary>
        /// 同期金额
        /// </summary>
        public string PeriodFee { get; set; }

        /// <summary>
        /// 同期权重
        /// </summary>
        public string PeriodWeight
        {
            get
            {
                var value1 = PeriodFee.ToDouble();
                var value2 = sumPeriodFee.ToDouble();
                if(value2 != 0)
                    return Math.Round((value1 * 100 / value2), 2).ToString();
                return "-";
            }
        }

        /// <summary>
        /// 工作量变化
        /// </summary>
        public string WeightChage
        {
            get
            {
                var value1 = CurrentWorkload.ToDouble();
                var value2 = PeriodWorkload.ToDouble();
                if (value2 != 0)
                    return Math.Round((value1 - value2) / value2, 2).ToString();
                return "-";
            }
        }

        /// <summary>
        /// 金额变化
        /// </summary>
        public string FeeChage
        {
            get
            {
                var value1 = CurrentFee.ToDouble();
                var value2 = PeriodFee.ToDouble();
                var value3 = PeriodWorkload.ToDouble();
                if (value3 != 0)
                    return Math.Round((value1 - value2) / value3, 2).ToString();
                return "-";
            }
        }


    }
}
