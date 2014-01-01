<%@ Page Title="Solid Foundry" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeFile="WorkOrder.aspx.cs" Inherits="WorkOrder" %>
<%@ Register Src="~/control/Time.ascx" TagName="Time" TagPrefix="ctrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchPlaceHolder" runat="Server">
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtBoxSearch2"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="" CssClass="button" OnClick="btnSearch_Click" />
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
                <asp:Button ID="btnListAll" runat="server" Text="" CssClass="button_refresh" OnClick="btnListAll_Click" />
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
                <asp:Button ID="btnExportPdf" runat="server" Text="" CssClass="button_exportPdf"
                    OnClick="btnExportPdf_Click" />
            </td>
            <td>
                <asp:Button ID="btnExportExcel" runat="server" Text="" CssClass="button_exportExcel"
                    OnClick="btnExportExcel_Click" />
            </td>
            <td>
                <asp:Button ID="btnPrint" runat="server" Text="" CssClass="button_print" OnClick="btnPrint_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ViewPlaceHolder" runat="Server">
    <asp:GridView ID="gvWorkOrder" runat="server" SkinID="gridViewSkin" AutoGenerateColumns="false"
        OnRowDataBound="gvWorkOrder_RowDataBound" OnSelectedIndexChanged="gvWorkOrder_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Customer">
                <ItemTemplate>
                    <asp:Label ID="lblCustomerName" runat="server" Text='<%# Bind("Customer.Name") %>'> /></asp:Label>
                    <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Bind("CustomerId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:HiddenField ID="hfDescription" runat="server" Value='<%# Bind("Description") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Material">
                <ItemTemplate>
                    <asp:Label ID="lblMaterialName" runat="server" Text='<%# Bind("Material.Name") %>'> /></asp:Label>
                    <asp:HiddenField ID="hfMaterialId" runat="server" Value='<%# Bind("MaterialId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Casting Weight">
                <ItemTemplate>
                    <asp:Label ID="lblCastingWeight" runat="server" Text='<%# Bind("CastingWeight") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pattern">
                <ItemTemplate>
                    <asp:Label ID="lblPatternCost" runat="server" Text='<%# Bind("PatternCost") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Machining">
                <ItemTemplate>
                    <asp:Label ID="lblMachiningCost" runat="server" Text='<%# Bind("MachiningCost") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modification">
                <ItemTemplate>
                    <asp:Label ID="lblModificationCost" runat="server" Text='<%# Bind("ModificationCost") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:Label ID="lblTotalCost" runat="server" Text='<%# Bind("TotalCost") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Others">
                <ItemTemplate>
                    <asp:Label ID="lblOthers" runat="server" Text='<%# Bind("Others") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delivery">
                <ItemTemplate>
                    <asp:Label ID="lblDeliveryDateTime" runat="server" Text='<%# Bind("DeliveryDateTime","{0:dd-MMM-yyyy HH:mm}") %>'> /></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfRemarks" runat="server" Value='<%# Bind("Remarks") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:ObjectDataSource ID="odsWorkOrders" runat="server" SelectMethod="GetWorkOrders"
            TypeName="InventorySystem.Business.WorkOrderModule"></asp:ObjectDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="InfoPlaceHolder" runat="Server">
    <div id="info">
        <table width="100%">
            <tr>
                <td>
                    Customer :
                </td>
                <td>
                    <asp:DropDownList ID="ddlCustomers" runat="server" DataSourceID="odsCustomers" DataTextField="Name"
                        DataValueField="Id" CssClass="ddlNormal">
                    </asp:DropDownList>
                </td>
                <td>
                    Pattern Cost :
                </td>
                <td>
                    <asp:TextBox ID="txtPatternCost" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Quantity :
                </td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Machining Cost :
                </td>
                <td>
                    <asp:TextBox ID="txtMachiningCost" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Material :
                </td>
                <td>
                    <asp:DropDownList ID="ddlMaterial" runat="server" DataSourceID="odsMaterials" DataTextField="Name"
                        DataValueField="Id" CssClass="ddlNormal">
                    </asp:DropDownList>
                </td>
                <td>
                    Total Cost
                </td>
                <td>
                    <asp:TextBox ID="txtTotalCost" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    DeliveryDateTime :
                </td>
                <td>
                    <asp:TextBox ID="txtDeliveryDateTime" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                    <asp:ImageButton ID="btnCalendar" runat="server" CausesValidation="false" ImageUrl="~/images/Calendar.gif" />
                    <%--<ctrl:Time ID="TimeMinute" runat="server" />--%>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDeliveryDateTime"
                        PopupButtonID="btnCalendar" Format="dd-MMM-yyyy hh:mm">
                    </asp:CalendarExtender>
                </td>
                <td>
                    Modification Cost :
                </td>
                <td>
                    <asp:TextBox ID="txtModificationCost" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Casting Weight :
                </td>
                <td>
                    <asp:TextBox ID="txtCastingWeight" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Others :
                </td>
                <td>
                    <asp:TextBox ID="txtOthers" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Description :
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="60px"
                        CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Remarks :
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBoxNormal" TextMode="MultiLine"
                        Height="60px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:ObjectDataSource ID="odsMaterials" runat="server" SelectMethod="GetMaterials"
            TypeName="InventorySystem.Business.MaterialModule"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsCustomers" runat="server" SelectMethod="GetCustomers"
            TypeName="InventorySystem.Business.CustomerModule"></asp:ObjectDataSource>
    </div>
    <div>
        <CR:CrystalReportSource ID="IUReport" runat="server">
        </CR:CrystalReportSource>
    </div>
</asp:Content>
