using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Country : System.Web.UI.UserControl
{
    public string TextField
    { 
        get
        {
            return ddlCountry.SelectedItem.Text;

        }
        set { ddlCountry.SelectedItem.Text = value; }
    }

    public DropDownList ControlCountry
    {
        get { return ddlCountry; }
        set { ddlCountry = value; }
    }

    public string ValueField 
    { 
        get
        {
            
            return ddlCountry.SelectedValue;
        }
    }
   
}
