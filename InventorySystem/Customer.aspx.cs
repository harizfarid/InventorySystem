using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using InventorySystem.Business;

public partial class Customer : System.Web.UI.Page
{
    private InventorySystem.Business.Customer _customer;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Helper.SetMainTitle(Master, "CUSTOMER");
            if (Session["id"] == null)
            {
                Response.Redirect("Membership.aspx");
            }
            Label time = (Label)Master.FindControl("lblTime");
            Label user = (Label)Master.FindControl("lblUserid");
            time.Text = Session["logintime"].ToString();
            user.Text = Session["id"].ToString();
            Helper.EnableControls(false, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
            ddlCountry.ControlCountry.Enabled = false;
            btnSave.Enabled = false;
            gvCustomer.DataSource = odsCustomer;
            gvCustomer.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtCustomerCode.Text == "")
        {
            lblError.Visible = true;
            lblError.Text = "PLEASE ENTER CUSTOMER CODE";
        }
        else
        {
            gvCustomer.DataSource = odsSearchByCode;
            gvCustomer.DataBind();
        }
    }
    protected void gvCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvCustomer.SelectedRow;

        Label id = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblId");
        Label companyName = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblCompanyName");
        Label name = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblName");
        Label phoneNo = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblPhoneNo");
        Label email = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblEmail");
        Label fax = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblFax");
        Label website = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblWebsite");
        Label address = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lbladdress");
        Label postalCode = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblPostalCode");
        Label country = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblCountry");
        Label remarks = (Label)gvCustomer.Rows[row.RowIndex].FindControl("lblRemarks");

        ViewState["id"] = id.Text;

        txtCustName.Text = name.Text;
        txtCustCompName.Text = companyName.Text;
        txtCustAddress.Text = address.Text;
        txtCustWebsite.Text = website.Text;
        txtCustRemarks.Text = remarks.Text;
        txtCustEmail.Text = email.Text;
        txtCustFaxNo.Text = fax.Text;
        txtCustPostalCode.Text = postalCode.Text;
        ddlCountry.TextField = country.Text;
        txtCustPhoneNo.Text = phoneNo.Text;
        Helper.EnableControls(false, Helper.GetControlsInPlaceHolder("infoPlaceHolder", Master));
        ddlCountry.ControlCountry.Enabled = false;
    }
    protected void gvCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvCustomer, "Select$" + e.Row.RowIndex);
        }
    }

    private void InsertCustomer()
    {
        InventorySystem.Business.Customer customer = new InventorySystem.Business.Customer();
        CustomerModule customerModule = new CustomerModule();
        if (ViewState["id"] != null)
            customer.Id = Convert.ToInt32(ViewState["id"]);

        customer.Name = txtCustName.Text;
        customer.Company = txtCustCompName.Text;
        customer.Address = txtCustAddress.Text;
        customer.Website = txtCustWebsite.Text;
        customer.Remarks = txtCustRemarks.Text;
        customer.Email = txtCustEmail.Text;
        customer.Fax = txtCustFaxNo.Text;
        customer.PostCode = txtCustPostalCode.Text;
        //customer.Country = txtCustCountry.Text;
        customer.Country = ddlCountry.TextField;
        customer.PhoneNo = txtCustPhoneNo.Text;
        customer.Rating = RatingExample.CurrentRating;
        customerModule.Save(customer);


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertCustomer();
        gvCustomer.DataSource = odsCustomer;
        gvCustomer.DataBind();
        Helper.EnableControls(false, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
        ddlCountry.ControlCountry.Enabled = false;
        btnSave.Enabled = false;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CustomerModule customerModule = new CustomerModule();
        if (ViewState["id"] != null)
        {
            customerModule.Delete(ViewState["id"].ToString());
            gvCustomer.DataSource = odsCustomer;
            gvCustomer.DataBind();
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "PLEASE SELECT CUSTOMER";
        }
        
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("../InventorySystem/Customer.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ViewState["id"] = null;
        Helper.SetControlsValue("", Helper.GetControlsInPlaceHolder("InfoPlaceholder", Master));
        btnSave.Enabled = true;
        Helper.EnableControls(true, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
        ddlCountry.ControlCountry.Enabled = true;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        btnSave.Enabled = true;
        Helper.EnableControls(true, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
        ddlCountry.ControlCountry.Enabled = true;
    }
}
