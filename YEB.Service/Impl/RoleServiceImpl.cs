using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;
using YEB.Repository;

namespace YEB.Service.Impl
{
    public class RoleServiceImpl : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleServiceImpl(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        #region 基础增删改
        public async Task<int> Add(Role role)
        {
            try
            {
                return await _roleRepository.Insert(role);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> AddRange(List<Role> role)
        {
            try
            {
                return await _roleRepository.Insert(role);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Del(Role role)
        {
            try
            {
                return await _roleRepository.Delete(role);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DelRange(List<Role> role)
        {
            try
            {
                return await _roleRepository.Delete(role);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Edit(Role role)
        {
            try
            {
                return await _roleRepository.Update(role);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> EditRange(List<Role> role)
        {
            try
            {
                return await _roleRepository.Update(role);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
