using EMS.BDataContract;
using EMS.BusinessDataContract;
using EMS.BusinessInterface.DBHandler;
using EMS.DataAccessLayer.DBConnectionPool;
using EMS.EnterpriseLibrary;
using EMS.ErrorSpace;
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
   public class EmployeeIdentityDBHandler : IEmployeeStorageIdentity
    {
        public BusinessLayerEmployee Authenticate(BusinessLayerCredential credential)
        {
            int iConn = 0;
            SqlDataReader result = null;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            try
            {    
                SqlConnection connection =(SqlConnection) dbPool.GetConnection(out iConn);
                SqlCommand command = new SqlCommand("AuthenticateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@email", credential.UserName));
                command.Parameters.Add(new SqlParameter("@password", credential.Password));
                 result = command.ExecuteReader();
                BusinessLayerEmployee employee = new BusinessLayerEmployee();

                bool isValid = result.HasRows;
                if (isValid == false)
                {
                    throw new LoginFailedException();
                }
                while (result.Read())
                {
                    employee.Id = result[0].ToString();
                    employee.Title = result[1].ToString();
                    employee.FirstName = result[2].ToString();
                    employee.LastName = result[3].ToString();
                    employee.Email = result[4].ToString();
                    employee.Designation = result[5].ToString();
                    employee.Password = result[6].ToString();
                }      
                return employee;
            }
            catch (Exception e)
            {        
                var rethrow = ExceptionPolicy.HandleException("DataLayerPolicy", e);
                if (rethrow) throw e;
                return null;
            }
            finally
            {
                if (result != null)
                result.Close();
                dbPool.FreeConnection(iConn);
            }  
        }
        public BusinessLayerEmployee ChangePassword(BusinessLayerChangePassword changePassword)
        {
            int iConn = 0;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            SqlDataReader result = null;
            try
            {
                SqlConnection connection = (SqlConnection)dbPool.GetConnection(out iConn);

                SqlCommand sqlComand = new SqlCommand("ChangePassword", connection);
                sqlComand.CommandType = CommandType.StoredProcedure;
                sqlComand.Parameters.Add(new SqlParameter("userName", changePassword.UserName));
                sqlComand.Parameters.Add(new SqlParameter("oldPassword", changePassword.OldPassword));
                sqlComand.Parameters.Add(new SqlParameter("newPassword", changePassword.NewPassword));

                var isSuccess = sqlComand.ExecuteNonQuery();
                if (isSuccess == 0)
                {
                    throw new PasswordChangeFailedException();
                }
                dbPool.FreeConnection(iConn);

                connection = (SqlConnection)dbPool.GetConnection(out iConn);

                SqlCommand command = new SqlCommand("GetEmployeeByEmail", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@email", changePassword.UserName));
                result = command.ExecuteReader();
                BusinessLayerEmployee employee = new BusinessLayerEmployee();

                while (result.Read())
                {
                    employee.Id = result[0].ToString();
                    employee.Title = result[1].ToString();
                    employee.FirstName = result[2].ToString();
                    employee.LastName = result[3].ToString();
                    employee.Email = result[4].ToString();
                    employee.Designation = result[5].ToString();
                    employee.Password = result[6].ToString();
                }
                
                return employee;
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("DataLayerPolicy", e);
                if (rethrow) throw e;
                return null;
            }
            finally
            {
                if(result!=null)
                result.Close();
                dbPool.FreeConnection(iConn);
            }

        }
    }
}
