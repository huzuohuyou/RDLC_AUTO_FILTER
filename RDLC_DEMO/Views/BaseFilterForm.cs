﻿using Framework.Win.Base;
using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Infrastructure;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InhospitalIndicators.Service.Views
{
    public  partial class BaseFilterForm : PageForm, ICanLoadFilter
    {
        private IBaseReportService service;

        private string ReportDataSourceName;

        private string FileName;

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
                var l = new Label();
                l.Text = $@"{r.ParamLabel}";
                l.Top = yIndex*40+15;
                l.Left = index * 240 + 20;
                l.Width = 80;
                l.BackColor = Color.FromArgb(153,106,214);

                var c = FilterHelper.Convert(r);
                c.Top = yIndex * 40+15;
                c.Left = l.Left+ 80;
                c.Width = 140;
                c.BackColor = Color.Azure;
                panel_filter.Controls.Add(l);
                panel_filter.Controls.Add(c);
                index++;
                if (index%4==0&&index!=0)
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
    }
}