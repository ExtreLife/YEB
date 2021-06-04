using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Data;

namespace YEB.Repository.Impl
{
    public class BaseRepositoryImpl : IBaseRepository
    {
        private readonly Context _context;
        public BaseRepositoryImpl(Context context)
        {
            _context = context;
        }
        #region 实体的增删改
        public async Task<int> Insert<T>(T entity) where T : class
        {
            try
            {
                _context.Add<T>(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<int> Insert<T>(List<T> entity) where T : class
        {
            try
            {
                _context.AddRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<int> Delete<T>(T entity) where T : class
        {
            try
            {
                _context.Remove<T>(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<int> Delete<T>(List<T> entity) where T : class
        {
            try
            {
                _context.RemoveRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<int> Update<T>(T entity) where T : class
        {
            try
            {
                _context.Update<T>(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<int> Update<T>(List<T> entity) where T : class
        {
            try
            {
                _context.UpdateRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
