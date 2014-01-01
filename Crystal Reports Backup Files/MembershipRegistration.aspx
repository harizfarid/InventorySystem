<%@ Page Language="C#" MasterPageFile="~/MasterPage_SingleContainer.master" AutoEventWireup="true" CodeFile="MembershipRegistration.aspx.cs" Inherits="MembershipRegistration" Title="Membership Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div middle-container>
    <table>
    <tr>
        <td>
            User Id:
        </td>
        <td>
            <asp:TextBox ID="txtMembershipUserid" runat="server" Width="240px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="vldMembershipUserid" runat="server" 
                ErrorMessage="User Id Required" ControlToValidate="txtMembershipUserid" 
                ValidationGroup="SubmitEvent"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Password:
        </td>
        <td>
            <asp:TextBox ID="txtMembershipPassword" runat="server" TextMode="Password" Width="240px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="vldMembershipPassword" runat="server" 
                ErrorMessage="Password Required" ControlToValidate="txtMembershipPassword" 
                ValidationGroup="SubmitEvent"></asp:RequiredFieldValidator>        
        </td>
    </tr>
    <tr>
        <td>
            Confirm Password:
        </td>
        <td>
            <asp:TextBox ID="txtMembershipConfirmPassword" runat="server" 
                TextMode="Password" Width="240px"></asp:TextBox>
        </td>
        <td>
            <asp:CompareValidator ID="vldMembershipConfirmPassword" runat="server" 
                ErrorMessage="Password Does Not Match" ControlToCompare="txtMembershipPassword" 
                ControlToValidate="txtMembershipConfirmPassword" 
                ValidationGroup="SubmitEvent"></asp:CompareValidator>
        </td>      
   </tr>
        <tr>
        <td>
            Authorization:
        </td>
        <td>
            <asp:DropDownList ID="ddlMembershipAuthorization" runat="server" 
                DataSourceID="odsAuthorization" DataTextField="Level" DataValueField="Id" Width="240px">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
            Employee Name:
        </td>
        <td>
            <asp:DropDownList ID="ddlMembershipEmployeeName" runat="server"
                DataSourceId="odsEmployee" DataTextField="Name" DataValueField="Id" Width="240px">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
        
        </td>
        <td colspan="2">
            <asp:Button ID="btnSubmit" runat="server" Text="" 
                onclick="btnSubmit_Click" CssClass="button_submit" 
                ValidationGroup="SubmitEvent" /> 
            <asp:Button ID="btnCancel" runat="server" Text=""  
                onclick="btnCancel_Click" CssClass="button_cancel" />

        </td>
        </tr>
        <tr>
                    <asp:ObjectDataSource ID="odsAuthorization" runat="server" 
                SelectMethod="GetAuthorizations" 
                TypeName="InventorySystem.Business.AuthorizationModule"></asp:ObjectDataSource>
    
            <asp:ObjectDataSource ID="odsEmployee" runat="server" 
                SelectMethod="GetEmployees" TypeName="InventorySystem.Business.EmployeeModule">
            </asp:ObjectDataSource>
        </tr>
    </table>
    </div>
    <div>
       
    </div>
</asp:Content>

