using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;
using YEB.Repository;

namespace YEB.Service.Impl
{
    public class MenuServiceImpl : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuServiceImpl(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        #region 基础增删改
        public async Task<int> Add(Menu menu)
        {
            try
            {
                return await _menuRepository.Insert(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> AddRange(List<Menu> menu)
        {
            try
            {
                return await _menuRepository.Insert(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Del(Menu menu)
        {
            try
            {
                return await _menuRepository.Delete(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DelRange(List<Menu> menu)
        {
            try
            {
                return await _menuRepository.Delete(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Edit(Menu menu)
        {
            try
            {
                return await _menuRepository.Update(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> EditRange(List<Menu> menu)
        {
            try
            {
                return await _menuRepository.Update(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
