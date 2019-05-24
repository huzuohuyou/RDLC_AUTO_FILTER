using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Services.CurrentPeriod
{

    class OutItem : BaseManager<FeeItem>
    {
        public override List<FeeItem> GetData()
        {
            return Db.SqlQueryable<FeeItem>(
                $@"select sum(amt1) fee,a.nu,c.codename  Project,sugbe,'同期' age from twopd_slip a, twbas_tsuga b,twbas_basecode c  where a.nu<>90
                    and entdate>=to_date('{PeriodStart}','yyyy-MM-dd')
                    and entdate<=to_date('{PeriodEnd}','yyyy-MM-dd')
                    and a.sunext=b.sunext
                    and c.business='BASIC'
                    and c.bun='NU'
                    and a.nu=c.code
                    group by a.nu,sugbe,codename
                    union
                    select sum(amt1) fee,a.nu,c.codename  Project,sugbe,'当期' age from twopd_slip a, twbas_tsuga b,twbas_basecode c  where a.nu<>90
                    and entdate>=to_date('{CurrentStart}','yyyy-MM-dd')
                    and entdate<=to_date('{CurrentEnd}','yyyy-MM-dd')
                    and a.sunext=b.sunext
                    and c.business='BASIC'
                    and c.bun='NU'
                    and a.nu=c.code
                    group by a.nu,sugbe，codename").ToList();
        }
    }
}
