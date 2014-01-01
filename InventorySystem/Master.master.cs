using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Maintenance : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptInclude("jquery-1.8.3", ResolveClientUrl("~scripts/jquery-1.8.3.js"));
        Page.ClientScript.RegisterClientScriptInclude("jquery-ui-1.9.2.custom.min", ResolveClientUrl("~/scripts/jquery-ui-1.9.2.custom.min.js"));
        Page.ClientScript.RegisterClientScriptInclude("date.js", ResolveClientUrl("~/scripts/date.js"));
        Page.ClientScript.RegisterClientScriptInclude("ScrollableGridPlugin", ResolveClientUrl("~/scripts/ScrollableGridPlugin.js"));
        Page.ClientScript.RegisterClientScriptInclude("gridview-readonly-script", ResolveClientUrl("~/scripts/gridview-readonly-script.js"));
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
