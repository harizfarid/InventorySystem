<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeFile="PurchasedOrder.aspx.cs" Inherits="PurchasedOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchPlaceHolder" runat="Server">
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtBoxSearch2"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="" CssClass="button" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" CssClass="lblWarning"
                    Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonPlaceHolder" runat="Server">
    <table class="table_button_style">
        <tr>
            <td>
                <asp:Button ID="btnListAll" runat="server" Text="" CssClass="button_refresh" 
                    onclick="btnListAll_Click" />
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="" CssClass="button_add" OnClick="btnAdd_Click" />
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="" CssClass="button_edit" OnClick="btnEdit_Click" />
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="" CssClass="button_remove" OnClick="btnDelete_Click" />
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="" CssClass="button_save" OnClick="btnSave_Click" />
            </td>
            <td>
                <asp:Button ID="btnExportPdf" runat="server" Text="" CssClass="button_exportPdf" />
            </td>
            <td>
                <asp:Button ID="btnExportExcel" runat="server" Text="" CssClass="button_exportExcel" />
            </td>
            <td>
                <asp:Button ID="btnPrint" runat="server" Text="" CssClass="button_print" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ViewPlaceHolder" runat="Server">
    <%--    <script type="text/javascript" >
        $(document).ready(function() {
            $('#<%=gvPurchaseOrder.ClientID %>').Scrollable();
        });
    </script>--%>
    <div id='datasources'>
        <asp:ObjectDataSource ID="odsPurchaseOrder" runat="server" SelectMethod="GetPurchaseOrders"
            TypeName="InventorySystem.Business.PurchaseOrderModule"></asp:ObjectDataSource>
    </div>
    <div>
        <asp:GridView ID="gvPurchaseOrder" runat="server" AutoGenerateColumns="False" SkinID="gridViewSkin"
            DataSourceID="odsPurchaseOrder" OnRowDataBound="gvPurchaseOrder_RowDataBound"
            OnSelectedIndexChanged="gvPurchaseOrder_SelectedIndexChanged" OnRowCreated="gvPurchaseOrder_RowCreated">
            <Columns>
                <asp:TemplateField HeaderText="Row Id.">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cust No.">
                    <ItemTemplate>
                        <asp:Label ID="lblCustId" runat="server" Text='<%# Bind("CustomerId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCustomerName" runat="server" Text='<%# Bind("CustomerInfo.Name") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PO No.">
                    <ItemTemplate>
                        <asp:Label ID="lblPoNo" runat="server" Text='<%# Bind("PONo") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Price">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Created">
                    <ItemTemplate>
                        <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("DateCreated","{0:dd-MMM-yyyy}") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delivery Date Time">
                    <ItemTemplate>
                        <asp:Label ID="lblDeliveryDateTime" runat="server" Text='<%# Bind("DeliveryDateTime","{0:dd-MMM-yyyy}") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created By">
                    <ItemTemplate>
                        <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Bind("CreatedBy") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("StatusInfo.Name") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="InfoPlaceHolder" runat="Server">
    <asp:ObjectDataSource ID="odsCustomers" runat="server" SelectMethod="GetCustomersLookUp"
        TypeName="InventorySystem.Business.CustomerModule"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsStatus" runat="server" SelectMethod="GetStatusLookUp"
        TypeName="InventorySystem.Business.StatusModule"></asp:ObjectDataSource>
    <div id="info">
        <table width="100%">
            <tr>
                <td>
                    Customer Name :
                </td>
                <td>
                    <asp:Label ID="lblCustomer" runat="server" Text=""></asp:Label>
                    <asp:DropDownList ID="ddlCustomers" runat="server" DataSourceID="odsCustomers" DataTextField="Name"
                        DataValueField="Id" CssClass='ddlNormal' AutoPostBack="True" 
                        onselectedindexchanged="ddlCustomers_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    PO No. :
                </td>
                <td>
                    <asp:TextBox ID="txtPONo" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Date Created :
                </td>
                <td>
                    <asp:TextBox ID="txtDateCreated" runat="server" CssClass='datepicker'></asp:TextBox>
                </td>
                <td>
                    Quantity :
                </td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Remarks :
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Price :
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Total Price :
                </td>
                <td>
                    <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Target Delivery Date:
                </td>
                <td>
                    <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="datepicker"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Status:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="odsStatus" DataTextField="Name"
                        DataValueField="Id" CssClass='ddlNormal'>
                    </asp:DropDownList>
                </td>
                <td>
                    Created By:
                </td>
                <td>
                    <asp:TextBox ID="txtCreatedBy" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
