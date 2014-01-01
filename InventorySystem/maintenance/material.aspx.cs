using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventorySystem.Entities;
using InventorySystem.Business;
using Material = InventorySystem.Entities.Material;

public partial class maintenance_material : System.Web.UI.Page
{
    private List<Material> items;
    private string user;
    string path;

    protected void Page_Init(object sender, EventArgs e)
    {
        items = new List<Material>();
        items = new MaterialFacade().GetMaterials();
        user = "Tester";
        path = Server.MapPath("~/images/materials/");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(hfId.Value))
        {
            Helper.EnableControls(true, action);
            fuAttachment.Visible = true;
            btnUpload.Visible = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        MaterialFacade facade = new MaterialFacade();
        int? id = null;
        decimal? nullValue = null;
        try
        {
            id = (!String.IsNullOrEmpty(hfId.Value)) ? Convert.ToInt32(hfId.Value) : id;
            facade.Save(id, txtMaterialCode.Text, txtMaterialName.Text, txtDescription.Text, (!String.IsNullOrEmpty(txtPricePerUnit.Text)) ? Convert.ToDecimal(txtPricePerUnit.Text) : nullValue
                , (!String.IsNullOrEmpty(hfAttachment.Value) ? hfAttachment.Value : null)
                        , DateTime.Now, DateTime.Now, user, user);
            lblErrorMessage.Text = Helper.SaveRecordMessage(true);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = Helper.SaveRecordMessage(false);

        }

        gvMaterials.DataBind();
        Helper.EnableControls(false, action);
        fuAttachment.Visible = false;
        btnUpload.Visible = false;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Helper.SetTextControls("", action);
        iMaterial.ImageUrl = "";
        Helper.EnableControls(true, action);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void txtFilterMaterialCode_TextChanged(object sender, EventArgs e)
    {
        gvMaterials.DataBind();
    }
    protected void txtFilterMaterialName_TextChanged(object sender, EventArgs e)
    {
        gvMaterials.DataBind();
    }
    protected void gvMaterials_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        Material item = new Material();
        item = items.FirstOrDefault(P => P.Id == id);
        if (e.CommandName == "Select")
        {
            iMaterial.ImageUrl = "~/images/materials/" + item.Attachment;
            hfId.Value = item.Id.ToString();
            txtMaterialCode.Text = item.MaterialCode;
            txtMaterialName.Text = item.Name;
            txtPricePerUnit.Text = item.PricePerUnit.ToString();
            txtDescription.Text = item.Description;
            hfAttachment.Value = item.Attachment;
            Helper.EnableControls(false, action);
        }
    }

    public void Attach()
    {
        string filename = Path.GetFileName(fuAttachment.FileName);
        string fullPath = path + filename;
        MaterialFacade facade = new MaterialFacade();
        if (hfId.Value != null)
        {
            if (fuAttachment.PostedFile != null)
            {
                HttpPostedFile myFile = fuAttachment.PostedFile;

                int nFileLen = myFile.ContentLength;
                byte[] myData = new byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);
                WriteToFile(fullPath, ref myData);
                facade.UpdateAttachment(Convert.ToInt32(hfId.Value), filename);
                gvMaterials.DataBind();
            }
        }
    }

    private void WriteToFile(string strPath, ref byte[] Buffer)
    {
        // Create a file

        FileStream newFile = new FileStream(strPath, FileMode.Create);

        // Write data to the file

        newFile.Write(Buffer, 0, Buffer.Length);

        // Close file

        newFile.Close();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Attach();
    }
}
