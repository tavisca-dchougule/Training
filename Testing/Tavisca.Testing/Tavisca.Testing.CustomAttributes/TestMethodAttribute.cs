using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

[AttributeUsage(AttributeTargets.Method)]
public class TestMethodAttribute : Attribute
{
    public TestMethodAttribute()
    {

    }

}