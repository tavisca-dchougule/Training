using EMS.BusinessDataContract;
using EMS.BusinessImplementation;
using EMS.DataContract;
using EMS.ServiceContract;
using EMS.Translator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EMS.EnterpriseLibrary;
using Microsoft.Practices.Unity;
using EMS.EnterpriseLibrary.Unity;
using EMS.BusinessInterface;

namespace EMS.ServiceImplementation
{

    public class EMSGetImplementation : IEmployeeService
    {
       
        public EmployeeResponse Get(string employeeId)
        {
            EmployeeResponse response = new EmployeeResponse();
            if (employeeId == null)
            {
                ArgumentNullException e = new ArgumentNullException();
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;
            }
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeManager implementor = container.Resolve<IEmployeeManager>();
          
            Employee serviceEmployee = null;
            BusinessLayerEmployee businessEmployee = null;
            try
            {
                 businessEmployee = implementor.GetEmployee(employeeId);
               
            }
            catch (Exception e)
            {
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
               response.Status.StatusCode = "500";
               response.Status.Message = e.Message;
               return response; 
            }
            EmployeeTranslator employeeTranslator = new EmployeeTranslator();
            serviceEmployee = employeeTranslator.ConvertToServiceEmployee(businessEmployee);
            response.Employee = serviceEmployee;
            return response;
        }
        public GetAllEmployeeResponse GetAll()
        {        
            List<BusinessLayerEmployee> businessEmployeeList = null;
            GetAllEmployeeResponse response = new GetAllEmployeeResponse();
            try
            {
                IUnityContainer container = Factory.GetUnityConfiguration();
                IEmployeeManager implementor = container.Resolve<IEmployeeManager>();
                 businessEmployeeList = implementor.GetAll();
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;
            }
            EmployeeTranslator employeeTranslator = new EmployeeTranslator();
            List<Employee> serviceEmployeeList = new List<Employee>();

            BusinessLayerEmployee tempBusinessEmployee = null;
           
            for (int i = 0; i < businessEmployeeList.Count(); i++)
            {
                tempBusinessEmployee = businessEmployeeList.ElementAt(i);
                serviceEmployeeList.Add(employeeTranslator.ConvertToServiceEmployee(tempBusinessEmployee));
            }
            response.AllEmployeeList = serviceEmployeeList;
            return response;
        }
        public PaginationRemarkListResponse GetRemark(string employeeId,string pageNumber, string rows)
        {

            PaginationRemarkListResponse response = new PaginationRemarkListResponse();
            if (employeeId == null || pageNumber==null || rows==null)
            {
                ArgumentNullException e = new ArgumentNullException();
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;
            }
            
            List<BusinessLayerRemark> businessRemarkList = null;
            try
            {
                IUnityContainer container = Factory.GetUnityConfiguration();
                IEmployeeManager implementor = container.Resolve<IEmployeeManager>();
                businessRemarkList = implementor.GetRemark(employeeId,pageNumber,rows);
            }
            catch (Exception e)
            {
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                 response.Status.StatusCode = "500";
                 response.Status.Message = e.Message;
                 return response;
               
            }
            RemarkTranslator remarkTranslator = new RemarkTranslator();
            List<Remark> serviceRemarkList = new List<Remark>();

            BusinessLayerRemark tempBusinessRemark = null;

            for (int i = 0; i < businessRemarkList.Count(); i++)
            {
                tempBusinessRemark = businessRemarkList.ElementAt(i);
                serviceRemarkList.Add(remarkTranslator.ConvertToServiceRemark(tempBusinessRemark));
            }
            response.PaginationRemarkList = serviceRemarkList;
            return response;
        }
        public RemarkCountResponse GetRemarkCount(string employeeId)
        {
            RemarkCountResponse response = new RemarkCountResponse();
            if (employeeId == null )
            {
                ArgumentException e = new ArgumentNullException();
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;
            }
          
            int remarkCount = 0;
            try
            {
                IUnityContainer container = Factory.GetUnityConfiguration();
                IEmployeeManager implementor = container.Resolve<IEmployeeManager>();
                remarkCount = implementor.GetRemarkCount(employeeId);
            }
            catch (Exception e)
            {
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
               response.Status.StatusCode = "500";
               response.Status.Message = e.Message;
               return response;            
            }
            response.RemarkCount = remarkCount;
            return response;
        }
    }
}
