<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test_CrystalReport.aspx.cs" Inherits="Test_CrystalReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="crvStatement" runat="server" 
			AutoDataBind="True" Height="1123px" EnableDatabaseLogonPrompt="False" 
			EnableParameterPrompt="False" 
			HasCrystalLogo="False"			 		
			HasDrillUpButton="False" HasExportButton="True" BestFitPage="True" EnableDrillDown="False" 
			ReportSourceID="IUReport" GroupTreeStyle-BackColor="#FFFFCC" Width="768px" 
			DisplayGroupTree="False" />
        <CR:CrystalReportSource ID="IUReport" runat="server">
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
