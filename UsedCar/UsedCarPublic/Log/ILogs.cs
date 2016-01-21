using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsedCarPublic.Log
{
    public interface ILogs
    {
        void Debug(string str);
        void Err(Exception ex);
        void Err(string str);
        void Info(string str);
    }
}
