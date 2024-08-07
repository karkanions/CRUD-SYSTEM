using Bussiness.Helper;
using Bussiness.Parameters;
using DataAccess.Helper;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DWEFormsWeb.Settings
{
    public static class Settings
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public static IList<TablesDto> listOfTables;
        public static Bussiness.Excel.ExcelValidation ex;
        public static Bussiness.Settings.BussinessSettings bl;
        public static List<ColumnAccess> ColumnAccesseList = new List<ColumnAccess>();
        public static bool hasChanges = false;
        public static FilterItems filter = null;
        public static Bussiness.Parameters.TablesDto SelectedClass;
        public static List<DataGridItem> s = new List<DataGridItem>(); 
    }

}
    