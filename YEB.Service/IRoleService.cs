using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;

namespace YEB.Service
{
    public interface IRoleService
    {
        #region 基础增删改
        Task<int> Add(Role role);
        Task<int> AddRange(List<Role> role);
        Task<int> Del(Role role);
        Task<int> DelRange(List<Role> role);
        Task<int> Edit(Role function);
        Task<int> EditRange(List<Role> role);
        #endregion
    }
}
