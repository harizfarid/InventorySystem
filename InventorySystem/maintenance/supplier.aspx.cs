using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventorySystem.Entities;
using InventorySystem.Business;
public partial class maintenance_supplier : System.Web.UI.Page
{
    private List<Supplier> items;
    private string user;
    protected void Page_Init(object sender, EventArgs e)
    {
        items = new List<Supplier>();
        items = new SupplierFacade().GetSuppliers();
        user = "Tester";

    }
    protected void Page_Load(object sender, EventArgs e)
    {

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
        SupplierFacade facade = new SupplierFacade();
        int? id = null;
        try
        {
            id = (!String.IsNullOrEmpty(hfId.Value)) ? Convert.ToInt32(hfId.Value) : id;
            facade.Save(id, txtSupplierCode.Text, txtSupplierName.Text, txtCompany.Text, txtPhoneNo.Text
                        , txtFax.Text, txtEmail.Text, txtAddress.Text, txtPostcode.Text, txtState.Text, txtCountry.Text,
                        txtWebsite.Text
                        , DateTime.Now, DateTime.Now, user, user, txtRemarks.Text);
            lblErrorMessage.Text = Helper.SaveRecordMessage(true);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = Helper.SaveRecordMessage(false);

        }
        gvSuppliers.DataBind();
        Helper.EnableControls(false, action);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Helper.SetTextControls("", action);
        Helper.EnableControls(true, action);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(hfId.Value))
        {
            try
            {
                SupplierFacade facade = new SupplierFacade();
                int id = Convert.ToInt32(hfId.Value);
                facade.Delete(id);
                gvSuppliers.DataBind();
                lblErrorMessage.Text = Helper.DeleteRecordMessage(true);
            }
            catch (Exception exception)
            {
                lblErrorMessage.Text = Helper.DeleteRecordMessage(false);
            }
        }
    }

    protected void gvSuppliers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        Supplier item = new Supplier();
        item = items.FirstOrDefault(P => P.Id == id);
        if (e.CommandName == "Select")
        {
            hfId.Value = item.Id.ToString();
            txtSupplierCode.Text = item.SupplierCode;
            txtSupplierName.Text = item.Name;
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
            Helper.EnableControls(false, action);
        }
    }

    protected void txtFilterSupplierCode_TextChanged(object sender, EventArgs e)
    {
        gvSuppliers.DataBind();
    }

    protected void txtFilterSupplierName_TextChanged(object sender, EventArgs e)
    {
        gvSuppliers.DataBind();
    }

    protected void txtFilterSupplierEmail_TextChanged(object sender, EventArgs e)
    {
        gvSuppliers.DataBind();
    }
}
