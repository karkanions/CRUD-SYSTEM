using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Bussiness.Helper
{
    public static class ExtensionMethods
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        public static List<DataGridViewColumn> CloneDataGridColumns(this DataGridViewColumnCollection listToClone)
        {
            return listToClone.Cast<DataGridViewColumn>().ToList().Select(item => (DataGridViewColumn)item.Clone()).ToList();
        }
        //public static List<GridView> CloneDataGridColumns(this DataControlFieldCollection listToClone)
        //{
        //    return listToClone.Cast <GridView>().ToList().Select(item => (GridView)item).ToList();
        //}


        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static void SetPropValue(this Object obj, String name, object value)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return; }

                info.SetValue(obj, value);
            }
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default; }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

    }
}
