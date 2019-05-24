using Framework.Win.Base;
using InhospitalIndicators.Service.Services;
using InhospitalIndicators.Service.Views;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InhospitalIndicators.Service
{
    public partial class MainForm : PageForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer2.RefreshReport();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text=="同期费用比")
            {
                var flag = rb_all.Checked ? "all" : (rb_in.Checked ? "in" : (rb_out.Checked ? "out" : null));
                Stream ms = new MemoryStream(Properties.Resources.CurrentPeriod);
                reportViewer2.LocalReport.LoadReportDefinition(ms);
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";


                Task<DataTable> t = new SameReriodIncomeReportService(
                    flag
                    , dtp_current_start.Value.Date.ToShortDateString()
                    , dtp_current_end.Value.Date.ToShortDateString()
                    , dtp_period_start.Value.Date.ToShortDateString()
                    , dtp_period_end.Value.Date.ToShortDateString()).DoTable();

                t.Wait();
                reportDataSource.Value = t.Result;
                reportViewer2.LocalReport.DataSources.Clear();
                reportViewer2.LocalReport.DataSources.Add(reportDataSource);
                reportViewer2.LocalReport.Refresh();

                reportViewer2.Tag = t.Result;
                reportViewer2.RefreshReport();
            }
            if (tabControl1.SelectedTab.Text == "38项费用") {
                button1_Click_1(sender,e);
            }
            if (tabControl1.SelectedTab.Text == "检验项目比")
            {
                button2_Click(sender, e);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var flag = radioButton2.Checked ? "all" : (radioButton3.Checked ? "out" : (radioButton1.Checked ? "in" : null));
            Stream ms = new MemoryStream(Properties.Resources.ThirtyEight);
            reportViewer1.LocalReport.LoadReportDefinition(ms);
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "ThirtyEight2";


            Task<DataTable> t = new ThirtyEightFeeReportService(flag
                , dateTimePicker2.Value.Date.ToShortDateString()
                , dateTimePicker1.Value.Date.ToShortDateString()
                , dateTimePicker4.Value.Date.ToShortDateString()
                , dateTimePicker3.Value.Date.ToShortDateString()).DoTable();

            t.Wait();
            reportDataSource.Value = t.Result;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.Refresh();

            reportViewer1.Tag = t.Result;
            reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var flag = radioButton5.Checked ? "all" 
                : (radioButton6.Checked ? "in" 
                : (radioButton4.Checked ? "out" : null));
            Stream ms = new MemoryStream(Properties.Resources.WorkloadChangeandWeight);
            reportViewer3.LocalReport.LoadReportDefinition(ms);
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";


            Task<DataTable> t = new WorkloadWeightReportService(flag
                , dateTimePicker6.Value.Date.ToShortDateString()
                , dateTimePicker5.Value.Date.ToShortDateString()
                , dateTimePicker8.Value.Date.ToShortDateString()
                , dateTimePicker7.Value.Date.ToShortDateString()).DoTable();

            t.Wait();
            reportDataSource.Value = t.Result;
            reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.DataSources.Add(reportDataSource);
            reportViewer3.LocalReport.Refresh();

            reportViewer3.Tag = t.Result;
            reportViewer3.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Demo().Show();
        }
    }
}
