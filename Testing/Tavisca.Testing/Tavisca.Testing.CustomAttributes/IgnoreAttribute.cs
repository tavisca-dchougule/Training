using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class IgnoreAttribute : Attribute
{
    public IgnoreAttribute()
    {
    }
    public static bool Exists(MethodInfo type)
    {
        foreach (object attribute in type.GetCustomAttributes(true))
        {
            if (attribute is IgnoreAttribute)
            {
                return true;
            }
        }
        return false;
    }
   
}