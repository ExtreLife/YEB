using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;
using YEB.Helper;
using YEB.Repository;

namespace YEB.Service.Impl
{
    public class UserServiceImpl : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> CheckUsername(User user)
        {
            try
            {
                return await _userRepository.CheckUsername(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Login(User user)
        {
            try
            {
                user.Password = MD5Helper.Md5Encoding64(user.Password);
                return await _userRepository.Login(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Register(User user)
        {
            try
            {
                user.Password = MD5Helper.Md5Encoding64(user.Password);
                return await _userRepository.Insert(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
