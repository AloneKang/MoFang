using SqlSugar;
using System.Collections.Generic;

namespace MoFang.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            List<CPAT_VISIT> Visit = GetList("c=>c.PATIENT_ID.Equals('C886751')");

        }

        public static List<CPAT_VISIT> GetList(string StrWhere)
        {
            SqlSugarClient db = new SqlSugarClient(
           new ConnectionConfig()
           {
               ConnectionString = "Data Source=192.168.1.251;Initial Catalog=RY_SDR_MONIM;UID=sa;PWD=ry@123;Integrated Security=False",
               DbType = DbType.SqlServer,//设置数据库类型
                IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息
            });
            return db.Queryable<CPAT_VISIT>().WhereIF(!string.IsNullOrEmpty(StrWhere), StrWhere).ToList();
        }


        public class CPAT_VISIT
        {
            public string PATIENT_NO { get; set; }
            public string PATIENT_ID { get; set; }
            public string Name { get; set; }
        }
    }
}
