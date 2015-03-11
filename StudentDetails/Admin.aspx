<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="StudentDetails.Admin1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="StyleSheets/Custom.css" rel="stylesheet" type="text/css" />
    <link href="StyleSheets/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jQuery1.11.1.js" type="text/javascript"></script>
    <script src="Scripts/Bootstrap.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="LoginContainer">
        <table class="table">
            <tr>
                <td colspan="4">
                    <b>Create DataBase, Tables and Do the web config related work</b>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <b>Enter Server Name:</b>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="ServerName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <b>Enter Database Name:</b>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="DBTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="CreateDB" runat="server" Text="Create DataBase" OnClick="CreateDB_Click" />
                </td>
                <td colspan="2">
                    <asp:Label ID="dbStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="CreateTable" runat="server" Text="Create Tables" OnClick="CreateTable_Click" />
                </td>
                <td colspan="2">
                    <asp:Label ID="TableStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="CreateStoreProcedure" runat="server" Text="Create Store Proc" OnClick="CreateStoreProcedure_Click" />
                </td>
                <td colspan="2">
                    <asp:Label ID="LableCreateStoreProcedure" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="ConfigureWebConfig" runat="server" Text="Configure Web Config" OnClick="ConfigureWebConfig_Click" />
                </td>
                <td colspan="2">
                    <asp:Label ID="WebConfigStatus" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
