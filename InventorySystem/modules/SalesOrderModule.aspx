<%@ Page Title="" Language="C#" MasterPageFile="~/InventorySystemMaster.master" AutoEventWireup="true" CodeFile="SalesOrderModule.aspx.cs" Inherits="modules_SalesOrderModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-lg-12">
            <h3>Sales Order Module</h3>
        </div>
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5 class="panel-title">Search Criteria</h5>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-1">
                            Order ID:
                        </div>
                        <div class="col-lg-3">
                            <input type="text" class="input-sm" />
                        </div>
                        <div class="col-lg-1">
                            Text
                        </div>
                        <div class="col-lg-3">
                            <input type="text" class="input-sm" />
                        </div>
                        <div class="col-lg-1">
                            Name:
                        </div>
                        <div class="col-lg-3">
                            <input type="text" class="input-sm" />
                        </div>
                    </div>
                    <p></p>
                    <div class="row">
                        <div class="col-lg-1">
                            Order ID:
                        </div>
                        <div class="col-lg-3">
                            <input type="text" class="input-sm" />
                        </div>
                        <div class="col-lg-1">
                            Text
                        </div>
                        <div class="col-lg-3">
                            <input type="text" class="input-sm" />
                        </div>
                        <div class="col-lg-1">
                            Name:
                        </div>
                        <div class="col-lg-3">
                            <input type="text" class="input-sm" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5 class="panel-title">User Action</h5>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <button class="btn btn-primary btn-sm">Print Record</button>
                       
                            <button class="btn btn-success btn-sm">Generate Report</button>
                       
                            <button class="btn btn-primary btn-sm">Search Record</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5 class="panel-title">View Results</h5>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <table>
                                <thead>
                                    <tr>
                                        <th></th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

