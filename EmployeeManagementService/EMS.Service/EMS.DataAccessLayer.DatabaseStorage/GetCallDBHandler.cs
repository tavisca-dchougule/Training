using EMS.BusinessDataContract;
using EMS.BusinessInterface.DBHandler;
using EMS.DataAccessLayer.DBConnectionPool;
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
    public class GetCallDBHandler : IEmployeeStorageGetCall
    {
        private List<BusinessLayerRemark> GetRemark(string id)
        {
            int iConn = 0;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            SqlDataReader result = null;
            try
            {           
                SqlConnection connection = (SqlConnection)dbPool.GetConnection(out iConn);
                SqlCommand command = new SqlCommand("GetRemark", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@empId", id));
                result = command.ExecuteReader();

                List<BusinessLayerRemark> remarkList = new List<BusinessLayerRemark>();
                while (result.Read())
                {
                    BusinessLayerRemark remark = new BusinessLayerRemark();
                    remark.DateTime = DateTime.Parse(result[2].ToString());
                    remark.Text = result[3].ToString();
                    remarkList.Add(remark);
                }    
                return remarkList;
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
        public List<BusinessLayerRemark> GetRemark_Pagination(string id,string pageNumber,string rows)
        {
            int iConn = 0;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            SqlDataReader result = null;
            try
            {
                
                SqlConnection connection = (SqlConnection)dbPool.GetConnection(out iConn);
                
                SqlCommand command = new SqlCommand("PaginationGetRemark", connection);
                command.CommandType = CommandType.StoredProcedure;
                  
                command.Parameters.Add(new SqlParameter("@empId", int.Parse(id)));
                command.Parameters.Add(new SqlParameter("@pageNum", int.Parse(pageNumber)));
                command.Parameters.Add(new SqlParameter("@rows", int.Parse(rows)));
                 result = command.ExecuteReader();

                List<BusinessLayerRemark> remarkList = new List<BusinessLayerRemark>();
                while (result.Read())
                {
                    BusinessLayerRemark remark = new BusinessLayerRemark();
                    remark.DateTime = DateTime.Parse(result[2].ToString());
                    remark.Text = result[3].ToString();
                    remarkList.Add(remark);
                }
                
                return remarkList;
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

        public int GetRemarkCount(string employeeId)
        {
            int iConn = 0;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            SqlDataReader result = null;
            try
            {
                
                SqlConnection connection = (SqlConnection)dbPool.GetConnection(out iConn);
              
                SqlCommand command = new SqlCommand("GetRemarkCount", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@empId", employeeId));
                
                result = command.ExecuteReader();
                int remarkCount = 0;
                while (result.Read())
                {
                    remarkCount = int.Parse(result[0].ToString());
                   
                }
               
                return remarkCount;
            }

            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("DataLayerPolicy", e);
                if (rethrow) throw e;
                return 0;
            }
            finally
            {
                if (result != null)
                result.Close();
                dbPool.FreeConnection(iConn);
            }

        }

        public BusinessLayerEmployee GetById(string id)
        {
            int iConn = 0;
            SqlDataReader result = null;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            try
            {
                
                SqlConnection connection = (SqlConnection)dbPool.GetConnection(out iConn);
                
                SqlCommand command = new SqlCommand("GetEmployeeById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@empId", id));
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
                    employee.Password = null;
                }
                
                employee.Remarks = this.GetRemark(id);
               
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

        public List<BusinessLayerEmployee> GetAll()
        {
            int iConn = 0;
            SqlDataReader result = null;
            DBPool dbPool = DBPool.GetDBPoolInstance();
            try
            {
                
                SqlConnection connection = (SqlConnection)dbPool.GetConnection(out iConn);
                SqlCommand command = new SqlCommand("GetAll", connection);

                result = command.ExecuteReader();


                List<BusinessLayerEmployee> tempList = new List<BusinessLayerEmployee>();
                while (result.Read())
                {
                    BusinessLayerEmployee employee = new BusinessLayerEmployee();
                    employee.Id = result[0].ToString();

                    employee.Title = result[1].ToString();
                    employee.FirstName = result[2].ToString();
                    employee.LastName = result[3].ToString();
                    employee.Email = result[4].ToString();
                    employee.Designation = result[5].ToString();
                    employee.Password = null;
                    tempList.Add(employee);
                }              
                return tempList;
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
    }
}
