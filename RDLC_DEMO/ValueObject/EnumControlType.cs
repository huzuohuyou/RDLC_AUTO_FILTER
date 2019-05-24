using System.ComponentModel;

namespace InhospitalIndicators.Service.ValueObject
{

    public enum EnumControlType
    {
        [Description("下拉框")]
        _Combox,
        [Description("单选框")]
        _RadioButton,
        [Description("日期框")]
        _DateTimepicker,
        [Description("文本框")]
        _TextBox,
        [Description("数字框")]
        _NumBox,
    }
}
