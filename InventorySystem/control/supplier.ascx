<%@ Control Language="C#" AutoEventWireup="true" CodeFile="supplier.ascx.cs" Inherits="control_supplier" %>
<asp:ObjectDataSource ID="odsSuppliers" runat="server" 
    SelectMethod="GetSuppliers" TypeName="InventorySystem.Business.SupplierFacade"></asp:ObjectDataSource>
<asp:DropDownList ID="ddlSupplier" runat="server" AppendDataBoundItems="True" 
    DataSourceID="odsSuppliers" DataTextField="Name" DataValueField="Id">
    <asp:ListItem Value=''>NONE</asp:ListItem>
</asp:DropDownList>
