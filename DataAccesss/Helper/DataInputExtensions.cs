using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace DataAccess.Helper
{
    public static class DataInputExtensions
    {
        static public object ExportDbPropertyValues(this DbPropertyValues values)
        {
            var TupleValueList = new List<Tuple<object, string>>();

            foreach (var prop in values.PropertyNames)
            {
                TupleValueList.Add(Tuple.Create(values[prop], prop));
            }
            return TupleValueList;
        }
        public static void SetLastUpdateUser(this object p_object, string value)
        {
            string p_propertyName = "LastUpdateUser";
            PropertyInfo property = p_object.GetType().GetProperty(p_propertyName);
            property.SetValue(p_object, value);
        }
        public static void SetLastUpdateDate(this object p_object, DateTime? value)
        {
            string p_propertyName = "LastUpdateDate";
            PropertyInfo property = p_object.GetType().GetProperty(p_propertyName);
            property.SetValue(p_object, value);
        }
        public static void SetLastInsertedUser(this object p_object, string value)
        {
            string p_propertyName = "LastUpdateUser";
            PropertyInfo property = p_object.GetType().GetProperty(p_propertyName);
            property.SetValue(p_object, value);
        }
        public static void SetLastInsertedDate(this object p_object, DateTime? value)
        {
            string p_propertyName = "LastUpdateDate";
            PropertyInfo property = p_object.GetType().GetProperty(p_propertyName);
            property.SetValue(p_object, value);
        }
    }
}
