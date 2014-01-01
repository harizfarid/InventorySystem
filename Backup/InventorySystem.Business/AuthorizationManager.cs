using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InventorySystem.Data;

namespace InventorySystem.Business
{
    public class AuthorizationManager
    {
        private Authorization PopulateReader(IDataReader dr)
        {
            Authorization authorization = new Authorization();
            if (dr["Id"] != DBNull.Value)
                authorization.Id = Convert.ToInt32(dr["Id"]);
            authorization.Level = dr["Level"].ToString();
            return authorization;
        }
        public Authorization GetAuthorization(int id)
        {
            Authorization authorization = new Authorization();

            IDataReader dr = new AuthorizationDataAdapter().GetAuthorizationById(id);
            if (dr.Read())
            {
                authorization = PopulateReader(dr);
            }
            return authorization;
        }

        public AuthorizationCollection GetAuthorizations()
        {
            AuthorizationCollection authorizations = new AuthorizationCollection();

            IDataReader dr = new AuthorizationDataAdapter().GetAuthorizations();
            while (dr.Read())
            {
                authorizations.Add(PopulateReader(dr));
            }
            return authorizations;
        }
    }
}
