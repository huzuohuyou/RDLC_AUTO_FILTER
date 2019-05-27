using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;
using InhospitalIndicators.Service.Entitys;

namespace InhospitalIndicators.Service.Views.FilterItems
{
    public partial class UcBaseFilter : UserControl, ICanSetFilterInfo
    {
        public string ParamName { get; set; }

        public decimal OrderNo  { get; set; }

        public UcBaseFilter()
        {
            InitializeComponent();
        }

        public virtual void DoSetFilterInfo(FilterEntity entity)
        {
            lb_text.Text = entity.ParamLabel;
            ParamName = entity.ParamName;
            OrderNo = entity.OrderNo;
        }
    }
}
