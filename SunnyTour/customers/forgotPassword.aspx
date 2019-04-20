<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="SunnyTour.WebForm24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<main class="cd-main-content">
    <center>
	    <div class="title" style="text-align:center;">Forgot Password</div>
	    <div class="subTitle">Enter your Email. We will send email new password.</div>
        <div class="feature_div">
            <table class="loginTable">
                <tr>
                    <td class="form_title">
                        Email Address
                    </td>
                    <td style="width:50%;">
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" TextMode="Email"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqValidator_email" runat="server" ErrorMessage="Please, enter your email." Text="*" ControlToValidate="txtEmail" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regularExpressionValidator_email" runat="server" ErrorMessage="Please enter email in the correct format." ForeColor="#FF3300" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>     
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </center>
</main>
</asp:Content>
