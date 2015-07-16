using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Testing.Model;


namespace Tavisca.Training.Host
{
    class Host
    {

        static void Main(string[] args)
        {
            Assembly assembly = null;
            try
            {
                 assembly = Assembly.LoadFrom(args[0]);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Enter category:");
            string category = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(category) == true)
            {
                Console.WriteLine("Invalid Category.");
                Console.ReadKey();
                return;
            }
            
            foreach (Type type in assembly.GetTypes()) //test for each class in assembly
            {
                 if (type.IsClass)
                 {
                     Attribute[] ClassAttributes = Attribute.GetCustomAttributes(type);  // Reflection.
                     foreach (Attribute attribute in ClassAttributes) //test for each attribute of that class   
                     {
                         if (attribute is TestClassAttribute)
                         {
                             Console.WriteLine("class name: {0}", type.FullName);
                             MethodInfo[] myArrayMethodInfo = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                             for (int i = 0; i < myArrayMethodInfo.Length; i++)//test for each method in that class
                             {
                                 Attribute[] methodAttributes = myArrayMethodInfo[i].GetCustomAttributes().ToArray();
                                 foreach (Attribute methodAttribute in methodAttributes)
                                 {

                                     if (methodAttribute is IgnoreAttribute)
                                     {
                                         Console.WriteLine("Ignore Method: {0}", myArrayMethodInfo[i].Name);

                                     }
                                     if (methodAttribute is TestMethodAttribute)
                                     {
                                         Console.WriteLine("Test Method: {0}", myArrayMethodInfo[i].Name);


                                     }
                                     if (methodAttribute is CategoryAttribute)
                                     {
                                         CategoryAttribute categoryAttribute = methodAttribute as CategoryAttribute;
                                         if (string.Equals(category, categoryAttribute.Category, StringComparison.OrdinalIgnoreCase))
                                         {
                                             Console.WriteLine("Category Method: {0} with category: {1}", myArrayMethodInfo[i].Name, category);
                                         }
                                     }
                                 }
                             }
                             Console.WriteLine();

                         }
                     }
                 }

            }
           
            Console.ReadKey();
        }
    }
}
