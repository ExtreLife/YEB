using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YEB.Entity;
using YEB.Helper;
using YEB.Model.Result;
using YEB.Service;

namespace YEB.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        #region 基础增删改
        /// <summary>
        /// 添加单笔Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(Menu menu)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _menuService.Add(menu)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 添加多笔Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRange(List<Menu> menu)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _menuService.AddRange(menu)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 删除单笔Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Del(Menu menu)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _menuService.Del(menu)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 删除多笔Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DelRange(List<Menu> menu)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _menuService.DelRange(menu)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 编辑单笔Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Menu menu)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _menuService.Edit(menu)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 编辑多笔Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditRange(List<Menu> menu)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _menuService.EditRange(menu)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }
        #endregion
    }
}
