using Bussiness.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bussiness.Helper
{
    public class ColumnAccess
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public SearchTypes Type { get; set; }
        public List<object> DataList { get; set; }
        public bool Visible { get; set; }
        public string ComboDisplayMember { get; set; }
        public string ComboValueMember { get; set; }
    }
}
