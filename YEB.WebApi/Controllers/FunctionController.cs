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
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;
        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        #region 基础增删改
        /// <summary>
        /// 添加单笔Function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(Function function)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _functionService.Add(function)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 添加多笔Function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRange(List<Function> function)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _functionService.AddRange(function)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 删除单笔Function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Del(Function function)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _functionService.Del(function)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 删除多笔Function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DelRange(List<Function> function)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _functionService.DelRange(function)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 编辑单笔Function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Function function)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _functionService.Edit(function)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 编辑多笔Function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditRange(List<Function> function)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _functionService.EditRange(function)
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
