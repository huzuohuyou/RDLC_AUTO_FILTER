using InhospitalIndicators.Service.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace InhospitalIndicators.Service.Manager.ThirtyEightFee
{

    class AllItem : BaseManager<FeeItem>
    {
        public override List<FeeItem> GetData()
        {
            return new InItem
            {
                CurrentStart = CurrentStart,
                CurrentEnd = CurrentStart,
                PeriodStart = CurrentStart,
                PeriodEnd = CurrentStart,
            }.GetData()
            .Union(new OutItem
            {
                CurrentStart = CurrentStart,
                CurrentEnd = CurrentStart,
                PeriodStart = CurrentStart,
                PeriodEnd = CurrentStart,
            }.GetData()).ToList();
            return Db.SqlQueryable<FeeItem>(
                $@"select sum(amt) fee,code,codename Project,flag1 age from (
                    select sum(amt1) amt, c.codename,c.code,'同期' flag1 from twopd_slip a,twmir_duizhao b ,twbas_basecode c where
                     b.sunext=A.sunext
                    and c.business='IPD'
                    and c.bun='病案附页'
                    and C.CODE =b.t_bun2
                    and entdate>=to_date('{PeriodStart}','yyyy-MM-dd')
                    and entdate<=to_date('{PeriodEnd}','yyyy-MM-dd')
                    group by c.codename,c.code 
                    union 
                    select sum(amt1) amt, c.codename,c.code,'当期' flag1 from twopd_slip a,twmir_duizhao b ,twbas_basecode c where
                     b.sunext=A.sunext
                    and c.business='IPD'
                    and c.bun='病案附页'
                    and C.CODE =b.t_bun2
                    and entdate>=to_date('{CurrentStart}','yyyy-MM-dd')
                    and entdate<=to_date('{CurrentEnd}','yyyy-MM-dd')
                    group by c.codename,c.code 
                    union
                    select sum(amt1) amt, c.codename,c.code,'同期' flag1 from twipd_slip a,twmir_duizhao b ,twbas_basecode c where
                     b.sunext=A.sunext
                    and c.business='IPD'
                    and c.bun='病案附页'
                    and C.CODE =b.t_bun2
                    and entdate>=to_date('{PeriodStart}','yyyy-MM-dd')
                    and entdate<=to_date('{PeriodEnd}','yyyy-MM-dd')
                    group by c.codename,c.code 
                    union 
                    select sum(amt1) amt, c.codename,c.code,'当期' flag1 from twipd_slip a,twmir_duizhao b ,twbas_basecode c where
                     b.sunext=A.sunext
                    and c.business='IPD'
                    and c.bun='病案附页'
                    and C.CODE =b.t_bun2
                    and entdate>=to_date('{CurrentStart}','yyyy-MM-dd')
                    and entdate<=to_date('{CurrentEnd}','yyyy-MM-dd')
                    group by c.codename,c.code 
                    ) group by codename,code,flag1").ToList();
        }
    }
}
