using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Testing.Model
{
        [TestClass]
        public class Class2
        {
             [TestMethod]
            public void Test1()
            {
            }
             [Ignore]
            [TestMethod]
            public void Test2()
            {
            }
             [TestMethod]
             [Category("Smoke Test")]
            public void Test3()
            {
            }
        }
    
}
