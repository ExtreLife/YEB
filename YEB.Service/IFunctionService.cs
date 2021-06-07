using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;
using YEB.Repository;

namespace YEB.Service
{
    public interface IFunctionService
    {
        #region 基础增删改
        Task<int> Add(Function function);
        Task<int> AddRange(List<Function> function);
        Task<int> Del(Function function);
        Task<int> DelRange(List<Function> function);
        Task<int> Edit(Function function);
        Task<int> EditRange(List<Function> function);
        #endregion
    }
}
