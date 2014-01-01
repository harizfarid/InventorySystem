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

public partial class MembershipRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertMembership();
        Response.Redirect("Membership.aspx");
    }
    private void InsertMembership()
    {
        InventorySystem.Business.Membership membership = new InventorySystem.Business.Membership();
        InventorySystem.Business.MembershipModule membershipModule = new InventorySystem.Business.MembershipModule();
        if (ViewState["id"] != null)
            membership.Username = ViewState["id"].ToString();
        else
            membership.Username = null;

        membership.Username = txtMembershipUserid.Text;
        membership.Password = txtMembershipPassword.Text;
        membership.Authorization = Convert.ToInt32(ddlMembershipAuthorization.SelectedValue.ToString());
        membership.EmployeeId = ddlMembershipEmployeeName.SelectedValue.ToString();

        membershipModule.Save(membership);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Membership.aspx");
    }
}
