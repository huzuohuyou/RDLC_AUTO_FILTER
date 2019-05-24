using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace InhospitalIndicators.Service.Views
{
    public partial class ucFilter : UserControl, IamUc
    {
        public FilterEntity Item { get {
                return new FilterEntity(
                    numericUpDown1.Value,
                    textBox1.Text,
                    textBox2.Text,
                    (EnumDataType)comboBox1.SelectedValue,
                    (EnumControlType)comboBox2.SelectedValue
                    );
            } }

        private static string GetEnumDesc(Enum e)
        {
            FieldInfo EnumInfo = e.GetType().GetField(e.ToString());
            DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])EnumInfo.
              GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (EnumAttributes.Length > 0)
            {
                return EnumAttributes[0].Description;
            }
            return e.ToString();
        }

        private static IList ToList(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (!type.IsEnum) throw new ArgumentException("Type provided must be an Enum.", "type");

            ArrayList list = new ArrayList();
            Array array = Enum.GetValues(type);
            foreach (Enum value in array)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetEnumDesc(value)));
            }
            return list;
        }

        public static void BindComboxToDataEnumer(ComboBox cb,Type t)
        {
            //Type t = typeof(EnumControlType);
            IList list = ToList(t);
            cb.DataSource = list;
            cb.DisplayMember = "Value";
            cb.ValueMember = "Key";
        }




        ICanAddRemoveUc Parient;

        public ucFilter(ICanAddRemoveUc parient)
        {
            InitializeComponent();
            Parient = parient;
        }

        

        private void btn_add_Click(object sender, EventArgs e)
        {
            Parient.DoAdd(new ucFilter(Parient));
        }

        private void ucFilter_Load(object sender, EventArgs e)
        {
            BindComboxToDataEnumer(comboBox1,typeof(EnumDataType));
            BindComboxToDataEnumer(comboBox2, typeof(EnumControlType));
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            Parient.DoRemove(this);
        }
    }
}
