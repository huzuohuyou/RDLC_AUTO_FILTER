using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Services.CurrentPeriod;
using InhospitalIndicators.Service.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace InhospitalIndicators.Service
{
    /// <summary>
    /// 同期费用比
    /// </summary>
    public class SameReriodIncomeReportService: BaseReportService<SamePeriodIncomRatio>
    {
       

        public SameReriodIncomeReportService(string _flag, string _currentStart, string _currentEnd, string _periodStart, string _periodEnd)
            :base(_flag,_currentStart,_currentEnd,_periodStart,_periodEnd)
        {
            //flag = _flag;
            //currentStart = _currentStart;
            //currentEnd = _currentEnd;
            //periodStart = _periodStart;
            //periodEnd = _periodEnd;
        }

        public override List<SamePeriodIncomRatio> Do()
        {
            try
            {
                List<FeeItem> items = null;
                if (flag=="all")
                {
                    items = new AllItem() {
                        CurrentStart=currentStart,
                        CurrentEnd=currentEnd,
                        PeriodStart=periodStart,
                        PeriodEnd= periodEnd,
                    }.GetData();
                }
                else if (flag=="in")
                {
                    items = new InItem()
                    {
                        CurrentStart = currentStart,
                        CurrentEnd = currentEnd,
                        PeriodStart = periodStart,
                        PeriodEnd = periodEnd,
                    }.GetData();
                }
                else if (flag=="out")
                {
                    items = new OutItem()
                    {
                        CurrentStart = currentStart,
                        CurrentEnd = currentEnd,
                        PeriodStart = periodStart,
                        PeriodEnd = periodEnd,
                    }.GetData();
                }

                var sumCurrent = items?.Where(r => r?.Age == "当期")?.Sum(r => r?.Fee.ToDouble()).ToString().ToDouble().ToString();
                var sumPeriod = items?.Where(r => r?.Age == "同期")?.Sum(r => r?.Fee.ToDouble()).ToString().ToDouble().ToString();
                var sumCurrentDrug = items?.Where(r =>
                         (r?.Project == SPI_PROJECT.CHINESE_PATENT_MEDICINE_FEE
                         || r?.Project == SPI_PROJECT.CHINESE_HERBAL_MEDICINE_FEE
                         || r?.Project == SPI_PROJECT.WESTERN_MEDICINE_FEE)
                         && r?.Age == "当期").Sum(r => r?.Fee.ToDouble()).ToString().ToDouble().ToString();
                var sumPeriodDrug = items.Where(r =>
                        (r?.Project == SPI_PROJECT.CHINESE_PATENT_MEDICINE_FEE
                        || r?.Project == SPI_PROJECT.CHINESE_HERBAL_MEDICINE_FEE
                        || r?.Project == SPI_PROJECT.WESTERN_MEDICINE_FEE)
                        && r?.Age == "同期").Sum(r => r?.Fee.ToDouble()).ToString().ToDouble().ToString();

                var a = items.Where(r => r?.Project == SPI_PROJECT.WESTERN_MEDICINE_FEE && r?.Sugbe == "1" && r?.Age == "当期")?.FirstOrDefault()?.Fee;
                var list = new List<SamePeriodIncomRatio> {
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=0.9,
                    Project="住院收入",
                    Current=sumCurrent,
                    Period=sumPeriod,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=0.91,
                    Project="医疗收入",
                    Current=(sumCurrent.ToDouble()-sumCurrentDrug.ToDouble()).ToString(),
                    Period=(sumPeriod.ToDouble()-sumPeriodDrug.ToDouble()).ToString(),
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=1,
                    Project="  床位收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.BED_FEE&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.BED_FEE&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=2,
                    Project="  医事服务费",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.MEDICAL_FEES&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.MEDICAL_FEES&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=3,
                    Project="  检查收入",
                    Current=items.Where(r=>(r?.Project==SPI_PROJECT.ROUTINE_INSPECTION_FEE
                    ||r?.Project=="CT"
                    ||r?.Project==SPI_PROJECT.RADIATION
                    ||r?.Project==SPI_PROJECT.MAGNETIC_RESONANCE)&&r?.Sugbe=="1"&& r?.Age=="当期").Sum(r=>r?.Fee.ToDouble()).ToString(),
                    Period=items.Where(r=>(r?.Project==SPI_PROJECT.ROUTINE_INSPECTION_FEE
                    ||r?.Project=="CT"
                    ||r?.Project==SPI_PROJECT.RADIATION
                    ||r?.Project==SPI_PROJECT.MAGNETIC_RESONANCE)&&r?.Sugbe=="1"&& r?.Age=="同期").Sum(r=>r?.Fee.ToDouble()).ToString(),
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=4,
                    Project="    其中：放射",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.RADIATION&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.RADIATION&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=5,
                    Project="  化验收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.LAB_FEES&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.LAB_FEES&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=6,
                    Project="  病理收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.PATHOLOGY&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.PATHOLOGY&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=7,
                    Project="  治疗收入",
                    Current=items.Where(r=>(r?.Project==SPI_PROJECT.TREATMENT_COSTS
                    ||r?.Project==SPI_PROJECT.HYPERBARIC_OXYGEN_FEE
                    ||r?.Project==SPI_PROJECT.HEMODIALYSIS
                    ||r?.Project==SPI_PROJECT.BLOOD_TRANSFUSION_FEE
                    ||r?.Project==SPI_PROJECT.OXYGEN_DELIVERY_FEE)&&r?.Sugbe=="1"&& r?.Age=="当期").Sum(r=>r?.Fee.ToDouble()).ToString(),
                    Period=items.Where(r=>(r?.Project==SPI_PROJECT.TREATMENT_COSTS
                    ||r?.Project==SPI_PROJECT.HYPERBARIC_OXYGEN_FEE
                    ||r?.Project==SPI_PROJECT.HEMODIALYSIS
                    ||r?.Project==SPI_PROJECT.BLOOD_TRANSFUSION_FEE
                    ||r?.Project==SPI_PROJECT.OXYGEN_DELIVERY_FEE)&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=8,
                    Project="  手术收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.SURGERY_FEE&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.SURGERY_FEE&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=9,
                    Project="  护理收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.NURSING_FEE&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.NURSING_FEE&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=10,
                    Project="  卫生材料收入",
                    Current=items.Where(r=>r.NuValue<19&& r?.Sugbe=="0"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r.NuValue<19&& r?.Sugbe=="0"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=11,
                    Project="  其他住院收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.OTHER_EXPENSES&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.OTHER_EXPENSES&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=12,
                    Project="药品收入",
                    Current=sumCurrentDrug,
                    Period=sumPeriodDrug,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=13,
                    Project="  其中：西药收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.WESTERN_MEDICINE_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.WESTERN_MEDICINE_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=14,
                    Project="    中草药收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.CHINESE_HERBAL_MEDICINE_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.CHINESE_HERBAL_MEDICINE_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=15,
                    Project="    中成药收入",
                    Current=items.Where(r=>r?.Project==SPI_PROJECT.CHINESE_PATENT_MEDICINE_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==SPI_PROJECT.CHINESE_PATENT_MEDICINE_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=17,
                    Project="    —指标分析—",
                    Current="——",
                    Period="——",
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=17.1,
                    Project="药占比",
                    Current=(sumCurrentDrug.ToDouble()
                    /sumCurrent.ToDouble()).ToString(),
                    Period=(sumPeriodDrug.ToDouble()
                    /sumPeriod.ToDouble()).ToString(),
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=18,
                    Project="药占比(不含饮片)",
                    Current=((sumCurrentDrug.ToDouble()
                    -items.Where(r=>r?.Project==SPI_PROJECT.CHINESE_HERBAL_MEDICINE_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee.ToDouble())
                    /sumCurrent.ToDouble()).ToString(),
                    Period=((sumPeriodDrug.ToDouble()
                    -items.Where(r=>r?.Project==SPI_PROJECT.CHINESE_HERBAL_MEDICINE_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee.ToDouble())
                    /sumPeriod.ToDouble()).ToString(),
                },
                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=19,
                    Project="医务性收入占比",
                    Current=((
                    sumCurrent.ToDouble()
                    -items.Where(r=>r.NuValue<19&&r?.Sugbe=="0"&& r?.Age=="当期")?.FirstOrDefault()?.Fee.ToDouble()
                    -sumCurrentDrug.ToDouble()
                    -items.Where(r=>r?.Project==SPI_PROJECT.OTHER_EXPENSES&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee.ToDouble())
                    /sumCurrent.ToDouble()).ToString(),
                    Period=((
                    sumPeriod.ToDouble()
                    -items.Where(r=>r.NuValue<19&&r?.Sugbe=="0"&& r?.Age=="同期")?.FirstOrDefault()?.Fee.ToDouble()
                    -sumPeriodDrug.ToDouble()
                    -items.Where(r=>r?.Project==SPI_PROJECT.OTHER_EXPENSES&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee.ToDouble())
                    /sumPeriod.ToDouble()).ToString(),
                },

                new SamePeriodIncomRatio(sumCurrent,sumPeriod){
                    OrderNo=20,
                    Project="医疗服务收入占比",
                    Current=((
                    sumCurrent.ToDouble()
                    -items.Where(r=>r.NuValue<19&&r?.Sugbe=="0"&& r?.Age=="当期")?.FirstOrDefault()?.Fee.ToDouble()
                    -sumCurrentDrug.ToDouble()
                    -items.Where(r=>r?.Project==SPI_PROJECT.OTHER_EXPENSES&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee.ToDouble()
                    -items.Where(r=>(r?.Project==SPI_PROJECT.ROUTINE_INSPECTION_FEE
                    ||r?.Project=="CT"
                    ||r?.Project==SPI_PROJECT.RADIATION
                    ||r?.Project==SPI_PROJECT.MAGNETIC_RESONANCE)&&r?.Sugbe=="1"&& r?.Age=="当期").Sum(r=>r?.Fee.ToDouble()).ToString().ToDouble()
                    -items.Where(r=>r?.Project==SPI_PROJECT.LAB_FEES&&r?.Sugbe=="1"&& r?.Age=="当期")?.FirstOrDefault()?.Fee.ToDouble())
                    /sumCurrent.ToDouble()).ToString(),
                    Period=((
                    sumPeriod.ToDouble()
                    -items.Where(r=>r.NuValue<19&&r?.Sugbe=="0"&& r?.Age=="同期")?.FirstOrDefault()?.Fee.ToDouble()
                    -sumPeriodDrug.ToDouble()
                    -items.Where(r=>r?.Project==SPI_PROJECT.OTHER_EXPENSES&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee.ToDouble()
                    -items.Where(r=>(r?.Project==SPI_PROJECT.ROUTINE_INSPECTION_FEE
                    ||r?.Project=="CT"
                    ||r?.Project==SPI_PROJECT.RADIATION
                    ||r?.Project==SPI_PROJECT.MAGNETIC_RESONANCE)&&r?.Sugbe=="1"&& r?.Age=="同期").Sum(r=>r?.Fee.ToDouble()).ToString().ToDouble()
                    -items.Where(r=>r?.Project==SPI_PROJECT.LAB_FEES&&r?.Sugbe=="1"&& r?.Age=="同期")?.FirstOrDefault()?.Fee.ToDouble())
                    /sumPeriod.ToDouble()).ToString(),
                },
            };
                //list.Sort((a, b) => a.OrderNo.CompareTo(b.OrderNo));
                //var table = ToDataTable(list);

                
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       


        
    }
}
