using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class AuthorizationModule
    {
        public Authorization GetAuthorization(int id)
        {
            return new AuthorizationManager().GetAuthorization(id);
        }

        public AuthorizationCollection GetAuthorizations()
        {
            return new AuthorizationManager().GetAuthorizations();
        }

    }
}
