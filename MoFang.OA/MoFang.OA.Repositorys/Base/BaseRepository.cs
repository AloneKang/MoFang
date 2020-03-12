using MoFang.OA.Entity.Entity.BaseEntity;
using MoFang.OA.IRepository.Base;
using MoFang.OA.Repository.Sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoFang.OA.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<T> entityDB;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        internal SimpleClient<T> EntityDB
        {
            get { return entityDB; }
            private set { entityDB = value; }
        }
        public BaseRepository()
        {
            //获取连接字符串
            DbContext.Init(BaseDBConfig.ConnectionString);
            //给数据库上下文赋值
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GetEntityDB<T>(db);

        }
        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="RId"></param>
        /// <returns></returns>
        public bool DeleteById(object RId)
        {
            return db.Deleteable<T>().In(RId).ExecuteCommand() > 0;
        }
        /// <summary>
        /// 根据多个Id批量删除
        /// </summary>
        /// <param name="Rids"></param>
        /// <returns></returns>
        public bool DeleteByIds(List<object> Rids)
        {
            return db.Deleteable<T>(Rids).ExecuteCommand() > 0;
        }
        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteData(T model)
        {
            return db.Deleteable(model).ExecuteCommand() > 0;
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int InsertModel(T Model)
        {
            return db.Insertable(Model).ExecuteCommand();
        }
        /// <summary>
        /// 批量新增实体
        /// </summary>
        /// <param name="ListModel"></param>
        /// <returns></returns>
        public int InsertModel(List<T> ListModel)
        {
            return db.Insertable(ListModel).ExecuteCommand();
        }

        public List<T> Query()
        {
            return db.Queryable<T>().ToList();
        }


        public List<T> Query(Expression<Func<T, bool>> whereExpression)
        {
            return db.Queryable<T>().WhereIF(whereExpression != null, whereExpression).ToList();
        }

        public List<T> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds)
        {
            return db.Queryable<T>().WhereIF(whereExpression != null, whereExpression).OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).ToList();
        }

        public List<T> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            return db.Queryable<T>().OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).WhereIF(whereExpression != null, whereExpression).ToList();
        }

        public T QueryById(object RId)
        {
            return db.Queryable<T>().In(RId).First();
        }

        public bool Update(T model, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            IUpdateable<T> up = db.Updateable(model);
            if (lstIgnoreColumns != null && lstIgnoreColumns.Count > 0)
            {
                up = up.IgnoreColumns(lstIgnoreColumns.ToArray());
            }
            if (lstColumns != null && lstColumns.Count > 0)
            {
                up = up.UpdateColumns(lstColumns.ToArray());
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                up = up.Where(strWhere);
            }
            return up.ExecuteCommand() > 0;
        }

        public bool UpdateData(T model)
        {
            return db.Updateable(model).ExecuteCommand() > 0;
        }
    }
}
