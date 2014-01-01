<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true"
    CodeFile="pattern.aspx.cs" Inherits="maintenance_pattern" %>

<%@ Register Src="../control/supplier.ascx" TagName="supplier" TagPrefix="lookup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='datasource'>
        <asp:ObjectDataSource ID="odsPatterns" runat="server" SelectMethod='GetFilteredPatterns'
            TypeName='InventorySystem.Business.PatternFacade'>
            <SelectParameters>
                <asp:ControlParameter ControlID='txtFilterPatternCode' Type='String' Name='patternCode' />
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
                    Pattern Code :
                </td>
                <td>
                    <asp:TextBox ID="txtFilterPatternCode" runat="server" OnTextChanged="txtFilterPatternCode_TextChanged"
                        AutoPostBack="true"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div id='view'>
        <asp:GridView ID="gvPatterns" runat="server" Width='100%' AllowPaging="True" CellPadding="4"
            DataSourceID="odsPatterns" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
            OnRowCommand="gvPatterns_RowCommand">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%# Eval("Id") %>'
                            CommandName='Select'>Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SupplierId" HeaderText="SupplierId" SortExpression="SupplierId" />
                <asp:BoundField DataField="PatternCode" HeaderText="PatternCode" SortExpression="PatternCode" />
                <asp:BoundField DataField="PatternMaker" HeaderText="PatternMaker" SortExpression="PatternMaker" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="OuterDiameter" HeaderText="OuterDiameter" SortExpression="OuterDiameter" />
                <asp:BoundField DataField="InnerDiameter" HeaderText="InnerDiameter" SortExpression="InnerDiameter" />
                <asp:BoundField DataField="Height" HeaderText="Height" SortExpression="Height" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                <asp:BoundField DataField="ModificationRemarks" HeaderText="ModificationRemarks"
                    SortExpression="ModificationRemarks" />
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
                    Supplier :
                </td>
                <td>
                    <lookup:supplier ID="ddlSupplier" runat="server" SetEnable='false' />
                          <asp:HiddenField ID="hfId" runat="server" />
                </td>
                <td>
                    Pattern Code :
                </td>
                <td>
                    <asp:TextBox ID="txtPatternCode" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Pattern Maker :
                </td>
                <td>
                    <asp:TextBox ID="txtPatternMaker" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Price :
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
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
                    <asp:TextBox ID="txtModificationRemarks" runat="server" CssClass='txtstyle' Width='657px' Enabled='false'></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
