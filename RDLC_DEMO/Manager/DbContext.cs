using Elight.Infrastructure;
using SqlSugar;
using System;
using System.Configuration;
using System.Linq;

namespace InhospitalIndicators.Service.Services
{

    public class DbContext<T> //where T : class, new()
    {
        
        public SqlSugarClient Db;
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
#if DEBUG
                //ConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ToString(),
                ConnectionString = "User ID=tw_hsp_pmpa;Password=hospital;Data Source=192.168.5.58/ocsdb;",
#else
                ConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ToString(), //"User ID=tw_hsp_pmpa;Password=hospital;Data Source=192.168.5.58/ocsdb;",
#endif
                DbType = DbType.Oracle,//设置数据库类型
                IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息

            });
            LogHelper.RegisterConfig();
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                
                LogHelper.Info(sql);
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };

        }
    }
}
