using EMS.BusinessDataContract;
using EMS.BusinessInterface;
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
   public class PostCallDBHandler : IEmployeeStoragePostCall
    {
       
       public BusinessLayerRemark AddRemark(string id, BusinessLayerRemark remark)
        {
            int iConn = 0;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            try
            {
                
                SqlConnection connection = (SqlConnection)dbPool.GetConnection(out iConn);
                
                SqlCommand sqlComand = new SqlCommand("AddRemark", connection);
                sqlComand.CommandType = CommandType.StoredProcedure;
                sqlComand.Parameters.Add(new SqlParameter("empId", id));
                sqlComand.Parameters.Add(new SqlParameter("dateTime", remark.DateTime.ToString()));
                sqlComand.Parameters.Add(new SqlParameter("text", remark.Text));
                
                sqlComand.ExecuteNonQuery();
                return remark;
                
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("DataLayerPolicy", e);
                if (rethrow) throw e;
                return null;
            }
            finally
            {
                dbPool.FreeConnection(iConn);
            }
            
        }
        public BusinessLayerEmployee Save(BusinessLayerEmployee employee)
        {
            int iConn = 0;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            try
            {         
                SqlConnection connection = (SqlConnection)dbPool.GetConnection(out iConn);
                

                SqlCommand sqlComand = new SqlCommand("CreateEmployee", connection);
                sqlComand.CommandType = CommandType.StoredProcedure;

                sqlComand.Parameters.Add(new SqlParameter("title", employee.Title));
                sqlComand.Parameters.Add(new SqlParameter("firstName", employee.FirstName));
                sqlComand.Parameters.Add(new SqlParameter("lastName", employee.LastName));
                sqlComand.Parameters.Add(new SqlParameter("email", employee.Email));
                sqlComand.Parameters.Add(new SqlParameter("designation", employee.Designation));
                sqlComand.Parameters.Add(new SqlParameter("password", employee.Password));

                sqlComand.ExecuteNonQuery();
               
                if (employee.Remarks != null)
                {
                    List<BusinessLayerRemark> tempList = employee.Remarks;
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        AddRemark(employee.Id, tempList.ElementAt(i));
                    }
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
                dbPool.FreeConnection(iConn);
            }
           

        }
       
    }
}
