using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Configuration;
namespace Datakini.Framework
{
    public static class EntityConnectionHelper
    {
        public static string CommonEFConnString(string entitySetName, string connectionStringName)
        {
            
            string innerConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            string entConnection =
               string.Format(
                   "metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;provider=System.Data.SqlClient;provider connection string=\"{1}\"",
                   entitySetName,
                   innerConnectionString);
            return entConnection;
        }
    }
}
