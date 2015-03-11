<%@ Page Title="" Language="C#" MasterPageFile="~/StudentDetails.Master" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="StudentDetails.WebForm2" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
        <h2>
        Student Registration Page</h2>
    </asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="StudentContainer" runat="server">
        <div class="LoginContainer" id="RegistraionContainer">
            <label id="RegistraionMessage">
                Please enter your personal details then click on Register button</label>
            <table class="table">
                <tr>
                    <td>
                        <b>First Name</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Last Name</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Email Id</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="EmailID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Password</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Confirm Password</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Password Hint</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="PasswordHint" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="AlreadyExist" runat="server" Text="Already Exist" OnClick="AlreadyExist_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Button ID="submit" runat="server" Text="Register" class="submit" onclick="submit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="validationMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Content>
    <asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
        <span class="SignatureContainer">powered by Njay Co-operation</span>
        <script type="text/ecmascript">

            //client side validation
            //$("#StudentContainer_FirstName").keyup(function () {
           //     alert('sa');
           // });
        </script>
    </asp:Content>