using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWEFormsWeb.Settings
{
    public class Log
    {
        public static NLog.Logger logger = LogManager.GetCurrentClassLogger();
    }
}