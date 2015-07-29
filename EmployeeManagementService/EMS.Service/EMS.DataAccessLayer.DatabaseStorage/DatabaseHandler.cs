using EMS.BusinessDataContract;
using EMS.BusinessInterface;
using EMS.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataAccessLayer.DatabaseStorage
{
   public class DatabaseHandler : IEmployeeStorage
    {
       private SqlConnection DBConnect()
       {
           string machineName = ConfigurationManager.AppSettings["MachineName"];
           string dbName = ConfigurationManager.AppSettings["DBName"];
           string dbId = ConfigurationManager.AppSettings["DBId"];
           string dbPassword = ConfigurationManager.AppSettings["DBPassword"];
           SqlConnection connection = new SqlConnection("Data Source=" + machineName + ";Initial Catalog=" + dbName + ";Persist Security Info=True;User ID=" + dbId + ";Password=" + dbPassword);
           return connection;
       }
        
       public void AddRemark(string id, BusinessLayerRemark remark)
        {
            try
            {
                SqlConnection connection = this.DBConnect();
                connection.Open();
                SqlCommand sqlComand = new SqlCommand("AddRemark", connection);
                sqlComand.CommandType = CommandType.StoredProcedure;

                sqlComand.Parameters.Add(new SqlParameter("id", id));
                sqlComand.Parameters.Add(new SqlParameter("dateTime", remark.DateTime.ToString()));
                sqlComand.Parameters.Add(new SqlParameter("text", remark.Text));
                
                sqlComand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return;
            }
            
        }
        public void Save(BusinessLayerEmployee employee)
        {
            try
            {

                SqlConnection connection = this.DBConnect();

                connection.Open();

                SqlCommand sqlComand = new SqlCommand("CreateEmployee", connection);
                sqlComand.CommandType = CommandType.StoredProcedure;

                sqlComand.Parameters.Add(new SqlParameter("id", employee.Id));
                sqlComand.Parameters.Add(new SqlParameter("title", employee.Title));
                sqlComand.Parameters.Add(new SqlParameter("firstName", employee.FirstName));
                sqlComand.Parameters.Add(new SqlParameter("lastName", employee.LastName));
                sqlComand.Parameters.Add(new SqlParameter("email", employee.Email));

                sqlComand.ExecuteNonQuery();
                connection.Close();
                
                


                List<BusinessLayerRemark> tempList = employee.Remarks;
                for (int i = 0; i < tempList.Count(); i++)
                {
                    AddRemark(employee.Id, tempList.ElementAt(i));
                }
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return;
            }

           

        }
        private List<BusinessLayerRemark> GetRemark(string id)
        {
            try
            {
                SqlConnection connection = this.DBConnect();
                connection.Open();
                SqlCommand command = new SqlCommand("GetRemark", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@id", id));
                var result = command.ExecuteReader();
                
                List<BusinessLayerRemark> remarkList = new List<BusinessLayerRemark>();
                while (result.Read())
                {
                    BusinessLayerRemark remark = new BusinessLayerRemark();
                    remark.DateTime=DateTime.Parse(result[1].ToString());
                    remark.Text = result[2].ToString();
                    remarkList.Add(remark);
                }
                connection.Close();
                return remarkList;
            }
                
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            
        }

        public BusinessLayerEmployee GetById(string id)
        {
            try
            {
                SqlConnection connection = this.DBConnect();
                connection.Open();
                SqlCommand command = new SqlCommand("GetEmployeeById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@id", id));
                var result = command.ExecuteReader();
                BusinessLayerEmployee employee = new BusinessLayerEmployee();
               
                while (result.Read())
                {
                    employee.Id = result[0].ToString();
                    employee.Title = result[1].ToString();
                    employee.FirstName = result[2].ToString();
                    employee.LastName = result[3].ToString();
                    employee.Email = result[4].ToString();
                }
                connection.Close();
                employee.Remarks = this.GetRemark(id);
                return employee;
            }

            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }

        }

        public List<BusinessLayerEmployee> GetAll()
        {
            try
            {
                SqlConnection connection = this.DBConnect();
                connection.Open();

                SqlCommand command = new SqlCommand("GetAll", connection);

                SqlDataReader result = command.ExecuteReader();
               
               
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
                connection.Close();
              
                return tempList;
            }

            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
        }
    }
}
