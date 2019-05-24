using System;

namespace InhospitalIndicators.Service.Entitys
{

    class FeeItem
    {
        private string _fee;
        /// <summary>
        /// 万元单位
        /// </summary>
        public string Fee {
            get
            {
                var _value = 0.0d;
                if (_fee == null || !double.TryParse(_fee, out _value))
                {
                    return "0";
                }
                return (double.Parse(_fee)).ToString();
            }
            set
            {
                _fee = value;
            }
        }

        public string Project { get; set; }

        public string Sugbe { get; set; }

        public string Age { get; set; }

        public string Nu { get; set; }

        public string Count { get; set; }

        public int NuValue { get {
                return int.Parse(Nu);
            } }
    }
}
