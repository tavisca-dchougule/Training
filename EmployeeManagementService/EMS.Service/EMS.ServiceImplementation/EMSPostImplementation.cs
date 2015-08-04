using EMS.BusinessDataContract;
using EMS.BusinessImplementation;
using EMS.BusinessInterface;
using EMS.DataContract;
using EMS.EnterpriseLibrary;
using EMS.EnterpriseLibrary.Unity;
using EMS.ServiceContract;
using EMS.Translator;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMS.ServiceImplementation
{

    public class EMSPostImplementation :IEmployeeManagementService
    {
        public EmployeeResponse Create(Employee employee)
        {
            EmployeeResponse response = new EmployeeResponse();
            if (employee == null)
            {
                ArgumentNullException e = new ArgumentNullException();
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;         
            }       
            EmployeeTranslator employeeTranslator = new EmployeeTranslator();
            BusinessLayerEmployee businessLayerEmployee = employeeTranslator.ConvertToBusinessEmployee(employee);
            Employee serviceEmployee = null;
            try
            {
                IUnityContainer container = Factory.GetUnityConfiguration();
                IEmployeeManagementManager implementor = container.Resolve<IEmployeeManagementManager>();
                serviceEmployee = employeeTranslator.ConvertToServiceEmployee(implementor.Create(businessLayerEmployee));
            }
            catch (Exception e)
            {
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;       
            }
            response.Employee = serviceEmployee;
            return response; 
        }


        public RemarkResponse AddRemark(string employeeId, Remark remark)
        {
            RemarkResponse response = new RemarkResponse();
            if (employeeId == null || remark == null)
            {
                ArgumentNullException e = new ArgumentNullException();
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;
               
            }
           
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeManagementManager implementor = container.Resolve<IEmployeeManagementManager>();
           
            RemarkTranslator remarkTranslator = new RemarkTranslator();
            BusinessLayerRemark businessRemark = remarkTranslator.ConvertToBusinessRemark(remark);
            Remark serviceRemark = null;
            try
            {
                 serviceRemark = remarkTranslator.ConvertToServiceRemark(implementor.AddRemark(employeeId, businessRemark));
            }
            catch (Exception e)
            {

                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;
            }
            response.Remark = serviceRemark;
            return response;

        }
    }
}
