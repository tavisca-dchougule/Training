using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.BDataContract
{
    
    [Serializable]
    public class BusinessEmployee
    {
        public BusinessRemark BusinessRemark
        {
            get;
            set;
        }
        public string Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }


        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
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
        public BusinessEmployee()
        {
            BusinessRemark = new BusinessRemark();
        }
        public BusinessEmployee(string id, string title, string firstname, string lastName, string email, BusinessRemark businessRemark)
        {
            
            this.Id = id;
            this.Title = title;
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Email = email;
            this.BusinessRemark = businessRemark;
        }
    }
}
