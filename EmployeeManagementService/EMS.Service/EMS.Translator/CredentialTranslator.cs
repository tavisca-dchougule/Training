using EMS.BDataContract;
using EMS.BusinessDataContract;
using EMS.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Translator
{
    public class CredentialTranslator
    {
        public BusinessLayerCredential ConvertToBusinessCredential(Credential credential)
        {
            BusinessLayerCredential businessCredential;
            if (credential == null)
                businessCredential = null;
            else
                businessCredential = new BusinessLayerCredential(credential.UserName, credential.Password);

            return businessCredential;
        }
        public Credential ConvertToServiceCredential(BusinessLayerCredential credential)
        {
            Credential serviceCredential;
            if (credential == null)
                serviceCredential = null;
            else
                serviceCredential = new Credential(credential.UserName, credential.Password);

            return serviceCredential;
        }
    }
}
