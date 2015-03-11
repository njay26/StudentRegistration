<%@ Page Title="" Language="C#" MasterPageFile="~/StudentDetails.Master" AutoEventWireup="true"
    CodeBehind="StudentLogin.aspx.cs" Inherits="StudentDetails.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <h2>
        <asp:Label ID="TextHeader" runat="server"></asp:Label></h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StudentContainer" runat="server">
    <div class="LoginContainer" id="StudentLoginContainer">
        <label id="LoginMessage">
            Please enter your login ID and Password</label>
        <table class="table">
            <tr>
                <td>
                    <b>Login Id</b>
                </td>
                <td colspan="2">
                    :<asp:TextBox ID="LoginInput" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Password</b>
                </td>
                <td colspan="2">
                    :<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Register" runat="server" class="submit" Text="New Student" 
                        onclick="Register_Click" />
                </td>
                <td colspan="2">
                    <asp:Button ID="submit" class="submit" runat="server" Text="Login" OnClick="submit_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="GetpasswordHint" class="submit" runat="server" Text="Get Password Hint"
                        OnClick="GetpasswordHint_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="validationMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
     <span class="SignatureContainer">powered by Njay Co-operation</span>
</asp:Content>
