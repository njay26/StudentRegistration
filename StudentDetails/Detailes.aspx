<%@ Page Title="" Language="C#" MasterPageFile="~/StudentDetails.Master" AutoEventWireup="true" CodeBehind="Detailes.aspx.cs" Inherits="StudentDetails.WebForm4" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
        <h2><asp:Label ID="TextHeader" runat="server"></asp:Label></h2>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="StudentContainer" runat="server">
        <div class="LoginContainer" id="DetailsContainer">
            <label id="DeatilsMessage">
                Please enter your personal details then click on save button</label>
            <asp:Panel ID="LogoutPanel" runat="server">
                <asp:Button ID="Logout" class="Logout" runat="server" Text="Logout!" OnClick="Logout_Click" />
            </asp:Panel>
            <table cellspacing="10" class="table">
                <tr>
                    <td>
                        <b>Sex</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:DropDownList ID="SexDDM" class="" runat="server">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Nationality</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="NationalityText" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Tel/Mobile</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="ContactText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Date of Birth</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="DOBText" runat="server" value="1900/01/01"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Area Code</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="AreaCodeText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Address</b>
                    </td>
                    <td colspan="2">
                        :
                        <asp:TextBox ID="AddressText" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="StudentList" runat="server" Text="See student List" OnClick="StudentList_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Button ID="submit" runat="server" Text="Save" class="submit" onclick="submit_Click" />
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
        <button id="EditOption">Edit</button>
        <script type="text/ecmascript">
            $("#StudentContainer_SexDDM, #StudentContainer_NationalityText, #StudentContainer_ContactText,#StudentContainer_DOBText, #StudentContainer_AreaCodeText, #StudentContainer_AddressText,#StudentContainer_submit").attr("disabled", "disabled");
            $("#EditOption").click(function () {
                $("#StudentContainer_SexDDM, #StudentContainer_NationalityText, #StudentContainer_ContactText,#StudentContainer_DOBText, #StudentContainer_AreaCodeText, #StudentContainer_AddressText,#StudentContainer_submit").removeAttr("disabled");
            });
        </script>
    </asp:Content>