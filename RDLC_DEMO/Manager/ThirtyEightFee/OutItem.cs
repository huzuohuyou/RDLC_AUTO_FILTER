using InhospitalIndicators.Service.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Manager.ThirtyEightFee
{

     class OutItem : BaseManager<FeeItem>
    {
        public override List<FeeItem> GetData()
        {
            return Db.SqlQueryable<FeeItem>(
                $@"select sum(amt1) fee, c.codename project,c.code,'同期' age from twopd_slip a,twmir_duizhao b ,twbas_basecode c where
                        b.sunext=A.sunext
                    and c.business='IPD'
                    and c.bun='病案附页'
                    and C.CODE =b.t_bun2
                    and entdate>=to_date('{PeriodStart}','yyyy-MM-dd')
                    and entdate<=to_date('{PeriodEnd}','yyyy-MM-dd')
                    group by c.codename,c.code 
                    union 
                    select sum(amt1) fee, c.codename project,c.code,'当期' age from twopd_slip a,twmir_duizhao b ,twbas_basecode c where
                        b.sunext=A.sunext
                    and c.business='IPD'
                    and c.bun='病案附页'
                    and C.CODE =b.t_bun2
                    and entdate>=to_date('{CurrentStart}','yyyy-MM-dd')
                    and entdate<=to_date('{CurrentEnd}','yyyy-MM-dd')
                    group by c.codename,c.code ").ToList();
        }
    }
}
