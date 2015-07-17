using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class TestMethodAttribute : Attribute
{
    public TestMethodAttribute()
    {

    }
    public static bool Exists(MethodInfo type)
    {
        foreach (object attribute in type.GetCustomAttributes(true))
        {
            if (attribute is TestMethodAttribute)
            {
                return true;
            }
        }
        return false;
    }

}