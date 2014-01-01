<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="InventorySystem.Home" EnableTheming="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ViewPlaceHolder" runat="server">
    <script type='text/javascript'>
        $(function() {
            $(".datepicker").datepicker();
        });
	</script>
    
    THIS IS A TESTSSS
    <br />
    THIS IS A TEST
    <br />
    THIS IS A TEST
    <br />
    THIS IS A TEST
    <asp:TextBox ID="TextBox1" runat="server" CssClass='datepicker'></asp:TextBox>
</asp:Content>
