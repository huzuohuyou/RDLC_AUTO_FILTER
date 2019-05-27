using InhospitalIndicators.Service.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service.Manager.WorkloadWeight
{

     class OutItem : BaseManager<FeeItem>
    {
        public override  Tuple<string, List<FeeItem>> GetData()
        {
            var sql = $@"
 
                select b.codename project,a.count ,c.fee fee,'同期' age  from
                (
                select value, sum(cntamt) count from twtong_ygjc_yhld_yn
                where  
                CTYPE1='检验检测' 
                and ctype2='MZ' 
                and reportdate>=to_date('{PeriodStart}', 'yyyy-MM-dd')
                and reportdate<=to_date('{PeriodEnd}', 'yyyy-MM-dd')
                group by value
                ) a
                left join
                (
                select value, sum(cntamt) fee from twtong_ygjc_yhld_yn
                where  
                CTYPE1='检验金额' 
                and ctype2='MZ' 
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
                and ctype2='MZ' 
                and reportdate>=to_date('{CurrentStart}', 'yyyy-MM-dd')
                and reportdate<=to_date('{CurrentEnd}', 'yyyy-MM-dd')
                group by value
                ) a
                left join
                (
                select value, sum(cntamt) fee from twtong_ygjc_yhld_yn
                where  
                CTYPE1='检验金额' 
                and ctype2='MZ' 
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
             var result=Db.SqlQueryable<FeeItem>(
                              sql       ).ToList();
            return new Tuple<string, List<FeeItem>>(sql, result);
        }
    }
}
