<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true"
    CodeFile="product.aspx.cs" Inherits="maintenance_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='datasource'>
    <asp:ObjectDataSource ID="odsProducts" runat="server" SelectMethod='GetFilteredProducts'
            TypeName='InventorySystem.Business.ProductFacade'>
            <SelectParameters>
                <asp:ControlParameter ControlID='txtFilterProductCode' Type='String' Name='productCode' />
                <asp:ControlParameter ControlID='txtFilterProductName' Type='String' Name='productName' />
                <asp:ControlParameter ControlID='ddlFilterProductGroup' Type='Int32' Name='productGroup' />
                <asp:ControlParameter ControlID='ddlFilterCustomer' Type='Int32' Name='customer' />
                <asp:ControlParameter ControlID='ddlFilterSupplier' Type='Int32' Name='supplier' />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsCustomers" runat="server" TypeName='InventorySystem.Business.CustomerFacade'
        SelectMethod='GetCustomers'></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSuppliers" runat="server" TypeName='InventorySystem.Business.SupplierFacade'
        SelectMethod='GetSuppliers'></asp:ObjectDataSource>
    </div>
    <div id='warning'>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass='lblWarning'></asp:Label>
    </div>
    <div id="filter">
        <table>
            <tr>
                <td>
                    Product Code :
                </td>
                <td>
                    <asp:TextBox ID="txtFilterProductCode" runat="server" AutoPostBack="true" CssClass='txtstyle'></asp:TextBox>
                </td>
                <td>
                    <td>
                        Product Name :
                    </td>
                    <td>
                        <asp:TextBox ID="txtFilterProductName" runat="server" AutoPostBack="true" CssClass='txtstyle'></asp:TextBox>
                    </td>
                    <td>
                        Product Group :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFilterProductGroup" runat="server" AppendDataBoundItems="true"
                            AutoPostBack="true">
                            <asp:ListItem Value='0'>ALL</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Customer :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFilterCustomer" runat="server" AppendDataBoundItems="true"
                            AutoPostBack="true" DataSourceID='odsCustomers' DataTextField='Name' DataValueField='Id'>
                            <asp:ListItem Value='0'>ALL</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Supplier :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFilterSupplier" runat="server" AppendDataBoundItems="true" DataSourceID='odsSuppliers'
                            AutoPostBack="true" DataTextField='Name' DataValueField='Id'>
                            <asp:ListItem Value=''>ALL</asp:ListItem>
                        </asp:DropDownList>
                    </td>
            </tr>
        </table>
    </div>
    <div id='view'>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width='100%' 
            CellPadding="4" DataSourceID="odsProducts" ForeColor="#333333" 
            GridLines="None" onrowcommand="gvProducts_RowCommand">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbId" runat="server" CommandName='Select' CommandArgument='<%#Eval("Id") %>'>Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Name" 
                    SortExpression="Name" />
                <asp:BoundField DataField="ProductGroupName" HeaderText="ProductGroupName" 
                    SortExpression="ProductGroupName" />
                <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" 
                    SortExpression="CustomerName" />
                <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" 
                    SortExpression="SupplierName" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
                <asp:BoundField DataField="Weight" HeaderText="Weight" 
                    SortExpression="Weight" />
                <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
                <asp:BoundField DataField="OuterDiameter" HeaderText="OuterDiameter" 
                    SortExpression="OuterDiameter" />
                <asp:BoundField DataField="InnerDiameter" HeaderText="InnerDiameter" 
                    SortExpression="InnerDiameter" />
                <asp:BoundField DataField="Height" HeaderText="Height" 
                    SortExpression="Height" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Length" HeaderText="Length" 
                    SortExpression="Length" />
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
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass='btnstyle' />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass='btnstyle' />
        <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" CssClass='btnstyle'/>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass='btnstyle'
            OnClientClick='return confirm("Are you sure you want to delete this record?");' />
    </div>
    <div id="action" runat='server'>
        <table>
            <tr>
                <td colspan='6'>
                    <asp:Image ID="iProduct" runat="server" />
                    <asp:HiddenField ID="hfId" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Product Group :
                </td>
                <td>
                    <asp:DropDownList ID="ddlProductGroup" runat="server" AppendDataBoundItems="true" Enabled='false'>
                        <asp:ListItem Value='0'>NONE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Customer :
                </td>
                <td>
                      <asp:DropDownList ID="ddlCustomers" runat="server" AppendDataBoundItems="true"
                            AutoPostBack="true" DataSourceID='odsCustomers' DataTextField='Name' DataValueField='Id' Enabled='false'>
                            <asp:ListItem Value='0'>ALL</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td>
                    Supplier :
                </td>
                <td>
                    <asp:DropDownList ID="ddlSupplier" runat="server" AppendDataBoundItems="true" Enabled='false' DataSourceID='odsSuppliers'
                    DataTextField='Name' DataValueField='Id'>
                        <asp:ListItem Value='0'>NONE</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Product Code :
                </td>
                <td>
                    <asp:TextBox ID="txtProductCode" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Product Name :
                </td>
                <td>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Description :
                </td>
                <td colspan='5'>
                    <asp:TextBox ID="txtDescription" runat="server" Width='622px' CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Outer Diameter :
                </td>
                <td>
                    <asp:TextBox ID="txtOuterDiameter" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Inner Diameter :
                </td>
                <td>
                    <asp:TextBox ID="txtInnerDiameter" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Weight :
                </td>
                <td>
                    <asp:TextBox ID="txtWeight" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Height :
                </td>
                <td>
                    <asp:TextBox ID="txtHeight" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Width :
                </td>
                <td>
                    <asp:TextBox ID="txtWidth" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Length :
                </td>
                <td>
                    <asp:TextBox ID="txtLength" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Modification Remarks :
                </td>
                <td colspan='5'>
                    <asp:TextBox ID="txtModificationRemarks" runat="server" Width='622px' CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
