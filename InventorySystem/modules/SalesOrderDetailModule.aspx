<%@ Page Title="" Language="C#" MasterPageFile="~/InventorySystemMaster.master" AutoEventWireup="true" CodeFile="SalesOrderDetailModule.aspx.cs" Inherits="modules_SalesOrderDetailModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-lg-12">
            <h3>Sales Order Detail Module</h3>
        </div>
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5 class="panel-title">Detail Information</h5>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-2"><span>Customer ID:</span></div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-lg-7"></div>
                    </div>
                    <p></p>
                    <div class="row">
                        <div class="col-lg-2">Customer Name:</div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-lg-7"></div>
                    </div>
                    <p></p>
                    <div class="row">
                        <div class="col-lg-2">Pattern Name:</div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-lg-7"></div>
                    </div>
                    <p></p>
                    <div class="row">
                        <div class="col-lg-2"></div>
                        <div class="col-lg-10">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" />
                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-success btn-sm" Text="New" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

