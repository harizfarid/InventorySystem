<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true"
    CodeFile="customer.aspx.cs" Inherits="maintenance_customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='datasource'>
        <asp:ObjectDataSource ID="odsCustomers" runat="server" SelectMethod="GetFilteredCustomer"
            TypeName="InventorySystem.Business.CustomerFacade">
            <SelectParameters>
            <asp:ControlParameter ControlID='txtFilterCustomerCode' Type="String" Name='customerCode' />
            <asp:ControlParameter ControlID='txtFilterCustomerName' Type="String" Name='name' />
            <asp:ControlParameter ControlID='txtFilterCustomerEmail' Type="String" Name='email' />
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
                    Customer Code:
                </td>
                <td>
                    <asp:TextBox ID="txtFilterCustomerCode" runat="server" AutoPostBack="true" 
                        ontextchanged="txtFilterCustomerCode_TextChanged"></asp:TextBox>
                </td>
                <td>
                    Customer Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFilterCustomerName" runat="server"  AutoPostBack="true" 
                        ontextchanged="txtFilterCustomerName_TextChanged"></asp:TextBox>
                </td>
                <td>
                    Email:
                </td>
                <td>
                    <asp:TextBox ID="txtFilterCustomerEmail" runat="server"  AutoPostBack="true" 
                        ontextchanged="txtFilterCustomerEmail_TextChanged"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div id='view'>
        <asp:GridView ID="gvCustomers" runat="server" Width='100%' AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" DataSourceID="odsCustomers" ForeColor="#333333" GridLines="None"
            OnRowCommand="gvCustomers_RowCommand">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%# Eval("Id") %>'
                            CommandName='Select'>Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="CustomerCode" HeaderText="CustomerCode" SortExpression="CustomerCode" />
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
        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass='btnstyle' onclick="btnEdit_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass='btnstyle' onclick="btnSave_Click" />
        <asp:Button ID="btnNew" runat="server" Text="New" CssClass='btnstyle' onclick="btnNew_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass='btnstyle' 
            onclick="btnDelete_Click"  OnClientClick='return confirm("Are you sure you want to delete this record?");'/>
    </div>
    <div id="action" runat='server'>
        <table>
            <tr>
                <td>
                    Customer Code :
                </td>
                <td>
                    <asp:HiddenField ID="hfId" runat="server" />
                    <asp:TextBox ID="txtCustomerCode" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Customer Name :
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass='txtstyle'  Enabled='false'></asp:TextBox>
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
