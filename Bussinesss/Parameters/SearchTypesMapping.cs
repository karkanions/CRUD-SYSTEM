using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Parameters
{
    public enum SearchTypes
    {
        String,
        Number,
        ListBox,
        DateTime,
        Flag
    }
    public static class SearchTypesMapping
    {
        public static SearchTypes GetSearchTypesMappingFromType(Type type, bool isList = false)
        {
            if (isList)
            {
                return SearchTypes.ListBox;
            }

            switch (type)
            {
                case Type _ when type == typeof(Int32):
                case Type _ when type == typeof(Nullable<Int32>):
                case Type _ when type == typeof(Decimal):
                case Type _ when type == typeof(Nullable<Decimal>):
                    return SearchTypes.Number;
                case Type _ when type == typeof(DateTime):
                case Type _ when type == typeof(Nullable<DateTime>):
                    return SearchTypes.DateTime;
                case Type _ when type == typeof(String):
                    return SearchTypes.String;
                case Type _ when type == typeof(bool):
                    return SearchTypes.Flag;
                default:
                    return SearchTypes.String;
            }


            
        }
    }
}
