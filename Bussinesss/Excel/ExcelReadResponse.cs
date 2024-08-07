using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinesss.Excel
{
    public class ExcelReadResponse
    {
        public System.Data.DataTable dataTable { get; set; }
        public bool isValid { get; set; }
    }
}
