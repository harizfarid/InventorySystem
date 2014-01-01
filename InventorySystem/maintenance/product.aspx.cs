using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventorySystem.Business;
using InventorySystem.Entities;
using Product = InventorySystem.Entities.Product;

public partial class maintenance_product : System.Web.UI.Page
{
    private List<Product> items;
    private string user;
    string path;
    public decimal? Weight { get; set; }
    public decimal? InnerDiameter { get; set; }
    public decimal? OuterDiameter { get; set; }
    public decimal? Height { get; set; }
    public decimal? Width { get; set; }
    public decimal? Length { get; set; }

    protected void Page_Init(object sender, EventArgs e)
    {
        items = new List<Product>();
        items = new ProductFacade().GetProducts();
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
        ProductFacade facade = new ProductFacade();
        int? id = null;
        if (!String.IsNullOrEmpty(txtOuterDiameter.Text))
            OuterDiameter = Convert.ToDecimal(txtOuterDiameter.Text);
        if (!String.IsNullOrEmpty(txtInnerDiameter.Text))
            InnerDiameter = Convert.ToDecimal(txtInnerDiameter.Text);
        if (!String.IsNullOrEmpty(txtHeight.Text))
            Height = Convert.ToDecimal(txtHeight.Text);
        if (!String.IsNullOrEmpty(txtWidth.Text))
            Width = Convert.ToDecimal(txtWidth.Text);
        if (!String.IsNullOrEmpty(txtWeight.Text))
            Weight = Convert.ToDecimal(txtWeight.Text);
        if (!String.IsNullOrEmpty(txtLength.Text))
            Length = Convert.ToDecimal(txtLength.Text);
        
        try
        {
            id = (!String.IsNullOrEmpty(hfId.Value)) ? Convert.ToInt32(hfId.Value) : id;
            facade.Save(id, txtProductCode.Text, Convert.ToInt32(ddlProductGroup.SelectedValue), Convert.ToInt32(ddlCustomers.SelectedValue), Convert.ToInt32(ddlSupplier.SelectedValue), txtProductName.Text, txtDescription.Text, Weight, String.Empty, OuterDiameter, InnerDiameter, Height, Width, Length, null, DateTime.Now, user, user, String.Empty);
            lblErrorMessage.Text = Helper.SaveRecordMessage(true);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = Helper.SaveRecordMessage(false);

        }
        gvProducts.DataBind();
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
                ProductFacade facade = new ProductFacade();
                int id = Convert.ToInt32(hfId.Value);
                facade.Delete(id);
                gvProducts.DataBind();
                lblErrorMessage.Text = Helper.DeleteRecordMessage(true);
            }
            catch (Exception exception)
            {
                lblErrorMessage.Text = Helper.DeleteRecordMessage(false);
            }
        }
    }

    protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        Product item = new Product();
        item = items.FirstOrDefault(P => P.Id == id);
        if (e.CommandName == "Select")
        {
            hfId.Value = item.Id.ToString();
            txtProductName.Text = item.Name;
            txtDescription.Text = item.Description;
            txtOuterDiameter.Text = item.OuterDiameter.ToString();
            txtInnerDiameter.Text = item.InnerDiameter.ToString();
            txtWeight.Text = item.Weight.ToString();
            txtHeight.Text = item.Height.ToString();
            txtWidth.Text = item.Width.ToString();
            txtLength.Text = item.Length.ToString();
            txtModificationRemarks.Text = item.ModificationRemarks;
            Helper.EnableControls(false, action);
        }
    }
}
