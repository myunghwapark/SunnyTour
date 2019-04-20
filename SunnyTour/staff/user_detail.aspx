<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="user_detail.aspx.cs" Inherits="SunnyTour.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">User Detail</div>
                <table style="width:100%;">
                    <tr>
                        <td><asp:Button ID="btnList" runat="server" Text="List" Class="btn btn-info" OnClick="btnList_Click"></asp:Button></td>
                        <td style="text-align:right;">
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Class="btn btn-secondary" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete?')"></asp:Button>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" Class="btn btn-info" OnClick="btnEdit_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
                <table class="table">
                    <tr>
                        <td>User Id</td>
                        <td><asp:Label ID="labelUserId" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>First Name</td>
                        <td><asp:Label ID="labelFirstName" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Last Name</td>
                        <td><asp:Label ID="labelLastName" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Phone Number</td>
                        <td><asp:Label ID="labelPhoneNumber" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>User Type</td>
                        <td><asp:Label ID="labelUserType" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                   
             </div>
        </center>
    </main>
</asp:Content>
