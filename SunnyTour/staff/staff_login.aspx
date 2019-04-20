<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="staff_login.aspx.cs" Inherits="SunnyTour.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	<center>
	<div class="title" style="text-align:center;">Staff Login</div>
    <div class="staff_div">
        <asp:Panel runat="server" DefaultButton="btnLogin">
        <table class="loginTable">
            <tr>
                <td class="form_title_blue">
                    User ID
                </td>
                <td>
                    <asp:TextBox ID="txtUserId" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqValidator_userId" runat="server" ErrorMessage="Please, enter your ID." Text="*" ControlToValidate="txtUserId" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>     
            </tr>
            <tr>
                <td class="form_title_blue">
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" onkeypress="btnLogin_Click"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqValidator_password" runat="server" ErrorMessage="Please, enter password." Text="*" ControlToValidate="txtPassword" ForeColor="#FF3300" ></asp:RequiredFieldValidator>
                </td>     
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300" />
                    <asp:Label ID="labelNotice" runat="server" Text="Invalid ID or password." ForeColor="#FF3300" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="center">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary" OnClick="btnLogin_Click" />
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    </center>
</main>
</asp:Content>
