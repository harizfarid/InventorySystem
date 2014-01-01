<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true"
    CodeFile="employee.aspx.cs" Inherits="maintenance_employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='datasource'>
    </div>
    <div id='warning'>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass='lblWarning'></asp:Label>
    </div>
    <div id="filter">
        <table>
            <tr>
                <td>
                    Employee Code :
                </td>
                <td>
                    <asp:TextBox ID="txtFilterEmployeeCode" runat="server"></asp:TextBox>
                </td>
                <td>
                    Employee Name :
                </td>
                <td>
                    <asp:TextBox ID="txtFilterEmployeeName" runat="server"></asp:TextBox>
                </td>
                <td>
                    Department:
                </td>
                <td>
                    <asp:TextBox ID="txtFilterDepartment" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div id='view'>
        <asp:GridView ID="gvEmployees" runat="server">
        </asp:GridView>
    </div>
    <div id="button">
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
            OnClientClick='return confirm("Are you sure you want to delete this record?");' />
    </div>
    <div id="action" runat='server'>
        <table>
            <tr>
                <td>
                    Employee Code :
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeCode" runat="server"></asp:TextBox>
                </td>
                <td>
                    Employee Name :
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                </td>
                <td>
                    Gender :
                </td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server">
                        <asp:ListItem Value='Male'>Male</asp:ListItem>
                        <asp:ListItem Value='Female'>Female</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Position :
                </td>
                <td>
                    <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
                </td>
                <td>
                    Department :
                </td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                </td>
                <td>
                    Email :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
                    Address :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
                <td>
                    Postcode :
                </td>
                <td>
                    <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                </td>
                <td>
                    Country :
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
                    Remarks :
                </td>
                <td colspan='5'>
                    <asp:TextBox ID="txtRemarks" runat="server" Width='626px'></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
