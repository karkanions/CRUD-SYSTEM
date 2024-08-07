using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bussinesss.Helper
{
    public class EnumHelp
    {
        public class EnumWithName<T>
        {
            public string Name { get; set; }
            public T Value { get; set; }

            public static EnumWithName<T>[] ParseEnum()
            {
                List<EnumWithName<T>> list = new List<EnumWithName<T>>();
                var members = typeof(T)
                                 .GetTypeInfo()
                                 .DeclaredMembers;

                foreach (var member in members)
                {
                    if (member.CustomAttributes.Count() > 0)
                    {
                        list.Add(new EnumWithName<T>
                        {
                            Name = member.CustomAttributes.FirstOrDefault().NamedArguments.FirstOrDefault().TypedValue.Value.ToString(),
                            Value = (T)Enum.Parse(typeof(T), member.Name) //(T)member
                        });
                    }
                }

                return list.ToArray();
            }
        }
    }
}
