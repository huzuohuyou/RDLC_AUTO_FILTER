using Framework.Win.Base;
using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Infrastructure;
using InhospitalIndicators.Service.ValueObject;
using InhospitalIndicators.Service.Views.FilterItems.Interfaces;
using InhospitalIndicators.Service.Views.Interfaces;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InhospitalIndicators.Service.Views
{
    public  partial class BaseFilterForm : PageForm, ICanLoadFilter, ICanExportParam
    {
        public IBaseReportService service;

        public string ReportDataSourceName="DataSet1";

        public string FileName;

        public BaseFilterForm()
        {
            InitializeComponent();

            //ReportDataSourceName = sourceName;
            //fileName = FileName;

            var list =  readFilters();
            AddFilterControls(list);
        }

        public void AddFilterControls(List<FilterEntity> list)
        {
            var index = 0;
            var yIndex = 0;
            list.ForEach(r =>
            {

                var c = FilterHelper.Convert(r);
                c.Top = yIndex * 40+5;
                c.Left = 280*index+ 15;
                (c as ICanSetGetFilterInfo).SetFilterInfo(r);
                panel_filter.Controls.Add(c);
                index++;
                if (index%3==0&&index!=0)
                {
                    yIndex++;
                    index = 0;
                }
            });

        }



        public virtual List<FilterEntity> readFilters()
        {
            //throw new Exception("未配置过滤条件");
            return new List<FilterEntity>();
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        protected byte[] AuthGetFileData(string fileUrl)
        {
            using (FileStream fs = new FileStream(fileUrl, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] buffur = new byte[fs.Length];
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(buffur);
                    bw.Close();
                }
                return buffur;
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            Stream ms = new MemoryStream(AuthGetFileData($@"{Environment.CurrentDirectory}/Reports/{FileName}.rdlc" ));
            reportViewer2.LocalReport.LoadReportDefinition(ms);
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = ReportDataSourceName;
            Task<DataTable> t = service.DoTable();

            t.Wait();
            reportDataSource.Value = t.Result;
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(reportDataSource);
            reportViewer2.LocalReport.Refresh();

            reportViewer2.Tag = t.Result;
            reportViewer2.RefreshReport();
        }

        private void BaseFilterForm_Load(object sender, EventArgs e)
        {
            if (Controls.Count==0)
            {

            }
        }

        public string DoExport()
        {
            var filters = new List<FilterValueObject>();
            foreach (var item in panel_filter.Controls)
            {
                filters.Add((item as ICanGetFilter).GetFilter());
            }

            return JsonConvert.SerializeObject(filters); 
            
        }

        private void btn_filter_setting_Click(object sender, EventArgs e)
        {
            new FrmFilterSetting().ShowDialog();
        }
    }
}
