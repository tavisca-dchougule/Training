using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class CategoryAttribute : Attribute
{
    public string Category
    {
        get;
        set;
    }
    public CategoryAttribute(String category)
    {
        Category = category;
    }
    public static bool Exists(MethodInfo memberInfo, string category)
    {
        foreach (object attribute in memberInfo.GetCustomAttributes(true))
        {
            if (attribute is CategoryAttribute)
            {
                var attr = attribute as CategoryAttribute;
                if (attr.Category != null)
                    if (attr.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                        return true;
            }
        }
        return false;
    }

}