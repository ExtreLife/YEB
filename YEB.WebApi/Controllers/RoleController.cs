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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #region 基础增删改
        /// <summary>
        /// 添加单笔Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(Role role)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _roleService.Add(role)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 添加多笔Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRange(List<Role> role)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _roleService.AddRange(role)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 删除单笔Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Del(Role role)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _roleService.Del(role)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 删除多笔Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DelRange(List<Role> role)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _roleService.DelRange(role)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 编辑单笔Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Role role)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _roleService.Edit(role)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 编辑多笔Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditRange(List<Role> role)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _roleService.EditRange(role)
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
