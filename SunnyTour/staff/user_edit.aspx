<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="user_edit.aspx.cs" Inherits="SunnyTour.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;"><asp:Label ID="LabelTitle" runat="server" Text="Edit"></asp:Label> User</div>
                <table style="width:100%;margin-bottom:10px;">
                    <tr>
                        <td style="text-align:left;"><asp:Button ID="btnList" runat="server" Text="List" Class="btn btn-info" OnClick="btnList_Click" CausesValidation="False"></asp:Button></td>
                        <td style="text-align:right;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" Class="btn btn-success" OnClick="btnSave_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
                <table class="table">
                    <tr>
                        <td style="width:15%;">Email(User ID)</td>
                        <td style="width:40%;"><asp:TextBox ID="txtUserId" runat="server" class="form-control"></asp:TextBox>
                            <asp:HiddenField ID="idChecked" runat="server" Value="N"></asp:HiddenField>
                        </td>
                        <td>
                            <asp:Button ID="btnIdCheck" runat="server" Text="Check ID" Class="btn btn-info" Visible="False" AutoPostBack="false" OnClick="btnIdCheck_Click" CausesValidation="False"></asp:Button>
                            <asp:RequiredFieldValidator ID="reqValidator_UserId" runat="server" ErrorMessage="Please, enter user ID." ControlToValidate="txtUserId" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regularExpressionValidator_UserId" runat="server" ErrorMessage="Please enter email in the correct format." ForeColor="#FF3300" ControlToValidate="txtUserId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="reqValidator_Password" runat="server" ErrorMessage="Please, enter password." ControlToValidate="txtPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>Confirm Password</td>
                        <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please, enter confirm password." ForeColor="#FF3300"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password and Confirm Password should be the same." ForeColor="#FF3300"></asp:CompareValidator></td>
                    </tr>
                    <tr>
                        <td>First Name</td>
                        <td><asp:TextBox ID="txtFirstName" runat="server" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="reqValidator_FirstName" runat="server" ErrorMessage="Please, enter first name." ControlToValidate="txtFirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>Last Name</td>
                        <td><asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="reqValidator_LastName" runat="server" ErrorMessage="Please, enter last name." ControlToValidate="txtLastName" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>Phone Number</td>
                        <td><asp:TextBox ID="txtPhoneNumber" runat="server" TextMode="Number" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="reqValidator_PhoneNumber" runat="server" ErrorMessage="Please, enter phone number." ControlToValidate="txtPhoneNumber" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>User Type</td>
                        <td>
                            <asp:DropDownList ID="dropDownListUser" runat="server" AutoPostBack="false" DataSourceID="SqlDataSourceUserDropdown" DataTextField="userType" DataValueField="userTypeCode" class="form-control"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceUserDropdown" runat="server" ConnectionString="<%$ ConnectionStrings:dbSunnyTour %>" 
                                SelectCommand="SELECT DISTINCT [userType] AS userTypeCode, (select codeName from tbCommonCode where codeNo = userType) AS userType FROM [tbUser]"></asp:SqlDataSource>
                        </td>
                        <td></td>
                    </tr>
                </table>
                   
             </div>
        </center>
    </main>
</asp:Content>
