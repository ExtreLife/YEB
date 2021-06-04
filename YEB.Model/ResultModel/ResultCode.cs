using System;
using System.Collections.Generic;
using System.Text;

namespace YEB.Model.ResultModel
{
    public enum ResultCode
    {
        #region Controllor通用错误码
        Error = -10,

        #endregion

        #region DB错误 -100~-199
        /// <summary>
        /// 无法连接数据库
        /// </summary>
        DbUnconnectable = -100,
        /// <summary>
        /// 数据库连接超时
        /// </summary>
        DbConnectionTimeOut = -101,
        /// <summary>
        /// 键冲突
        /// </summary>
        PrimaryKeyConflict = -102
        #endregion
    }
}
