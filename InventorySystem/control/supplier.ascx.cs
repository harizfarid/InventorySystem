using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class control_supplier : System.Web.UI.UserControl
{
    public string ddlName
    {
        get { return ddlSupplier.SelectedItem.Text; }
        set { ddlSupplier.SelectedItem.Text = value; }
    }

    public string ddlId
    {
        get { return ddlSupplier.SelectedValue; }
        set { ddlSupplier.SelectedValue = value; }
    }

    public bool SetEnable
    {
        set { ddlSupplier.Enabled = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
