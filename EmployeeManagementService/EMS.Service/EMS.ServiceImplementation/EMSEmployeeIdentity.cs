using EMS.BDataContract;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ServiceImplementation
{
    class EMSEmployeeIdentity : IEmployeeIdentity
    {
        public EmployeeResponse Authenticate(Credential credential)
        {
            EmployeeResponse response = new EmployeeResponse();
            if (credential == null)
            {
                ArgumentNullException e = new ArgumentNullException();
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;
            }
            BusinessLayerEmployee businessEmployee = null;
            CredentialTranslator credentialTranslator = new CredentialTranslator();
            BusinessLayerCredential businessCredential = credentialTranslator.ConvertToBusinessCredential(credential);
            
            try
            {
                IUnityContainer container = Factory.GetUnityConfiguration();
                IEmployeeIdentityManager dataManager = container.Resolve<IEmployeeIdentityManager>();
                businessEmployee = dataManager.Authenticate(businessCredential);
            }
            catch (Exception e)
            {
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode="500";
                response.Status.Message = e.Message;
                return response;
            }
            EmployeeTranslator translator = new EmployeeTranslator();
            Employee serviceEmployee = translator.ConvertToServiceEmployee(businessEmployee);

            response.Employee = serviceEmployee;
            return response;
        }

        public EmployeeResponse ChangePassword(ChangeCredential changePassword)
        {
            EmployeeResponse response = new EmployeeResponse();
            if (changePassword == null)
            {
                ArgumentNullException e = new ArgumentNullException();
                ExceptionPolicy.HandleException("ServiceLayerPolicy", e);
                response.Status.StatusCode = "500";
                response.Status.Message = e.Message;
                return response;            
            }

            Employee serviceEmployee = null;
            try
            {

                IUnityContainer container = Factory.GetUnityConfiguration();
                IEmployeeIdentityManager implementor = container.Resolve<IEmployeeIdentityManager>();

                ChangePasswordTranslator changePasswordTranslator = new ChangePasswordTranslator();
                EmployeeTranslator employeeTranslator = new EmployeeTranslator();
                BusinessLayerChangePassword businessChangePassword = changePasswordTranslator.ConvertToBusinessChangePassword(changePassword);
                BusinessLayerEmployee businessLayerEmployee = implementor.ChangePassword(businessChangePassword);
                serviceEmployee = employeeTranslator.ConvertToServiceEmployee(businessLayerEmployee);
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
    }
}
