<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true"
    CodeFile="material.aspx.cs" Inherits="maintenance_material" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='datasource'>
        <asp:ObjectDataSource ID="odsMaterials" runat="server" SelectMethod='GetFilteredMaterials'
            TypeName='InventorySystem.Business.MaterialFacade'>
            <SelectParameters>
                <asp:ControlParameter ControlID='txtFilterMaterialCode' Type='String' Name='code' />
                <asp:ControlParameter ControlID='txtFilterMaterialName' Type='String' Name='name' />
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
                    Material Code :
                </td>
                <td>
                    <asp:TextBox ID="txtFilterMaterialCode" runat="server" CssClass='txtstyle' 
                        ontextchanged="txtFilterMaterialCode_TextChanged" AutoPostBack='true'></asp:TextBox>
                </td>
                <td>
                    Material Name :
                </td>
                <td>
                    <asp:TextBox ID="txtFilterMaterialName" runat="server" CssClass='txtstyle' 
                        ontextchanged="txtFilterMaterialName_TextChanged" AutoPostBack='true'></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div id='view'>
        <asp:GridView ID="gvMaterials" runat="server" Width='100%' AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" DataSourceID="odsMaterials" ForeColor="#333333" 
            GridLines="None" onrowcommand="gvMaterials_RowCommand">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbId" runat="server" CommandName='Select' CommandArgument='<%#Eval("Id") %>'>Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MaterialCode" HeaderText="MaterialCode" SortExpression="MaterialCode" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="PricePerUnit" HeaderText="PricePerUnit" SortExpression="PricePerUnit" />
                <asp:BoundField DataField="Attachment" HeaderText="Attachment" SortExpression="Attachment" />
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
        <td colspan='6'>
            <asp:Image ID="iMaterial" runat="server" Width='100px' Height='100px'/>
        </td>
        </tr>
            <tr>
                <td>
                    Material Code :
                </td>
                <td>
                    <asp:HiddenField ID="hfId" runat="server" />
                    <asp:TextBox ID="txtMaterialCode" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Material Name :
                </td>
                <td>
                    <asp:TextBox ID="txtMaterialName" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
                <td>
                    Price(unit) :
                </td>
                <td>
                    <asp:TextBox ID="txtPricePerUnit" runat="server" CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Description :
                </td>
                <td colspan='5'>
                    <asp:TextBox ID="txtDescription" runat="server" Width='627px' CssClass='txtstyle' Enabled='false'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan='6'>
                    <asp:HiddenField ID="hfAttachment" runat="server" />
                    <asp:FileUpload ID="fuAttachment" runat="server" Visible="false" />
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass='btnstyle' 
                        onclick="btnUpload_Click" Visible='false' />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
