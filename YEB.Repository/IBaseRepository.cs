using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YEB.Repository
{
    public interface IBaseRepository
    {
        #region 实体的增删改
        /// <summary>
        /// 添加单笔数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>DB变更数</returns>
        Task<int> Insert<T>(T entity) where T : class;
        /// <summary>
        /// 添加多笔数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>DB变更数</returns>
        Task<int> Insert<T>(List<T> entity) where T : class;
        /// <summary>
        /// 删除单笔数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>DB变更数</returns>
        Task<int> Delete<T>(T entity) where T : class;
        /// <summary>
        /// 删除多笔数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>DB变更数</returns>
        Task<int> Delete<T>(List<T> entity) where T : class;
        /// <summary>
        /// 更新单笔数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>DB变更数</returns>
        Task<int> Update<T>(T entity) where T : class;
        /// <summary>
        /// 更新多笔数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>DB变更数</returns>
        Task<int> Update<T>(List<T> entity) where T : class;
        #endregion
    }
}
