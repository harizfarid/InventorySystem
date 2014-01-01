using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using InventorySystem.Business;

public partial class Membership : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserid.Focus();
    }

    private bool CheckUserPassword(string userId,string password)
    {
        if (ValidateUserAvailability(userId))
        {
            MembershipModule membershipModule = new MembershipModule();
            InventorySystem.Business.Membership membership = new InventorySystem.Business.Membership();
            membership = membershipModule.GetMembershipByUsername(userId);

            if (membership.Username == userId && membership.Password == password)
                return true;
            
        }
        return false;
    }

    private bool ValidateUserAvailability(string userId)
    {
        MembershipModule membershipModule = new MembershipModule();
        if (membershipModule.GetMembershipByUsername(userId) == null)
            return false;

        return true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Session["id"] = txtUserid.Text;
        Session["logintime"] = DateTime.Now.ToShortTimeString();

        if (CheckUserPassword(Session["id"].ToString(), txtPassword.Text))
        {
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            lblWarning.Visible = true;
            lblWarning.Text = "Invalid User Password";
        }
    }
    protected void LinkRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("MembershipRegistration.aspx");
    }
}
