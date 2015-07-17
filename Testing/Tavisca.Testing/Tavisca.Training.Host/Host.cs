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
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid Arguments.");
                Console.ReadKey();
                return;
            }
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
            string category = "";
            try
            {
                category = args[1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            
            foreach (Type type in assembly.GetTypes()) //test for each class in assembly
            {
                  if (type.IsClass && TestClassAttribute.Exists(type))
                  {
                             Console.WriteLine("class name: {0}", type.FullName);
                            
                            foreach (MethodInfo method in (type.GetMethods()))
                            { 
                                if (TestMethodAttribute.Exists(method))
                                {
                                    if (IgnoreAttribute.Exists(method))
                                    {    
                                      Console.WriteLine("Ignored  method: {0}", method.Name);   
                                    }

                                    else if (CategoryAttribute.Exists(method, category))
                                        Console.WriteLine("Executable  method: {0}\n", method.Name);
                                } 
                            }
                  }
            }     
            Console.ReadKey();
        }
    }
}
