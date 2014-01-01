using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class control_Time : System.Web.UI.UserControl
{
    public DropDownList Hours
    {
        get { return ddlHour; }
        set { ddlHour = value; }
    }

    public DropDownList Minutes
    {
        get { return ddlMinute; }
        set { ddlMinute = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ddlHour.DataSource = GetHours();
        ddlMinute.DataSource = GetMinutes();
        ddlHour.DataBind();
        ddlMinute.DataBind();
    }

    private List<string> GetHours()
    {
        List<string> hour = new List<string>();
        for (int j = 0; j < 24; j++)
        {
            hour.Add(j.ToString("D2"));
        }
        return hour;
    }

    private List<string> GetMinutes()
    {
        List<string> minutes = new List<string>();
        for (int j = 0; j < 60; j++)
        {
            minutes.Add(j.ToString("D2"));
        }
        return minutes;
    }
}
