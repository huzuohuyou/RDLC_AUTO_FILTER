using InhospitalIndicators.Service.Entitys;
using System;
using System.Collections.Generic;

namespace InhospitalIndicators.Service.Manager.Pathology
{

    class InItem : BaseManager<FeeItem>
    {
        public override Tuple<string, List<FeeItem>> GetData()
        {
            #region 0527
            var sql1 = $@"select p.project,q.count,q.fee,q.age from (
    select distinct value, 0 num,codename Project from twbas_basecode  where business = '统计业务'
    and bun = '病理检测') p
    left join
        (
SELECT t.* FROM  (--检验数量
                    select m.codename Project, m.num count, n.fee ,'同期' age from
                    (
                    SELECT VALUE, COUNT(0) num, codename FROM(
                    select ORDERNO, SUCODE, VALUE, codename from twbas_basecode a, twipd_slip b where business = '统计业务'
                    and a.bun = '病理检测'
                    and(a.remark1 = b.sucode or a.remark2 = b.sucode)
                    and b.entdate >= to_date('{PeriodStart}', 'yyyy-MM-dd')
                    and b.entdate <= to_date('{PeriodEnd}', 'yyyy-MM-dd')
                    and b.nu <> 90
                    --and codename = '甲功'
                    --and sucode = 'EXM01058'
                    AND GBDC is null
                    GROUP BY ORDERNO, SUCODE, VALUE, codename)
                    GROUP BY VALUE, codename
                    )m
                    left join
                    (
                    --检验金额
                    select sum(amt) fee, value, codename from(
                    select sum(amt1)amt, sucode, value, codename from twbas_basecode a, twipd_slip b where business = '统计业务'
                    and a.bun = '病理检测'
                    and(a.remark1 = b.sucode or a.remark2 = b.sucode)
                    and b.entdate >= to_date('{PeriodStart}', 'yyyy-MM-dd')
                    and b.entdate <= to_date('{PeriodEnd}', 'yyyy-MM-dd')
                    and b.nu <> 90
                    AND GBDC is null
                    group by sucode, value, codename)
                    group by value, codename)n
                    on m.codename = n.codename
                    union
                    select m.codename Project, m.num count, n.fee, '当期' age from
                    (
                    SELECT VALUE, COUNT(0) num, codename FROM(
                    select ORDERNO, SUCODE, VALUE, codename from twbas_basecode a, twipd_slip b where business = '统计业务'
                    and a.bun = '病理检测'
                    and(a.remark1 = b.sucode or a.remark2 = b.sucode)
                    and b.entdate >= to_date('{CurrentStart}', 'yyyy-MM-dd')
                    and b.entdate <= to_date('{CurrentEnd}', 'yyyy-MM-dd')
                    and b.nu <> 90
                    --and codename = '甲功'
                    --and sucode = 'EXM01058'
                   AND GBDC is null
                    GROUP BY ORDERNO, SUCODE, VALUE, codename)
                    GROUP BY VALUE, codename
                    )m
                    left join
                    (
                    --检验金额
                    select sum(amt) fee, value, codename from(
                    select sum(amt1)amt, sucode, value, codename from twbas_basecode a, twipd_slip b where business = '统计业务'
                    and a.bun = '病理检测'
                    and(a.remark1 = b.sucode or a.remark2 = b.sucode)
                    and b.entdate >= to_date('{CurrentStart}', 'yyyy-MM-dd')
                    and b.entdate <= to_date('{CurrentEnd}', 'yyyy-MM-dd')
                    and b.nu <> 90
                    AND GBDC is null
                    group by sucode, value, codename)
                    group by value, codename)n
                    on m.codename = n.codename
) t )q 
on p.project=q.project
";
            #endregion

            var sql = $@"
 
                select b.codename project,a.count ,c.fee fee,'同期' age  from
                (
                select value, sum(cntamt) count from twtong_ygjc_yhld_yn
                where  
                CTYPE1='检验检测' 
                and ctype2='ZY' 
                and reportdate>=to_date('{PeriodStart}', 'yyyy-MM-dd')
                and reportdate<=to_date('{PeriodEnd}', 'yyyy-MM-dd')
                group by value
                ) a
                left join
                (
                select value, sum(cntamt) fee from twtong_ygjc_yhld_yn
                where  
                CTYPE1='检验金额' 
                and ctype2='ZY' 
                and reportdate>=to_date('{PeriodStart}', 'yyyy-MM-dd')
                and reportdate<=to_date('{PeriodEnd}', 'yyyy-MM-dd')
                group by value
                ) c
                on a.value=c.value
                left join
                (
                select * from twbas_basecode where business='统计业务' and bun='检验检测'
                )b
                on a.value=b.value

                union
 
                select b.codename project,a.count ,c.fee fee,'当期' age  from
                (
                select value, sum(cntamt) count from twtong_ygjc_yhld_yn
                where  
                CTYPE1='检验检测' 
                and ctype2='ZY' 
                and reportdate>=to_date('{CurrentStart}', 'yyyy-MM-dd')
                and reportdate<=to_date('{CurrentEnd}', 'yyyy-MM-dd')
                group by value
                ) a
                left join
                (
                select value, sum(cntamt) fee from twtong_ygjc_yhld_yn
                where  
                CTYPE1='检验金额' 
                and ctype2='ZY' 
                and reportdate>=to_date('{CurrentStart}', 'yyyy-MM-dd')
                and reportdate<=to_date('{CurrentEnd}', 'yyyy-MM-dd')
                group by value
                ) c
                on a.value=c.value
                left join
                (
                select * from twbas_basecode where business='统计业务' and bun='检验检测'
                )b
                on a.value=b.value";
            var result= Db.SqlQueryable<FeeItem>(sql ).ToList();
            return new Tuple<string, List<FeeItem>>(sql,result);
        }
    }
}
