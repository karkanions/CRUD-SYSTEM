using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Helper;
using static DataAccess.Helper.Enums;

namespace DataAccess.Helper
{
    public class FilterItems
    {
        public string Name { get; set; }
        public Operators Operators { get; set; }
        public object Value { get; set; }

    }
}
