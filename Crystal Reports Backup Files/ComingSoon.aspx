<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ComingSoon.aspx.cs" Inherits="ComingSoon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style='text-align:center;width:100%;'>
    <asp:Image ID="iComingSoon" ImageUrl="~/images/coming_soon.png" runat="server" />
    </div>
    <p style='font-family:tahoma;font-size:12px;'>
    * This features will be available on next release. 
    </p>
</asp:Content>

