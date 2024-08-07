using AutoMapper;
using System;
using System.Reflection;

namespace Bussinesss.Mapping
{
    /// <summary>
    /// /
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>

    public class DateTimeTypeConverter : AutoMapper.ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return System.Convert.ToDateTime(source);
        }
    }

    public class TypeTypeConverter : AutoMapper.ITypeConverter<string, Type>
    {
        public Type Convert(string source, Type destination, ResolutionContext context)
        {
            return Assembly.GetExecutingAssembly().GetType(source);
        }
    }

    public class DoubleToIntTypeConverter : AutoMapper.ITypeConverter<double, int>
    {
        int ITypeConverter<double, int>.Convert(double source, int destination, ResolutionContext context)
        {
            return System.Convert.ToInt32(source);
        }
    }

}
