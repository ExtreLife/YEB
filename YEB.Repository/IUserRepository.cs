using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;

namespace YEB.Repository
{
    public interface IUserRepository : IBaseRepository
    {
        /// <summary>
        /// 用户用户名是否存在
        /// 注册时检测
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0-用户名可以使用 1-用户名存在</returns>
        Task<int> CheckUsername(User user);
        /// <summary>
        /// 用户登录
        /// 检查用户名、密码是否正确
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0-登录失败 1-登录成功</returns>
        Task<int> Login(User user);
    }
}
