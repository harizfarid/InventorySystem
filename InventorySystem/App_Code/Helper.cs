using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
/// <summary>
/// Summary description for Helper
/// </summary>
public static class Helper
{
     static Helper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Set control enable/disable by providing div tag
    /// </summary>
    /// <param name="isEnabled"></param>
    /// <param name="div"></param>
     public static void EnableControls(bool isEnabled,HtmlGenericControl div)
     {
         foreach (Control c in div.Controls)
         {
             if (c is TextBox)
             {
                 TextBox txt = (TextBox)c;
                 txt.Enabled = isEnabled;
             }
             else if (c is DropDownList)
             {
                 DropDownList ddl = (DropDownList)c;
                 ddl.Enabled = isEnabled;
             }
             else if (c is RadioButtonList)
             {
                 RadioButtonList rbl = (RadioButtonList)c;
                 rbl.Enabled = isEnabled;
             }
         }
     }

     /// <summary>
     /// Set control enable/disable by providing div tag
     /// </summary>
     /// <param name="isEnabled"></param>
     /// <param name="div"></param>
     public static void SetTextControls(string text, HtmlGenericControl div)
     {
         foreach (Control c in div.Controls)
         {
             if (c is TextBox)
             {
                 TextBox txt = (TextBox)c;
                 txt.Text = "";
             }
             if (c is HiddenField)
             {
                 ((HiddenField) c).Value = "";
             }
         }
     }

    public static void EnableControls(bool enable,List<Control> controls)
    {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ((TextBox) (control)).Enabled = enable;
                }
                if (control is DropDownList)
                {
                    ((DropDownList) (control)).Enabled = enable;
                }
            }
    }

    public static void SetControlsValue(string value, List<Control> controls)
    {
        foreach (Control control in controls)
        {
            if (control is TextBox)
            {
                ((TextBox)(control)).Text = value;
            }
            if (control is DropDownList)
            {
             return;
            }
        }
    }

    public static List<Control> GetControlsInPlaceHolder(string placeHolderName,MasterPage master)
    {
        List<Control> controls = new List<Control>();
        ContentPlaceHolder contentPlaceHolder = new ContentPlaceHolder();
        contentPlaceHolder = (ContentPlaceHolder)master.FindControl(placeHolderName);
        if (contentPlaceHolder != null)
        {
            foreach (Control control in contentPlaceHolder.Controls)
            {
                controls.Add(control);
            }
            return controls;
        }
            return null;
    }

    public static Label SetMainTitle(MasterPage master,string text)
    {
        Label title = (Label)master.FindControl("lblTitle");
        title.Text = text;
        title.CssClass = "title_text";
        return title;
    }

    public static string SaveRecordMessage(bool isSuccess)
    {
        if (isSuccess)
        {
            return "Successfully save record";
        }
        return "Failed to save record. Please contact datakini representative. Sorry for any inconvinience";
    }

    public static string DeleteRecordMessage(bool isSuccess)
    {
        if (isSuccess)
        {
            return "Successfully delete record";
        }
        return "Failed to dekete record. Please contact datakini representative. Sorry for any inconvinience";
    }

}
