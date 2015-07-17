using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

[AttributeUsage(AttributeTargets.Class)]
public class TestClassAttribute : Attribute
{
    public TestClassAttribute()
    {

    }
    public static bool Exists(Type type)
    {
        foreach (object attribute in type.GetCustomAttributes(true))
        {
            if (attribute is TestClassAttribute)
            {
                return true;
            }
        }
        return false;
    }

}