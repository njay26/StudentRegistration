<%@ Page Title="" Language="C#" MasterPageFile="~/StudentDetails.Master" AutoEventWireup="true" CodeBehind="GetPasswordHint.aspx.cs" Inherits="StudentDetails.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <h2>Get you password hint</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StudentContainer" runat="server">
<div class="LoginContainer" id="PasswordHintContainer">
                    <label id="PasswordHintMessage">
                        Please enter your login id and get your password hint</label>
        <table class="table">
            <tr>
                <td>
                    <b>Login Id</b>
                </td>
                <td colspan="2">
                    :<asp:TextBox ID="EmailID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
                <asp:Button ID="Login" runat="server" Text="Go to login" OnClick="Login_Click" /></td>
                <td colspan="2">
                    <asp:Button id="submit" class= "submit" runat="server" Text="Get Password Hint" 
                        onclick="submit_Click" /> 
                </td>
            </tr>
            <tr>
                <td colspan ="3">
                    <asp:Label ID="StatausofPassword" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
     <span class="SignatureContainer">powered by Njay Co-operation</span>
</asp:Content>
