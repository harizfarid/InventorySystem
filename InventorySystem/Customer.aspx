<%@ Page Title="Solid Foundry" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeFile="Customer.aspx.cs" Inherits="Customer" %>

<%@ Register Src="~/control/Country.ascx" TagName="Country" TagPrefix="ctrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ViewPlaceHolder" runat="Server">
    <div>
        <asp:GridView ID="gvCustomer" runat="server" OnSelectedIndexChanged="gvCustomer_SelectedIndexChanged"
            OnRowDataBound="gvCustomer_RowDataBound" AutoGenerateColumns="False" SkinID="gridViewSkin">
            <Columns>
                <asp:TemplateField HeaderText="Cust No.">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Bind("Company") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cust Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone No.">
                    <ItemTemplate>
                        <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fax">
                    <ItemTemplate>
                        <asp:Label ID="lblFax" runat="server" Text='<%# Bind("Fax") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Website">
                    <ItemTemplate>
                        <asp:Label ID="lblWebsite" runat="server" Text='<%# Bind("Website") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Postal Code">
                    <ItemTemplate>
                        <asp:Label ID="lblPostalCode" runat="server" Text='<%# Bind("PostCode") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'> /></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rating">
                    <ItemTemplate>
                        <asp:Rating ID="RatingExample" runat="server" SkinID="RatingStyle" CurrentRating='<%# Bind("Rating") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchPlaceHolder" runat="Server">
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="txtBoxSearch2"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="" OnClick="btnSearch_Click" CssClass="button" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" CssClass="lblWarning" Visible='false'></asp:Label>
            </td>
        </tr>
    </table>
    <div>
        <asp:ObjectDataSource ID="odsCustomer" runat="server" SelectMethod="GetCustomers"
            TypeName="InventorySystem.Business.CustomerModule"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsSearchByCode" runat="server" SelectMethod="GetCustomerByCode"
            TypeName="InventorySystem.Business.CustomerModule">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtCustomerCode" Name="code" PropertyName="Text"
                    Type="String" ConvertEmptyStringToNull="False" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <CR:CrystalReportSource ID="IUReport" runat="server">
        </CR:CrystalReportSource>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ButtonPlaceHolder" runat="Server">
    <table class="table_button_style">
        <tr>
            <td>
                <asp:Button ID="btnListAll" runat="server" Text="" CssClass="button_refresh" 
                    onclick="btnListAll_Click" />
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="" CssClass="button_add" 
                    onclick="btnAdd_Click" />
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="" CssClass="button_edit" 
                    onclick="btnEdit_Click" />
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="" CssClass="button_remove" 
                    onclick="btnDelete_Click" />
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="" CssClass="button_save" 
                    onclick="btnSave_Click" />
            </td>
            <td>
                <asp:Button ID="btnExportPdf" runat="server" Text="" CssClass="button_exportPdf"/>
            </td>
            <td>
                <asp:Button ID="btnExportExcel" runat="server" Text="" CssClass="button_exportExcel"/>
            </td>
            <td>
                <asp:Button ID="btnPrint" runat="server" Text="" CssClass="button_print"/>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InfoPlaceHolder" runat="Server">
    <div>
        <table width="100%">
            <tr>
                <td>
                    Company Name
                </td>
                <td>
                    <asp:TextBox ID="txtCustCompName" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Address
                </td>
                <td rowspan="2">
                    <asp:TextBox ID="txtCustAddress" runat="server" Height="60px" TextMode="MultiLine"
                        CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Customer Name
                </td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Phone Number
                </td>
                <td>
                    <asp:TextBox ID="txtCustPhoneNo" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Postal Code
                </td>
                <td>
                    <asp:TextBox ID="txtCustPostalCode" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Fax Number
                </td>
                <td>
                    <asp:TextBox ID="txtCustFaxNo" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Country
                </td>
                <td>
                    <%--<asp:TextBox ID="txtCustCountry" runat="server" CssClass="txtBoxNormal"></asp:TextBox>--%>
                    <ctrl:Country ID="ddlCountry" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Email
                </td>
                <td>
                    <asp:TextBox ID="txtCustEmail" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
                <td>
                    Remarks
                </td>
                <td rowspan="2">
                    <asp:TextBox ID="txtCustRemarks" runat="server" TextMode="MultiLine" Height="60px"
                        CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Website
                </td>
                <td>
                    <asp:TextBox ID="txtCustWebsite" runat="server" CssClass="txtBoxNormal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Customer Rating
                </td>
                <td>
                    <asp:Rating ID="RatingExample" runat="server" CurrentRating="2" MaxRating="5" StarCssClass="ratingStar"
                        WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
