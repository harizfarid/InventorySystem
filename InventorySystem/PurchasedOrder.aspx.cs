using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventorySystem.Business;
public partial class PurchasedOrder : System.Web.UI.Page
{
    private StatusCollection status;
    private CustomerCollection customers;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Helper.EnableControls(false, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
        }

    }
    protected void gvPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPurchaseOrder, "Select$" + e.Row.RowIndex);
        }
    }

    protected void gvPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvPurchaseOrder.SelectedRow;
        Helper.EnableControls(false, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
        Label id = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblId");
        Label customerName = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblCustomerName");
        Label poNo = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblPoNo");
        Label dateCreated = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblDateCreated");
        Label quantity = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblQuantity");
        Label price = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblPrice");
        Label totalPrice = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblTotalPrice");
        Label deliveryDateTime = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblDeliveryDateTime");
        Label status = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblStatus");
        Label createdBy = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblCreatedBy");
        Label remarks = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblRemarks");
        Label custId = (Label)gvPurchaseOrder.Rows[row.RowIndex].FindControl("lblCustId");

        ViewState["id"] = id.Text;

        txtPONo.Text = poNo.Text;
        txtDateCreated.Text = dateCreated.Text;
        ddlCustomers.SelectedItem.Text = customerName.Text;
        txtQuantity.Text = quantity.Text;
        txtPrice.Text = price.Text;
        txtTotalPrice.Text = totalPrice.Text;
        txtDeliveryDate.Text = deliveryDateTime.Text;
        txtDeliveryDate.Text = deliveryDateTime.Text;
        ddlStatus.SelectedItem.Text = status.Text;
        txtCreatedBy.Text = createdBy.Text;
        txtRemarks.Text = remarks.Text;
        lblCustomer.Text = custId.Text;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Helper.EnableControls(true, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (ViewState["id"] != null)
        {
            Helper.EnableControls(true, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));    
        }
        else
        {
            lblError.Text = "require to select record";
        }
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PurchaseOrderModule module = new PurchaseOrderModule();
        PurchaseOrder purchaseOrder = new PurchaseOrder();
        try
        {
            purchaseOrder.CustomerId = Convert.ToInt32(ddlCustomers.SelectedValue);
            purchaseOrder.PONo = txtPONo.Text;
            purchaseOrder.Price = Convert.ToDecimal(txtPrice.Text);
            purchaseOrder.CreatedBy = txtCreatedBy.Text;
            purchaseOrder.DateCreated = Convert.ToDateTime(txtDateCreated.Text);
            purchaseOrder.DeliveryDateTime = Convert.ToDateTime(txtDeliveryDate.Text);
            purchaseOrder.Quantity = Convert.ToInt32(txtQuantity.Text);
            purchaseOrder.Remarks = txtRemarks.Text;
            purchaseOrder.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            purchaseOrder.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
            if (ViewState["id"] != null)
                purchaseOrder.Id = Convert.ToInt32(ViewState["id"]);

            module.Save(purchaseOrder);
          Response.Redirect("~/PurchasedOrder.aspx");
            //lblCustomer.Text = ddlCustomers.SelectedValue;
            //Helper.EnableControls(false, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
        }
        catch (Exception ex)
        {

            lblError.Text = "Please contact administrator. Error message : " + ex.Message;
        }


    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        PurchaseOrderModule module = new PurchaseOrderModule();
        if (ViewState["id"] != null)
        {
            module.Delete(Convert.ToInt32(ViewState["id"]));
            Response.Redirect("~/PurchasedOrder.aspx");
        }
        else
            lblError.Text = "Require to select record to be deleted";

    }
    protected void gvPurchaseOrder_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
    protected void btnListAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PurchasedOrder.aspx");
    }
    protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCustomer.Text = ddlCustomers.SelectedValue;
    }
}
