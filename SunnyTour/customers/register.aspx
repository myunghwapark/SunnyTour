<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="SunnyTour.WebForm20" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<main class="cd-main-content">
    <center>
	<div class="title" style="text-align:center;">Register</div>
    <div class="feature_div">
        <table class="loginTable">
            <tr>
                <td class="form_title" style="width:20%;">Email</td>
                <td style="width:50%;">
                    <asp:TextBox ID="txtUserId" runat="server" class="form-control"></asp:TextBox>
                    <asp:HiddenField ID="idChecked" runat="server" Value="N"></asp:HiddenField>
                </td>
                <td style="padding:0;">
                   <asp:Button ID="btnCheckId" runat="server" Text="Check ID" CssClass="btn btn-info" AutoPostBack="false" CausesValidation="False" OnClick="btnCheckId_Click"></asp:Button><asp:RequiredFieldValidator ID="reqValidator_userId" runat="server" ErrorMessage="Please, enter your ID." Text="*" ControlToValidate="txtUserId" ForeColor="#FF3300"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="regularExpressionValidator_email" runat="server" ErrorMessage="Please enter email in the correct format." ForeColor="#FF3300" ControlToValidate="txtUserId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>     
            </tr>
            <tr>
                <td class="form_title">
                    First Name
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqValidator_firstName" runat="server" ErrorMessage="Please, enter first name." Text="*" ControlToValidate="txtFirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>     
            </tr>
            <tr>
                <td class="form_title">
                    Last Name
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqValidator_lastName" runat="server" ErrorMessage="Please, enter last name." Text="*" ControlToValidate="txtLastName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>     
            </tr>
            <tr>
                <td class="form_title">
                    Phone number
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" class="form-control" TextMode="Phone"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please, enter phone number." Text="*" ControlToValidate="txtPhoneNumber" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
                <td class="form_title">Confirm Password</td>
                <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="reqValidator_confirmPassword" runat="server" ControlToValidate="txtConfirmPassword" Text="*" ErrorMessage="Please, enter confirm password." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="compareValidator_password" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Text="*" ErrorMessage="Password and Confirm Password should be the same." ForeColor="#FF3300"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300" />
                </td>
            </tr>
            <tr>
                <td colspan="3" class="center">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-primary" OnClick="btnRegister_Click" />
                </td>
            </tr>
        </table>
    </div>
    </center>
</main>
</asp:Content>
