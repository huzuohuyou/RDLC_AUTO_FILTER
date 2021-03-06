﻿using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.FilterItems;
using System.Windows.Forms;

namespace InhospitalIndicators.Service.Infrastructure
{

    public static class FilterHelper
    {
        public static Control Convert(FilterEntity filter)
        {

            if (filter.ControlType == EnumControlType._TextBox)
            {
                //var c= new TextBox();
                return new UcTextBox();
            }
            else if (filter.ControlType == EnumControlType._NumBox)
            {
                var c = new NumericUpDown();
                return c;
            }
            else if (filter.ControlType == EnumControlType._DateTimepicker)
            {
                var c = new DateTimePicker();
                c.Format = DateTimePickerFormat.Custom;
                c.CustomFormat= "yyyy-MM-dd";
                return new UcDateTimePicker();
            }
            else if (filter.ControlType == EnumControlType._Combox)
            {
                var c = new ComboBox();
                c.DataSource = filter.Items;
                c.DisplayMember = "key";
                c.ValueMember = "value";
                
                return new UcComBox();
            }
            else if (filter.ControlType == EnumControlType._RadioButton)
            {
                var c = new RadioButton();
                c.Text = filter.ParamLabel;
                return c;
            }
            return null;

        }
    }
}
