using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace AuthenticationForm.Model
{
    public class Serializer
    {
        public static string Serialize<T>(T data)
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(ms, data);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                return sr.ReadToEnd();
            }
        }

        public static T Deserialize<T>(string data)
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                using (StreamWriter writer = new StreamWriter(ms))
                {
                    writer.Write(data);
                    writer.Flush();

                    ms.Position = 0;
                    return (T)serializer.ReadObject(ms);
                }
            }
        }
    }
}