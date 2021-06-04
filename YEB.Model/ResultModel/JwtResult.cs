using System;
using System.Collections.Generic;
using System.Text;
using YEB.Model.Result;

namespace YEB.Model.ResultModel
{
    public class JwtResult : BaseResult
    {
        public string Token { get; set; }
    }
}
