<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true"
    CodeFile="pagetemplate.aspx.cs" Inherits="maintenance_pagetemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='datasource'>
    </div>
    <div id='warning'>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass='lblWarning'></asp:Label>
    </div>
    <div id="filter">
        <table>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div id='view'>
    </div>
    <div id="button">
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
            OnClientClick='return confirm("Are you sure you want to delete this record?");' />
    </div>
    <div id="action" runat='server'>
        <table>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
