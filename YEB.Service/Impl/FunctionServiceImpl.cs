using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;
using YEB.Repository;

namespace YEB.Service.Impl
{
    public class FunctionServiceImpl : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;
        public FunctionServiceImpl(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        #region 基础增删改
        public async Task<int> Add(Function function)
        {
            try
            {
                return await _functionRepository.Insert(function);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> AddRange(List<Function> function)
        {
            try
            {
                return await _functionRepository.Insert(function);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Del(Function function)
        {
            try
            {
                return await _functionRepository.Delete(function);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DelRange(List<Function> function)
        {
            try
            {
                return await _functionRepository.Delete(function);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Edit(Function function)
        {
            try
            {
                return await _functionRepository.Update(function);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> EditRange(List<Function> function)
        {
            try
            {
                return await _functionRepository.Update(function);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
