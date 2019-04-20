<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SunnyTour.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<main class="cd-main-content">
    <center>
	<div class="title" style="text-align:center;">Login</div>
    <div class="feature_div">
        <table class="loginTable">
            <tr>
                <td class="form_title">
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
                <td class="form_title">
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqValidator_password" runat="server" ErrorMessage="Please, enter password." Text="*" ControlToValidate="txtPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>     
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300" />
                </td>
            </tr>
            <tr>
                <td class="form_content">
                    <a href="/customers/forgotPassword.aspx">Forgot Password?</a>
                </td>
                <td style="text-align:right;" class="form_content">
                    <a href="/customers/register.aspx">Register</a>
                </td>   
            </tr>
            <tr>
                <td colspan="3" class="center">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary btn-lg" OnClick="btnLogin_Click" />
                </td>
            </tr>
        </table>
    </div>
    </center>
</main>
</asp:Content>
