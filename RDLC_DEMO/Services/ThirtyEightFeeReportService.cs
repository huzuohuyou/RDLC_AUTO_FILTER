using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Manager.ThirtyEightFee;
using InhospitalIndicators.Service.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Services
{
    /// <summary>
    /// 38项费用比
    /// </summary>
    public class ThirtyEightFeeReportService : BaseReportService<ThirtyEightFee>
    {
        public ThirtyEightFeeReportService(string _flag, string _currentStart, string _currentEnd, string _periodStart, string _periodEnd)
            : base(_flag, _currentStart, _currentEnd, _periodStart, _periodEnd)
        {
            //flag = _flag;
            //currentStart = _currentStart;
            //currentEnd = _currentEnd;
            //periodStart = _periodStart;
            //periodEnd = _periodEnd;
        }

        public override List<ThirtyEightFee> Do()
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
                }.GetData().Item2;
            }
            else if (flag == "in")
            {
                items = new InItem()
                {
                    CurrentStart = currentStart,
                    CurrentEnd = currentEnd,
                    PeriodStart = periodStart,
                    PeriodEnd = periodEnd,
                }.GetData().Item2;
            }
            else if (flag == "out")
            {
                items = new OutItem()
                {
                    CurrentStart = currentStart,
                    CurrentEnd = currentEnd,
                    PeriodStart = periodStart,
                    PeriodEnd = periodEnd,
                }.GetData().Item2;
            }
            var list = new List<ThirtyEightFee>
            {
                new ThirtyEightFee{
                    Project="1.诊查费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.EXAMINATION_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.EXAMINATION_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="2.挂号费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.REGISTRATION_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.REGISTRATION_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="3.床位费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.BED_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.BED_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="4.一般治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.GENERAL_TREATMENT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.GENERAL_TREATMENT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="5.护理治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.NURSING_TREATMENT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.NURSING_TREATMENT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="6.监护及辅助呼吸设备费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.MONITORING_AND_ASSISTED_BREATHING_EQUIPMENT_FEES&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.MONITORING_AND_ASSISTED_BREATHING_EQUIPMENT_FEES&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="7.输氧费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.OXYGEN_DELIVERY_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.OXYGEN_DELIVERY_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="8.护理费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.CARE_COSTS&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.CARE_COSTS&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="9.其它费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.OTHER_FEES&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.OTHER_FEES&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="10.病理费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.PATHOLOGY_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.PATHOLOGY_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="11.化验费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.LABORATORY_FEES&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.LABORATORY_FEES&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="12.核素检查费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.RADIONUCLIDE_INSPECTION_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.RADIONUCLIDE_INSPECTION_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="13.超声费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.ULTRASONIC_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.ULTRASONIC_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },


                new ThirtyEightFee{
                    Project="14.放射费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.RADIATION_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.RADIATION_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="15.一般检查费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.GENERAL_INSPECTION_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.GENERAL_INSPECTION_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="16.临床物理治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.CLINICAL_PHYSICAL_THERAPY_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.CLINICAL_PHYSICAL_THERAPY_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="17.核素治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.NUCLIDE_TREATMENT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.NUCLIDE_TREATMENT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="18.特殊治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.SPECIAL_TREATMENT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.SPECIAL_TREATMENT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="19.精神治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.PSYCHIATRIC_TREATMENT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.PSYCHIATRIC_TREATMENT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="20.麻醉费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.ANESTHESIA_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.ANESTHESIA_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="21.手术费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.SURGERY_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.SURGERY_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="22.介入治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.INTERVENTION_COSTS&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.INTERVENTION_COSTS&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="23.接生费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.BIRTH_PAYMENT&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.BIRTH_PAYMENT&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="24.康复治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.REHABILITATION_TREATMENT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.REHABILITATION_TREATMENT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="25.中医治疗费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.CHINESE_MEDICINE_TREATMENT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.CHINESE_MEDICINE_TREATMENT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="26.抗菌药物费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.ANTIBACTERIAL_DRUG_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.ANTIBACTERIAL_DRUG_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="27.西药费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.WESTERN_MEDICINE_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.WESTERN_MEDICINE_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="28.中成药费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.CHINESE_MEDICINE_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.CHINESE_MEDICINE_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="29.中草药费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.CHINESE_HERBAL_MEDICINE_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.CHINESE_HERBAL_MEDICINE_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="30.输血费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.BLOOD_TRANSFUSION_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.BLOOD_TRANSFUSION_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="31.白蛋白类制品费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.ALBUMIN_PRODUCT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.ALBUMIN_PRODUCT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="32.球蛋白类制品费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.GLOBIN_PRODUCT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.GLOBIN_PRODUCT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="33.凝血因子类制品费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.COAGULATION_FACTOR_PRODUCT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.COAGULATION_FACTOR_PRODUCT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="34.细胞因子类制品费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.CYTOKINE_PRODUCT_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.CYTOKINE_PRODUCT_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="35.检查用一次性医用材料费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.INSPECTION_OF_DISPOSABLE_MEDICAL_MATERIALS_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.INSPECTION_OF_DISPOSABLE_MEDICAL_MATERIALS_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="36.治疗用一次性医用材料费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.DISPOSABLE_MEDICAL_MATERIALS_FOR_TREATMENT&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.DISPOSABLE_MEDICAL_MATERIALS_FOR_TREATMENT&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="37.介入用一次性医用材料费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.INTERVENTIONAL_DISPOSABLE_MEDICAL_MATERIALS_FEE&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.INTERVENTIONAL_DISPOSABLE_MEDICAL_MATERIALS_FEE&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                new ThirtyEightFee{
                    Project="38.手术用一次性医用材料费",
                    Current=items.Where(r=>r?.Project==TE_PROJECT.DISPOSABLE_MEDICAL_MATERIALS_FOR_SURGERY&& r?.Age=="当期")?.FirstOrDefault()?.Fee,
                    Period=items.Where(r=>r?.Project==TE_PROJECT.DISPOSABLE_MEDICAL_MATERIALS_FOR_SURGERY&& r?.Age=="同期")?.FirstOrDefault()?.Fee,
                },

                
            };
            return list;
        }
    }
}
