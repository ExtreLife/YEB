using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;

namespace YEB.Service
{
    public interface IUserService
    {
        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0-不重复 1-重复</returns>
        Task<int> CheckUsername(User user);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0-登录失败 1-登录成功</returns>
        Task<int> Login(User user);
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0-注册失败 1-组成成功</returns>
        Task<int> Register(User user);
    }
}
