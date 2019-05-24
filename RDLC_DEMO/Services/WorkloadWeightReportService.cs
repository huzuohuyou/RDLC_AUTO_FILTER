using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Manager.WorkloadWeight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InhospitalIndicators.Service.Services
{
    /// <summary>
    ///     表9：检验科－工作量变化及权重（本部）
    /// </summary>
    class WorkloadWeightReportService : BaseReportService<WorkloadChangeandWeight>
    {
        public WorkloadWeightReportService(string _flag, string _currentStart, string _currentEnd, string _periodStart, string _periodEnd)
            : base(_flag, _currentStart, _currentEnd, _periodStart, _periodEnd)
        {
            //flag = _flag;
            //currentStart = _currentStart;
            //currentEnd = _currentEnd;
            //periodStart = _periodStart;
            //periodEnd = _periodEnd;
        }

        public override List<WorkloadChangeandWeight> Do()
        {
            try
            {
                List<FeeItem> items = null;
                if (flag == "all")
                {
                    items = new AllItem()
                    {
                        CurrentStart = currentStart,
                        CurrentEnd = currentEnd,
                        PeriodStart = periodStart,
                        PeriodEnd = periodEnd,
                    }.GetData();
                }
                else if (flag == "in")
                {
                    items = new InItem()
                    {
                        CurrentStart = currentStart,
                        CurrentEnd = currentEnd,
                        PeriodStart = periodStart,
                        PeriodEnd = periodEnd,
                    }.GetData();
                }
                else if (flag == "out")
                {
                    items = new OutItem()
                    {
                        CurrentStart = currentStart,
                        CurrentEnd = currentEnd,
                        PeriodStart = periodStart,
                        PeriodEnd = periodEnd,
                    }.GetData();
                }
                var sumCurrentCount = items?.Where(r => r?.Age == "当期")?.Sum(r => r?.Count.ToDouble()).ToString();
                var sumCurrentFee = items?.Where(r => r?.Age == "当期")?.Sum(r => r?.Fee.ToDouble()).ToString();
                var sumPeriodCount = items?.Where(r => r?.Age == "同期")?.Sum(r => r?.Count.ToDouble()).ToString();
                var sumPeriodFee = items?.Where(r => r?.Age == "同期")?.Sum(r => r?.Fee.ToDouble()).ToString();
               
                var list = new List<WorkloadChangeandWeight>();
                var projects=items.Select(r => r.Project).Distinct().ToList();
                projects.ForEach(r =>
                {
                    list.Add(new WorkloadChangeandWeight(sumCurrentCount, sumCurrentFee, sumPeriodCount, sumPeriodFee)
                    {
                        Project = r,
                        CurrentFee = items?.FirstOrDefault(s =>s.Project==r&& s.Age == "当期")?.Fee,
                        PeriodFee = items?.FirstOrDefault(s => s.Project == r && s.Age == "同期")?.Fee,
                        CurrentWorkload= items?.FirstOrDefault(s => s.Project == r && s.Age == "当期")?.Count,
                        PeriodWorkload = items?.FirstOrDefault(s => s.Project == r && s.Age == "同期")?.Count,
                    });
                });
                list.Insert(0,new WorkloadChangeandWeight(sumCurrentCount, sumCurrentFee, sumPeriodCount, sumPeriodFee)
                {
                    Project= "检验科—总计",
                    CurrentFee= sumCurrentFee,
                    PeriodFee= sumPeriodFee,
                    CurrentWorkload= sumCurrentCount,
                    PeriodWorkload= sumPeriodCount
                });
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
