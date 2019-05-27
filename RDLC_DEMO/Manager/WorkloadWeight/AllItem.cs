using InhospitalIndicators.Service.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InhospitalIndicators.Service.Manager.WorkloadWeight
{

    class AllItem : BaseManager<FeeItem>
    {
        public override Tuple<string, List<FeeItem>> GetData()
        {
            var _in = new InItem
            {
                CurrentStart = CurrentStart,
                CurrentEnd = CurrentEnd,
                PeriodStart = PeriodStart,
                PeriodEnd = PeriodEnd,
            }.GetData().Item1;
            var _out = new OutItem
            {
                CurrentStart = CurrentStart,
                CurrentEnd = CurrentEnd,
                PeriodStart = PeriodStart,
                PeriodEnd = PeriodEnd,
            }.GetData().Item1;
            var sql = $@"{_in}
                    union
                    {_out}";
            var _all = Db.SqlQueryable<FeeItem>(sql).ToList();
            return new Tuple<string, List<FeeItem>>(sql, _all);
        }
    }
}
