using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YEB.Entity;
using YEB.Helper;
using YEB.Model.Result;
using YEB.Model.ResultModel;
using YEB.Service;

namespace YEB.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        /// <summary>
        /// 检测Username是否重复
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0-不重复 1-重复</returns>
        [HttpGet]
        public async Task<IActionResult> CheckUsername(User user)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _userService.CheckUsername(user)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 用户登录
        /// 登录成功颁发Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                var SecrtKey = _configuration["JwtConfig:SecrtKey"];
                var ISS = _configuration["JwtConfig:ISS"];
                var Audience = _configuration["JwtConfig:Audience"];
                int Expires = int.Parse(_configuration["JwtConfig:Expires"]);
                //var secrtKey = "254d7345b0bf11ebbd2b7c8ae14efa53";
                //var iss = "https://localhost:44368";
                //var audience = "https://localhost:44368";
                if (await _userService.Login(user) > 0)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                    new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                    new Claim(ClaimTypes.Name, user.Username)
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecrtKey));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: ISS,
                        audience: Audience,
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(Expires),
                        signingCredentials: creds);

                    return Ok(new JwtResult
                    {
                        Result = 1,
                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                else
                {
                    return Ok(new JwtResult
                    {
                        Result = 0,
                        Message = "用户名或密码错误！"
                    });
                }
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetJwtResult(e));
            }
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0-失败 1-成功</returns>
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                return Ok(new BaseResult
                {
                    Result = await _userService.Register(user)
                });
            }
            catch (Exception e)
            {
                return Ok(ResultHelper.GetBaseResult(e));
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetSetting()
        {
            try
            {
                var SecrtKey = _configuration["JwtConfig:SecrtKey"];
                var ISS = _configuration["JwtConfig:ISS"];
                var Audience = _configuration["JwtConfig:Audience"];
                var Expires = _configuration["JwtConfig:Expires"];
                return Ok(new
                {
                    secrtKey = SecrtKey,
                    iss = ISS,
                    audience = Audience,
                    expires = Expires
                });
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
