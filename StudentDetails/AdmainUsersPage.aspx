<%@ Page Title="" Language="C#" MasterPageFile="~/StudentDetails.Master" AutoEventWireup="true" CodeBehind="AdmainUsersPage.aspx.cs" Inherits="StudentDetails.WebForm3" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
        <h2><asp:Label ID="TextHeader" runat="server"></asp:Label></h2>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="StudentContainer" runat="server">
        <div class="LoginContainer" id="AdminUserPageTable">
            <label id="AdminUserPageTableMessage">
                See Student details</label>
            <asp:Panel ID="LogoutPanel" runat="server">
                <asp:Button ID="LogoutFromStutentTable" runat="server" Text="Logout!" OnClick="Logout_OnClick" />
            </asp:Panel>
            <table id="AdminUsersTable" class="display" style="width: 650px;">
                <thead>
                    <tr>
                        <th>Email ID</th>
                        <th>Name</th>
                        <th>Gender</th>
                        <th>Telephone</th>
                        <th>Date Of Birth</th>
                        <th>Address</th>
                        <th>Action Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
            </table>
            <script type="text/ecmascript">
                function RegistrationAccepted(a) {
                    $.ajax({
                        type: "POST",
                        data: '{EmailID: "' + a + '" }',
                        url: "AdmainUsersPage.aspx/RegistrationAccepted",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            alert("Application of " + a + " has been accepted successfully by Admin");
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }

                function RegistrationRejected(a) {
                    $.ajax({
                        type: "POST",
                        data: '{EmailID: "' + a + '" }',
                        url: "AdmainUsersPage.aspx/RegistrationRejected",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            alert("Application of " + a + "has been rejected successfully by Admin");
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            </script>
        </div>
    </asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
        <span class="SignatureContainer">powered by Njay Co-operation</span>
    </asp:Content>