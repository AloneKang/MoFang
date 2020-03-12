using MoFang.OA.Entity.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoFang.OA.IRepository.Base
{
    public interface IBaseRepository<T> where T : class, new()
    {
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <returns></returns>
        List<T> Query();
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns></returns>
        List<T> Query(Expression<Func<T, bool>> whereExpression);
        /// <summary>
        /// 查询一个列表 
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="strOrderByFileds">条件升序 还是 降序</param>
        /// <returns></returns>
        List<T> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds);
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderByExpression">排序的条件表达式</param>
        /// <param name="isAsc">升序 或 降序</param>
        /// <returns></returns>
        List<T> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true);
       
        /// <summary>
        /// 根据Id返回一个对象
        /// </summary>
        /// <param name="RId"></param>
        /// <returns></returns>
        T QueryById(object RId);

        /// <summary>
        /// 根据实体删除一条数据  
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DeleteData(T model);
        /// <summary>
        /// 根据Id来删除数据 
        /// </summary>
        /// <param name="RId"></param>
        /// <returns></returns>
        bool DeleteById(object RId);
        /// <summary>
        /// 根据多个Id来删除数据
        /// </summary>
        /// <param name="Rids"></param>
        /// <returns></returns>
        bool DeleteByIds(List<object> Rids);
        /// <summary>
        /// 根据实体来修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateData(T model);
        /// <summary>
        /// 对指定的列更新或不更新 和更新条件
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="lstColumns"></param>
        /// <param name="lstIgnoreColumns">不更新的列</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        bool Update(T model, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int InsertModel(T Model);
        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="ListModel"></param>
        /// <returns></returns>
        int InsertModel(List<T> ListModel);




    }
}
