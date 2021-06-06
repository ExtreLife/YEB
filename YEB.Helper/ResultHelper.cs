using System;
using System.Collections.Generic;
using System.Text;
using YEB.Model.Result;
using YEB.Model.ResultModel;

namespace YEB.Helper
{
    public static class ResultHelper
    {
        /// <summary>
        /// 封装基础结果类
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static BaseResult GetBaseResult(Exception e)
        {
            StringBuilder stringBuilder = new StringBuilder(e.Message);
            stringBuilder.AppendLine(e.StackTrace);
            return new BaseResult
            {
                Result = (int)ResultCode.Error,
                Message = stringBuilder.ToString()
            };
        }

        /// <summary>
        /// 封装数据结果类
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static DataResult GetDataResult(Exception e)
        {
            StringBuilder stringBuilder = new StringBuilder(e.Message);
            stringBuilder.AppendLine(e.StackTrace);
            return new DataResult
            {
                Result = (int)ResultCode.Error,
                Message = stringBuilder.ToString(),
                Data = null
            };
        }
    }
}
