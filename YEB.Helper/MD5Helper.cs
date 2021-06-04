using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace YEB.Helper
{
    public static class MD5Helper
    {
        /// <summary>
        /// MD564位加密
        /// </summary>
        /// <param name="txt">需要加密的文本</param>
        /// <returns>加密后的文本</returns>
        public static string Md5Encoding64(string txt)
        {
            byte[] sor = Encoding.UTF8.GetBytes(txt);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                //加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
                strbul.Append(result[i].ToString("x4"));
            }
            return strbul.ToString();
        }
    }
}
