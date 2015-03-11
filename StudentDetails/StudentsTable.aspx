<%@ Page Title="" Language="C#" MasterPageFile="~/StudentDetails.Master" AutoEventWireup="true"
    CodeBehind="StudentsTable.aspx.cs" Inherits="StudentDetails.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <h2>
        <asp:Label ID="TextHeader" runat="server"></asp:Label></h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StudentContainer" runat="server">
    <div class="LoginContainer" id="StudentTable">
        <label id="MessageTe">
            See Student details</label>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="GoBackPage" class="BackPageFromStudentTable" runat="server" Text="Back"
                OnClick="GoBackPage_Onclick" />
        </asp:Panel>
        <asp:Panel ID="LogoutPanel" runat="server">
            <asp:Button ID="Logout" class="LogoutFromStutentTable" runat="server" Text="Logout!"
                OnClick="Logout_OnClick" />
        </asp:Panel>
        <table id="example" class="table col-sm-12" style="width: 650px; overflow: scroll">
            <thead>
                <tr>
                    <th>
                        Name
                    </th>
                    <th>
                        Sex
                    </th>
                    <th>
                        Nationality
                    </th>
                    <th>
                        Telephone
                    </th>
                    <th>
                        Address
                    </th>
                    <th>
                        Application Status
                    </th>
                </tr>
            </thead>
            <tfoot id="SearchBox">
                <tr>
                    <th>
                        Name
                    </th>
                    <th>
                        Sex
                    </th>
                    <th>
                        Nationality
                    </th>
                    <th>
                        Telephone
                    </th>
                    <th>
                        Address
                    </th>
                    <th>
                       Application Status
                    </th>
                </tr>
            </tfoot>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <span class="SignatureContainer">powered by Njay Co-operation</span>
</asp:Content>
