using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventorySystem.Business;
using InventorySystem.Entities;
public partial class maintenance_pattern : System.Web.UI.Page
{
    private List<Pattern> items;
    private string user;
    protected void Page_Init(object sender, EventArgs e)
    {
        items = new List<Pattern>();
        items = new PatternFacade().GetPatterns();
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
            ddlSupplier.SetEnable = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PatternFacade facade = new PatternFacade();
        int? nullValue = null;
        int? id = null;
        try
        {
            id = (!String.IsNullOrEmpty(hfId.Value)) ? Convert.ToInt32(hfId.Value) : id;
            facade.Save(id, (!String.IsNullOrEmpty(ddlSupplier.ddlId) ? Convert.ToInt32(ddlSupplier.ddlId) : nullValue), txtPatternCode.Text, txtPatternMaker.Text, Convert.ToDecimal(txtPrice.Text)
                        , Convert.ToDecimal(txtOuterDiameter.Text), Convert.ToDecimal(txtInnerDiameter.Text), Convert.ToDecimal(txtHeight.Text), Convert.ToDecimal(txtWidth.Text), Convert.ToDecimal(txtLength.Text), txtModificationRemarks.Text, DateTime.Now, DateTime.Now, user, user, "");
            lblErrorMessage.Text = Helper.SaveRecordMessage(true);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = Helper.SaveRecordMessage(false);

        }
        gvPatterns.DataBind();
        Helper.EnableControls(false, action);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Helper.SetTextControls("", action);
        Helper.EnableControls(true, action);
        ddlSupplier.SetEnable = true;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(hfId.Value))
        {
            try
            {
                PatternFacade facade = new PatternFacade();
                int id = Convert.ToInt32(hfId.Value);
                facade.Delete(id);
                gvPatterns.DataBind();
                lblErrorMessage.Text = Helper.DeleteRecordMessage(true);
            }
            catch (Exception exception)
            {
                lblErrorMessage.Text = Helper.DeleteRecordMessage(false);
            }
        }
    }
    protected void txtFilterPatternCode_TextChanged(object sender, EventArgs e)
    {
        gvPatterns.DataBind();
    }
    protected void gvPatterns_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        Pattern item = new Pattern();
        item = items.FirstOrDefault(P => P.Id == id);

        if (e.CommandName == "Select")
        {
            hfId.Value = item.Id.ToString();
            ddlSupplier.ddlId = item.SupplierId.ToString();
            txtPatternCode.Text = item.PatternCode;
            txtPatternMaker.Text = item.PatternMaker;
            txtPrice.Text = item.Price.ToString();
            txtOuterDiameter.Text = item.OuterDiameter.ToString();
            txtInnerDiameter.Text = item.InnerDiameter.ToString();
            txtHeight.Text = item.Height.ToString();
            txtWidth.Text = item.Width.ToString();
            txtLength.Text = item.Length.ToString();
            txtModificationRemarks.Text = item.ModificationRemarks;
            Helper.EnableControls(false, action);
            ddlSupplier.SetEnable = false;
        }
    }
}
