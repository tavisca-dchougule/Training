using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.DataContract
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public List <Remark> Remarks
        {
            get;
            set;
        }
        
        [DataMember]
        public string Id
        {
            get;
            set;
        }

        [DataMember]
        public string Title
        {
            get;
            set;
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }
        [DataMember]
        public string LastName
        {
            get;
            set;
        }
        [DataMember]
        public string Email
        {
            get;
            set;
        }


    
        public Employee()
        {
            Remarks = new List<Remark>();
        }
        public Employee(string id, string title, string firstname, string lastName, string email, List<Remark> serviceRemark)
        {
            
            this.Id = id;
            this.Title = title;
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Email = email;
            this.Remarks= serviceRemark;

        }
        public void AddData()
        {
            Console.WriteLine("Enter Id:");
            this.Id = Console.ReadLine();

            Console.WriteLine("Enter Title:");
            this.Title = Console.ReadLine();

            Console.WriteLine("Enter First name:");
            this.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            this.LastName = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            this.Email = Console.ReadLine();
        }
        public void Display()
        {
            Console.WriteLine("Enter Id:" + this.Id);


            Console.WriteLine("Enter Title:" + this.Title);


            Console.WriteLine("Enter First name:" + this.FirstName);


            Console.WriteLine("Enter Last Name:" + this.LastName);


            Console.WriteLine("Enter Email:" + this.Email);

        }
    }
}
