using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service
{

    public abstract class BaseReportService<T>: IBaseReportService
    {
        public BaseReportService(string _flag, string _currentStart, string _currentEnd, string _periodStart, string _periodEnd)
        {
            flag = _flag;
            currentStart = _currentStart;
            currentEnd = _currentEnd;
            periodStart = _periodStart;
            periodEnd = _periodEnd;
        }

        public string flag { get; set; }
        public string currentStart { get; set; }
        public string currentEnd { get; set; }
        public string periodStart { get; set; }
        public string periodEnd { get; set; }

        public abstract List<T> Do();

        public async Task<DataTable> DoTable()
        {
            var list = Do();
            var table = ToDataTable(Do());


            return table;
        }

        public DataTable ToDataTable(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        public Type GetCoreType(Type t)
        {
            if (t != null)
            {
                return t;
            }
            else
            {
                return t;
            }
        }
    }
}
