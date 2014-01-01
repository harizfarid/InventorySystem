<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeFile="salesorder.aspx.cs" Inherits="salesorder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='warning'>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass='lblWarning'></asp:Label>
    </div>
    <div id="filter">
        
    </div>
    <div id='view'>
        
    </div>
    <div id="button">
        <%--<asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass='btnstyle' onclick="btnEdit_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass='btnstyle' onclick="btnSave_Click" />
        <asp:Button ID="btnNew" runat="server" Text="New" CssClass='btnstyle' onclick="btnNew_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass='btnstyle' 
            onclick="btnDelete_Click"  OnClientClick='return confirm("Are you sure you want to delete this record?");'/>--%>
    </div>
    <div id="action" runat='server'>
        <table>
            <tr>
                <td>
                    Customer Reference No :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerId" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Customer Company :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerCompany" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Customer Name :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Customer Address :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerAddress" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Customer Tel :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerTel" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Customer Fax :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerFax" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Customer Email :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerEmail" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Customer P.O. :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerPO" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td>
                    Product Code :
                </td>
                <td>
                    <asp:TextBox ID="txtProductCode" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Product Name :
                </td>
                <td>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Material :
                </td>
                <td>
                    <asp:TextBox ID="txtMateria" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Quantity :
                </td>
                <td>
                    <asp:TextBox ID="txtWebsite" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Description :
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Unit Price :
                </td>
                <td>
                    <asp:TextBox ID="txtUnitPrice" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Amount :
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Total :
                </td>
                <td>
                    <asp:TextBox ID="txtTotal" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            <tr>
                <td>
                    Sales Order No :
                </td>
                <td>
                    <asp:TextBox ID="txtSONo" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Sales Order Created By :
                </td>
                <td>
                    <asp:TextBox ID="txtSOCreatedBy" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Sales Order Created On :
                </td>
                <td>
                    <asp:TextBox ID="txtSOCreatedOn" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Sales Order Lead Time :
                </td>
                <td>
                    <asp:TextBox ID="txtSOLeadTime" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
           </tr>     
           <tr>     
                <td>
                    Sales Order Status :
                </td>
                <td>
                    <asp:TextBox ID="txtSOStatus" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Sales Order Remarks :
                </td>
                <td>
                    <asp:TextBox ID="txtSORemarks" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>