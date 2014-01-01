<%@ Page Language="C#" MasterPageFile="~/MasterPage_SingleContainer.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="Membership" Title="Membership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>

</div>
    <table>
  <tr>
     <td>
     User ID:
     </td>

  </tr>
  <tr>
     <td>
     <asp:TextBox ID="txtUserid" runat="server" CssClass="txtBoxSearch2"></asp:TextBox>
     </td>
  </tr>
  <tr>
      <td>
      Password:
      </td>
  </tr>
  <tr>
      <td>
      <asp:TextBox ID="txtPassword" runat="server" CssClass="txtBoxSearch2" 
              TextMode="Password"></asp:TextBox>
      </td>
  </tr>
  <tr>
      <td>
          <asp:Label ID="lblWarning" runat="server" Text="" CssClass="lblWarning" Visible="false"></asp:Label>
      </td>
  </tr>
  <tr>
        <td>
        </td>
  </tr>
  <tr>
        <td align="left">
        <asp:Button ID="btnSubmit" runat="server" Text="" 
              onclick="btnSubmit_Click" CssClass="button_login"/>
        </td>
  </tr>
  <tr>
        <td>
            New Employee? <asp:LinkButton ID="LinkRegister" runat="server" 
                onclick="LinkRegister_Click" CssClass="btnLink">Create Account</asp:LinkButton>
      </td>
  </tr>
  </table>
</asp:Content>


