using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public class Enums
    {

        public enum SortDirection
        {
            OrderBy,
            OrderByDescending
        }
         
        public enum ModificationType
        {
            Insert=1,
            Update=2,
            Delete=3
        }
        public enum Operators
        {
            [EnumMember(Value = "<")]
            LessThan,
            [EnumMember(Value = "<=")]
            LessThanEqualTo,
            [EnumMember(Value = ">")]
            GreaterThan,
            [EnumMember(Value = ">=")]
            GreaterThanEqualTo,
            [EnumMember(Value = "=")]
            EqualTo,
            [EnumMember(Value = "!=")]
            DifferentTo   
        }
    }
}
