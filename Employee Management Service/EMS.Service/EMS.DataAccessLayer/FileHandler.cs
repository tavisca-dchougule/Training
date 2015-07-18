using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using EMS.BDataContract;


namespace EMS.DataAccessLayer
{
    public class FileHandler
    {

        public void Save(BusinessEmployee employee)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Employee Data\" + employee.Id + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, employee);
            stream.Close();
        }
        public BusinessEmployee GetById(string id)
        {
            BusinessEmployee employee = null;
            foreach (string file in Directory.EnumerateFiles(@"D:\Employee Data\", "*.bin"))
            {
                string path = @"D:\Employee Data\" + id + ".bin";
                if (string.Equals(file, path, StringComparison.OrdinalIgnoreCase))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    employee = (BusinessEmployee)formatter.Deserialize(stream);
                    stream.Close();
                    break;
                }
            }
            return employee;
        }

      

        public List<BusinessEmployee> GetAll()
        {
            List<BusinessEmployee> allEmployeeList = new List<BusinessEmployee>();
            Stream stream = null;
            IFormatter formatter = null;
            foreach (string file in Directory.EnumerateFiles(@"D:\Employee Data\", "*.bin"))
            {

                formatter = new BinaryFormatter();
                stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                allEmployeeList.Add((BusinessEmployee)formatter.Deserialize(stream));
            }
            stream.Close();
            return allEmployeeList;
        }
    }
}
