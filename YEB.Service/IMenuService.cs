using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;

namespace YEB.Service
{
    public interface IMenuService
    {
        #region 基础增删改
        Task<int> Add(Menu menu);
        Task<int> AddRange(List<Menu> menu);
        Task<int> Del(Menu menu);
        Task<int> DelRange(List<Menu> menu);
        Task<int> Edit(Menu function);
        Task<int> EditRange(List<Menu> menu);
        #endregion
    }
}
