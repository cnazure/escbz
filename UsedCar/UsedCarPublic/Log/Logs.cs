using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsedCarPublic.Log
{
    public class Logs : UsedCarPublic.Log.ILogs
    {
        #region 方法

        public void Debug(String str)
        {

            Log.ExceptionLog.writeFile(2, str);

        }

        public void Info(String str)
        {
            Log.ExceptionLog.writeFile(2, str);

        }

        public void Err(String str)
        {
            Log.ExceptionLog.writeFile(1, str);

        }

        public void Err(Exception ex)
        {
            Log.ExceptionLog.writeFile(ex);
        }

        #endregion
    }
}
