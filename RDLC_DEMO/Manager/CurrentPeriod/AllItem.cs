using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Manager;
using System.Collections.Generic;
using System.Linq;

namespace InhospitalIndicators.Service.Services.CurrentPeriod
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
            }.GetData().Union(new OutItem
            {
                CurrentStart = CurrentStart,
                CurrentEnd = CurrentStart,
                PeriodStart = CurrentStart,
                PeriodEnd = CurrentStart,
            }.GetData()).ToList();
            return Db.SqlQueryable<FeeItem>($@"select sum(amt) fee,nu,codename Project,sugbe,flag1 age from (
                    select sum(amt1) amt,a.nu,c.codename,sugbe,'同期' flag1 from twipd_slip a, twbas_tsuga b,twbas_basecode c  where a.nu<>90
                    and entdate>=to_date('{PeriodStart}','yyyy-MM-dd')
                    and entdate<=to_date('{PeriodEnd}','yyyy-MM-dd')
                    and a.sunext=b.sunext
                    and c.business='BASIC'
                    and c.bun='NU'
                    and a.nu=c.code
                    group by a.nu,sugbe,codename
                    union
                    select sum(amt1) amt,a.nu,c.codename,sugbe,'当期' flag1 from twipd_slip a, twbas_tsuga b,twbas_basecode c  where a.nu<>90
                    and entdate>=to_date('{CurrentStart}','yyyy-MM-dd')
                    and entdate<=to_date('{CurrentEnd}','yyyy-MM-dd')
                    and a.sunext=b.sunext
                    and c.business='BASIC'
                    and c.bun='NU'
                    and a.nu=c.code
                    group by a.nu,sugbe，codename
                    union
                    select sum(amt1) amt,a.nu,c.codename,sugbe,'同期' flag1 from twopd_slip a, twbas_tsuga b,twbas_basecode c  where a.nu<>90
                    and entdate>=to_date('{PeriodStart}','yyyy-MM-dd')
                    and entdate<=to_date('{PeriodEnd}','yyyy-MM-dd')
                    and a.sunext=b.sunext
                    and c.business='BASIC'
                    and c.bun='NU'
                    and a.nu=c.code
                    group by a.nu,sugbe,codename
                    union
                    select sum(amt1) amt,a.nu,c.codename,sugbe,'当期' flag1 from twopd_slip a, twbas_tsuga b,twbas_basecode c  where a.nu<>90
                    and entdate>=to_date('{CurrentStart}','yyyy-MM-dd')
                    and entdate<=to_date('{CurrentEnd}','yyyy-MM-dd')
                    and a.sunext=b.sunext
                    and c.business='BASIC'
                    and c.bun='NU'
                    and a.nu=c.code
                    group by a.nu,sugbe，codename
                    ) group by nu,codename,sugbe,flag1").ToList();
        }
    }
}
