using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InventorySystemMaster : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptInclude("jquery", ResolveClientUrl("~/scripts/jquery-1.9.1.min.js"));
        Page.ClientScript.RegisterClientScriptInclude("jquery-ui", ResolveClientUrl("~/scripts/jquery-ui-1.9.2.custom.min.js"));
        Page.ClientScript.RegisterClientScriptInclude("bootstrap", ResolveClientUrl("~/scripts/bootstrap.min.js"));
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
