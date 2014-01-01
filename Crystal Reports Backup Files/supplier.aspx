<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true"
    CodeFile="supplier.aspx.cs" Inherits="maintenance_supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='datasource'>
      <asp:ObjectDataSource ID="odsSuppliers" runat="server" SelectMethod="GetFilteredSuppliers"
            TypeName="InventorySystem.Business.SupplierFacade">
            <SelectParameters>
            <asp:ControlParameter ControlID='txtFilterSupplierCode' Type="String" Name='supplierCode' />
            <asp:ControlParameter ControlID='txtFilterSupplierName' Type="String" Name='name' />
            <asp:ControlParameter ControlID='txtFilterSupplierEmail' Type="String" Name='email' />
            </SelectParameters>
            </asp:ObjectDataSource>
    </div>
    <div id='warning'>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass='lblWarning'></asp:Label>
    </div>
    <div id="filter">
        <table>
                     <tr>
                <td>
                    Supplier Code:
                </td>
                <td>
                    <asp:TextBox ID="txtFilterSupplierCode" runat="server" CssClass='txtstyle' AutoPostBack="true" 
                        ontextchanged="txtFilterSupplierCode_TextChanged"></asp:TextBox>
                </td>
                <td>
                    Supplier Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFilterSupplierName" runat="server" CssClass='txtstyle'  AutoPostBack="true" 
                        ontextchanged="txtFilterSupplierName_TextChanged"></asp:TextBox>
                </td>
                <td>
                    Email:
                </td>
                <td>
                    <asp:TextBox ID="txtFilterSupplierEmail" runat="server" CssClass='txtstyle' AutoPostBack="true" 
                        ontextchanged="txtFilterSupplierEmail_TextChanged"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div id='view'>
     <asp:GridView ID="gvSuppliers" runat="server" Width='100%' AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" DataSourceID="odsSuppliers" ForeColor="#333333" GridLines="None"
            OnRowCommand="gvSuppliers_RowCommand">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%# Eval("Id") %>'
                            CommandName='Select'>Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="SupplierCode" HeaderText="SupplierCode" SortExpression="SupplierCode" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
                <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" SortExpression="PhoneNo" />
                <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="Postcode" HeaderText="Postcode" SortExpression="Postcode" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website" />
                <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>
    <div id="button">
        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass='btnstyle' OnClick="btnEdit_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass='btnstyle' OnClick="btnSave_Click" />
        <asp:Button ID="btnNew" runat="server" Text="New" CssClass='btnstyle' OnClick="btnNew_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass='btnstyle' OnClick="btnDelete_Click"
            OnClientClick='return confirm("Are you sure you want to delete this record?");' />
    </div>
    <div id="action" runat='server'>
          <table>
            <tr>
                <td>
                    Supplier Code :
                </td>
                <td>
                    <asp:HiddenField ID="hfId" runat="server" />
                    <asp:TextBox ID="txtSupplierCode" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Supplier Name :
                </td>
                <td>
                    <asp:TextBox ID="txtSupplierName" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Company :
                </td>
                <td>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Phone No :
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNo" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Fax :
                </td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Email :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Address :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Postcode :
                </td>
                <td>
                    <asp:TextBox ID="txtPostcode" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    State :
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Country :
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Website (if applicable) :
                </td>
                <td>
                    <asp:TextBox ID="txtWebsite" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Remarks :
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
