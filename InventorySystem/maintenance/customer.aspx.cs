using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventorySystem.Business;
using InventorySystem.Entities;
using Customer = InventorySystem.Entities.Customer;

public partial class maintenance_customer : System.Web.UI.Page
{
    private List<Customer> customers;
    private string user;
    protected void Page_Init(object sender,EventArgs e)
    {
        customers = new List<Customer>();
        customers = new CustomerFacade().GetCustomers();
        user = "Tester";
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        if (!Page.IsPostBack)
        {
            
        }
    }

    protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        Customer item = new Customer();
        item = customers.FirstOrDefault(P => P.Id == id);
        if (e.CommandName == "Select")
        {
            hfId.Value = item.Id.ToString();
            txtCustomerCode.Text = item.CustomerCode;
            txtCustomerName.Text = item.Name;
            txtCompany.Text = item.Company;
            txtPhoneNo.Text = item.PhoneNo;
            txtFax.Text = item.Fax;
            txtEmail.Text = item.Email;
            txtAddress.Text = item.Address;
            txtPostcode.Text = item.Postcode;
            txtState.Text = item.State;
            txtCountry.Text = item.Country;
            txtWebsite.Text = item.Website;
            txtRemarks.Text = item.Remarks;
            Helper.EnableControls(false,action);
        }
    }

    protected void txtFilterCustomerCode_TextChanged(object sender, EventArgs e)
    {
        gvCustomers.DataBind();
    }

    protected void txtFilterCustomerName_TextChanged(object sender, EventArgs e)
    {
        gvCustomers.DataBind();
    }

    protected void txtFilterCustomerEmail_TextChanged(object sender, EventArgs e)
    {
        gvCustomers.DataBind();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(hfId.Value))
        {
            Helper.EnableControls(true, action);    
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerFacade facade = new CustomerFacade();
        int? id = null;
        try
        {
        id = (!String.IsNullOrEmpty(hfId.Value)) ? Convert.ToInt32(hfId.Value) : id; 
        facade.Save(id, txtCustomerCode.Text, txtCustomerName.Text, txtCompany.Text, txtPhoneNo.Text
                    , txtFax.Text, txtEmail.Text, txtAddress.Text, txtPostcode.Text, txtState.Text, txtCountry.Text,
                    txtWebsite.Text
                    , DateTime.Now, DateTime.Now, user, user, txtRemarks.Text);
            lblErrorMessage.Text = Helper.SaveRecordMessage(true);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = Helper.SaveRecordMessage(false);

        }
        gvCustomers.DataBind();
        Helper.EnableControls(false, action);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Helper.SetTextControls("", action);
        Helper.EnableControls(true,action);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(hfId.Value))
        {
            try
            {
            CustomerFacade facade = new CustomerFacade();
            int id = Convert.ToInt32(hfId.Value);
            facade.Delete(id);
            gvCustomers.DataBind();
            lblErrorMessage.Text = Helper.DeleteRecordMessage(true);
            }
            catch (Exception exception)
            {
                lblErrorMessage.Text = Helper.DeleteRecordMessage(false);
            }
        }
    }
}
