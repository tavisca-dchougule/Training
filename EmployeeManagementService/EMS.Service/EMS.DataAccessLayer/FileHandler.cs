using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using EMS.BusinessDataContract;
using EMS.EnterpriseLibrary;
using EMS.BServiceContract;
using EMS.BusinessServiceContract;

namespace EMS.DataAccessLayer
{
    public class FileHandler : IEmployeeStorage
    {

        public void Save(BusinessLayerEmployee employee)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            try
            {
                stream = new FileStream(@"D:\Employee Data\" + employee.Id + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, employee);
                stream.Close();
            }
            catch (Exception e)
            {
               
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return;
            }

        }
        public BusinessLayerEmployee GetById(string id)
        {
            
            BusinessLayerEmployee employee = null;
            try
            {
                foreach (string file in Directory.EnumerateFiles(@"D:\Employee Data\", "*.bin"))
                {
                    string path = @"D:\Employee Data\" + id + ".bin";
                    if (string.Equals(file, path, StringComparison.OrdinalIgnoreCase))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                        employee = (BusinessLayerEmployee)formatter.Deserialize(stream);
                        stream.Close();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
               
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            return employee;
        }



        public List<BusinessLayerEmployee> GetAll()
        {
            List<BusinessLayerEmployee> allEmployeeList = new List<BusinessLayerEmployee>();
            Stream stream = null;
            IFormatter formatter = null;
            try
            {
                foreach (string file in Directory.EnumerateFiles(@"D:\Employee Data\", "*.bin"))
                {
                    formatter = new BinaryFormatter();
                    stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                    allEmployeeList.Add((BusinessLayerEmployee)formatter.Deserialize(stream));
                }
                stream.Close();
            }
            catch (Exception e)
            {
                
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            return allEmployeeList;
        }
    }
}
