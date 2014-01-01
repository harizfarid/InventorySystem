using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using InventorySystem.Business;

public partial class WorkOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Membership.aspx");
            }
            Helper.SetMainTitle(Master, "WORK ORDER");
            Label time = (Label)Master.FindControl("lblTime");
            Label user = (Label)Master.FindControl("lblUserid");
            time.Text = Session["logintime"].ToString();
            user.Text = Session["id"].ToString();
            Helper.EnableControls(false, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
            btnSave.Enabled = false;
            gvWorkOrder.DataSourceID = "odsWorkOrders";
            gvWorkOrder.DataBind();
        }
    }
    protected void gvWorkOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvWorkOrder, "Select$" + e.Row.RowIndex);
        }
    }
    protected void gvWorkOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvWorkOrder.SelectedRow;

        Label id = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblId");
        Label quantity = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblQuantity");
        Label castingWeight = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblCastingWeight");
        Label patternCost = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblPatternCost");
        Label machiningCost = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblMachiningCost");
        Label modificationCost = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblModificationCost");
        Label totalCost = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblTotalCost");
        Label others = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblOthers");
        Label DeliveryDateTime = (Label)gvWorkOrder.Rows[row.RowIndex].FindControl("lblDeliveryDateTime");
        HiddenField materialId = (HiddenField)gvWorkOrder.Rows[row.RowIndex].FindControl("hfMaterialId");
        HiddenField customerId = (HiddenField)gvWorkOrder.Rows[row.RowIndex].FindControl("hfCustomerId");
        HiddenField description = (HiddenField)gvWorkOrder.Rows[row.RowIndex].FindControl("hfDescription");
        HiddenField remarks = (HiddenField)gvWorkOrder.Rows[row.RowIndex].FindControl("hfRemarks");
        ViewState["id"] = id.Text;
        ddlCustomers.SelectedValue = customerId.Value;
        txtDescription.Text = description.Value;
        ddlMaterial.SelectedValue = materialId.Value; 
        txtQuantity.Text = quantity.Text;
        txtPatternCost.Text = patternCost.Text;
        txtMachiningCost.Text = machiningCost.Text;
        txtCastingWeight.Text = castingWeight.Text;
        txtOthers.Text = others.Text;
        txtModificationCost.Text = modificationCost.Text;
        txtTotalCost.Text = totalCost.Text;
        txtDeliveryDateTime.Text = DeliveryDateTime.Text;
        txtRemarks.Text = remarks.Value;
        

    }

    private void ConfigureReport()
    {
        IUReport.Report.FileName = @"~\Reports\WorkOrder.rpt";

        // connection		
        IUReport.ReportDocument.DataSourceConnections[0].SetConnection("SolidFoundry", "solidfoundry", "gu", "password");
        IUReport.ReportDocument.SetParameterValue("WorkOrderId", ViewState["id"]);
    }

    protected void btnExportPdf_Click(object sender, EventArgs e)
    {
        if (ViewState["id"] == null)
        {
            lblError.Visible = true;
            lblError.Text = "PLEASE SELECT WORK ORDER";
            return;
        }

        ConfigureReport();
        IUReport.ReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Work Order");
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        if (ViewState["id"] == null)
        {
            lblError.Visible = true;
            lblError.Text = "PLEASE SELECT WORK ORDER";
            return;
        }

        ConfigureReport();
        IUReport.ReportDocument.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Work Order");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ViewState["id"] = null;
        Helper.SetControlsValue("",Helper.GetControlsInPlaceHolder("InfoPlaceholder",Master));
        btnSave.Enabled = true;
        Helper.EnableControls(true, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));


    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        btnSave.Enabled = true;
        Helper.EnableControls(true, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        WorkOrderModule workOrderModule = new WorkOrderModule();
        InventorySystem.Business.WorkOrder workOrder = new InventorySystem.Business.WorkOrder();
        if (ViewState["id"] == null)
        {
            workOrder.Id = workOrderModule.GetMaxId() + 1;
        }
        else
        {
            workOrder.Id = Convert.ToInt32(ViewState["id"]);
        }

        workOrder.CustomerId = Convert.ToInt32(ddlCustomers.SelectedValue);
        workOrder.Description = txtDescription.Text;
        workOrder.MaterialId = ddlMaterial.SelectedValue;
        
        if (txtQuantity.Text != "")
            workOrder.Quantity = Convert.ToInt32(txtQuantity.Text);
        if (txtPatternCost.Text != "")
        workOrder.PatternCost = Convert.ToDecimal(txtPatternCost.Text);
        if (txtMachiningCost.Text != "")
        workOrder.MachiningCost = Convert.ToDecimal(txtMachiningCost.Text);
        if (txtCastingWeight.Text != "")
        workOrder.CastingWeight = Convert.ToInt32(txtCastingWeight.Text);
        workOrder.Others = txtOthers.Text;
        if (txtModificationCost.Text != "")
        workOrder.ModificationCost = Convert.ToDecimal(txtModificationCost.Text);
        if (txtTotalCost.Text != "")
        workOrder.TotalCost = Convert.ToDecimal(txtTotalCost.Text);
        if (txtDescription.Text != "")
        workOrder.DeliveryDateTime = Convert.ToDateTime(txtDeliveryDateTime.Text);
        workOrder.Remarks = txtRemarks.Text;
        workOrderModule.Save(workOrder);
        gvWorkOrder.DataBind();
        Helper.EnableControls(false, Helper.GetControlsInPlaceHolder("InfoPlaceHolder", Master));
        btnSave.Enabled = false;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (ViewState["id"] == null)
        {
            lblError.Visible = true;
            lblError.Text = "PLEASE SELECT WORK ORDER";
            return;
        }
        ConfigureReport();
        IUReport.ReportDocument.PrintOptions.PrinterName = "Canon MX340 series Printer (Copy 1)";
        IUReport.ReportDocument.PrintToPrinter(1, false, 0, 0);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        WorkOrderModule workOrderModule = new WorkOrderModule();
        workOrderModule.Delete(Convert.ToInt32(ViewState["id"]));
        gvWorkOrder.DataBind();
    }
    protected void btnListAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("../InventorySystem/WorkOrder.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        WorkOrderCollection workOrders = new WorkOrderModule().GetWorkOrdersByCustomerName(txtSearch.Text);
        gvWorkOrder.DataSourceID = null;
        gvWorkOrder.DataSource = workOrders;
        gvWorkOrder.DataBind();
    }
}
