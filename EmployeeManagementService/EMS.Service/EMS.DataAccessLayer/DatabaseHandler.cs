using EMS.BusinessDataContract;
using EMS.BusinessServiceContract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataAccessLayer
{
   public class DatabaseHandler : IEmployeeStorage
    {
        
       public void AddRemark(BusinessLayerEmployee employee, BusinessLayerRemark remark)
        {
            SqlConnection remarkConnection = new SqlConnection("Data Source=TRAINING7;Initial Catalog=EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
            remarkConnection.Open();
           
                SqlCommand sqlComand = new SqlCommand("insert into Remark values(@id,@dateTime,@text)", remarkConnection);
                SqlParameter p1 = new SqlParameter("id", employee.Id);
                SqlParameter p2 = new SqlParameter("dateTime", remark.DateTime.ToString());
                SqlParameter p3 = new SqlParameter("text", remark.Text);
                sqlComand.Parameters.Add(p1);
                sqlComand.Parameters.Add(p2);
                sqlComand.Parameters.Add(p3);

                sqlComand.ExecuteNonQuery();
                remarkConnection.Close();
            
        }
        public void Save(BusinessLayerEmployee employee)
        {
            SqlConnection employeeConnection = new SqlConnection("Data Source=TRAINING7;Initial Catalog=EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
            employeeConnection.Open();

            SqlCommand sqlComand = new SqlCommand("insert into Employee values(@id,@title,@firstName,@lastName,@email)", employeeConnection);
            SqlParameter p1 = new SqlParameter("id", employee.Id);
            SqlParameter p2 = new SqlParameter("title", employee.Title);
            SqlParameter p3 = new SqlParameter("firstName", employee.FirstName);
            SqlParameter p4 = new SqlParameter("lastName", employee.LastName);
            SqlParameter p5 = new SqlParameter("email", employee.Email);
          
            sqlComand.Parameters.Add(p1);
            sqlComand.Parameters.Add(p2);
            sqlComand.Parameters.Add(p3);
            sqlComand.Parameters.Add(p4);
            sqlComand.Parameters.Add(p5);

            sqlComand.ExecuteNonQuery();
            employeeConnection.Close();
          
           
            List<BusinessLayerRemark> tempList = employee.Remarks;
            for (int i = 0; i < tempList.Count(); i++)
            {
                AddRemark(employee, tempList.ElementAt(i));
            }

           

        }
        private List<BusinessLayerRemark> GetRemark(string id)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=TRAINING7;Initial Catalog=EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Remark where Id = '" + id + "'", con);
                var result = cmd.ExecuteReader();
                List<BusinessLayerRemark> remarkList = new List<BusinessLayerRemark>();
                while (result.Read())
                {
                    BusinessLayerRemark remark = new BusinessLayerRemark();
                    remark.DateTime=DateTime.Parse(result[1].ToString());
                    remark.Text = result[2].ToString();
                    remarkList.Add(remark);
                }
                con.Close();
                return remarkList;
            }
                
            catch (Exception ex)
            {
               throw ex;
            }
            
        }

        public BusinessLayerEmployee GetById(string id)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=TRAINING7;Initial Catalog=EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Employee where Id = '" + id + "'", con);
                var result = cmd.ExecuteReader();
               BusinessLayerEmployee employee = new BusinessLayerEmployee();
                while (result.Read())
                {
                    employee.Id = result[0].ToString();

                    employee.Title = result[1].ToString();
                    employee.FirstName = result[2].ToString();
                    employee.LastName = result[3].ToString();
                    employee.Email = result[4].ToString();
                }
                con.Close();
                employee.Remarks = this.GetRemark(id);
                return employee;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<BusinessLayerEmployee> GetAll()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=TRAINING7;Initial Catalog=EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Employee", con);
                var result = cmd.ExecuteReader();
               
                List<BusinessLayerEmployee> tempList = new List<BusinessLayerEmployee>();
                while (result.Read())
                {
                    BusinessLayerEmployee employee = new BusinessLayerEmployee();
                    employee.Id = result[0].ToString();

                    employee.Title = result[1].ToString();
                    employee.FirstName = result[2].ToString();
                    employee.LastName = result[3].ToString();
                    employee.Email = result[4].ToString();
                    tempList.Add(employee);
                }
                con.Close();
              
                return tempList;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
