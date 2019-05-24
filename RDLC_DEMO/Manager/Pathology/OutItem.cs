using InhospitalIndicators.Service.Entitys;
using System.Collections.Generic;

namespace InhospitalIndicators.Service.Manager.Pathology
{

    class OutItem : BaseManager<FeeItem>
    {
        public override List<FeeItem> GetData()
        {
            return Db.SqlQueryable<FeeItem>(
                                    $@"select p.project,q.count,q.fee,q.age from (
    select distinct value, 0 num,codename Project from twbas_basecode  where business = '统计业务'
    and bun = '病理检测') p
    left join
        (
SELECT t.* FROM  (--检验数量
                    select m.codename Project, m.num count, n.fee ,'同期' age from
                    (
                    SELECT VALUE, COUNT(0) num, codename FROM(
                    select ORDERNO, SUCODE, VALUE, codename from twbas_basecode a, twopd_slip b where business = '统计业务'
                    and a.bun = '病理检测'
                    and(a.remark1 = b.sucode or a.remark2 = b.sucode)
                    and b.bdate >= to_date('{PeriodStart}', 'yyyy-MM-dd')
                    and b.bdate <= to_date('{PeriodEnd}', 'yyyy-MM-dd')
                    and b.nu <> 90
                    
                    AND GBDC <> 'DC'
                    GROUP BY ORDERNO, SUCODE, VALUE, codename)
                    GROUP BY VALUE, codename
                    )m
                    left join
                    (
                    --检验金额
                    select sum(amt) fee, value, codename from(
                    select sum(amt1)amt, sucode, value, codename from twbas_basecode a, twopd_slip b where business = '统计业务'
                    and a.bun = '病理检测'
                    and(a.remark1 = b.sucode or a.remark2 = b.sucode)
                    and b.bdate >= to_date('{PeriodStart}', 'yyyy-MM-dd')
                    and b.bdate <= to_date('{PeriodEnd}', 'yyyy-MM-dd')
                    and b.nu <> 90
                    group by sucode, value, codename)
                    group by value, codename)n
                    on m.codename = n.codename
                    union
                    select m.codename Project, m.num count, n.fee, '当期' age from
                    (
                    SELECT VALUE, COUNT(0) num, codename FROM(
                    select ORDERNO, SUCODE, VALUE, codename from twbas_basecode a, twopd_slip b where business = '统计业务'
                    and a.bun = '病理检测'
                    and(a.remark1 = b.sucode or a.remark2 = b.sucode)
                    and b.bdate >= to_date('{CurrentStart}', 'yyyy-MM-dd')
                    and b.bdate <= to_date('{CurrentEnd}', 'yyyy-MM-dd')
                    and b.nu <> 90
                    --and codename = '甲功'
                    --and sucode = 'EXM01058'
                    AND GBDC <> 'DC'
                    GROUP BY ORDERNO, SUCODE, VALUE, codename)
                    GROUP BY VALUE, codename
                    )m
                    left join
                    (
                    --检验金额
                    select sum(amt) fee, value, codename from(
                    select sum(amt1)amt, sucode, value, codename from twbas_basecode a, twopd_slip b where business = '统计业务'
                    and a.bun = '病理检测'
                    and(a.remark1 = b.sucode or a.remark2 = b.sucode)
                    and b.bdate >= to_date('{CurrentStart}', 'yyyy-MM-dd')
                    and b.bdate <= to_date('{CurrentEnd}', 'yyyy-MM-dd')
                    and b.nu <> 90
                    group by sucode, value, codename)
                    group by value, codename)n
                    on m.codename = n.codename
) t )q 
on p.project=q.project
").ToList();
        }
    }
}
