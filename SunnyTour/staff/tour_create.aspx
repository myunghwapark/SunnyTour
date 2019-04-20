<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="tour_create.aspx.cs" Inherits="SunnyTour.WebForm13" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">Tour Create</div>
            
                    <table class="table">
                        <tr>
                            <td colspan="3" style="text-align:right;border-top:0;">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Class="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="False"></asp:Button>
                                <asp:Button ID="btnSave" runat="server" Text="Save" Class="btn btn-info" OnClick="btnSave_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <th>Tour Title</th>
                            <td><asp:TextBox ID="txtTourTitle" runat="server" class="form-control"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="reqValidatorTitle" runat="server" ErrorMessage="Please, enter tour title." ControlToValidate="txtTourTitle" ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th>Price</th>
                            <td><asp:TextBox ID="txtPrice" runat="server" TextMode="Number" class="form-control"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="reqValidatorPrice" runat="server" ErrorMessage="Please, enter price." ControlToValidate="txtPrice" ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th>Tour Region</th>
                            <td><asp:TextBox ID="txtTourRegion" runat="server" class="form-control"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="reqValidatorRegion" runat="server" ErrorMessage="Please, enter tour region." ControlToValidate="txtTourRegion" ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th>Image URL</th>
                            <td>
                                <p>Change the image:</p>
                                <asp:FileUpload ID="fileUpload_image" runat="server"></asp:FileUpload>
                            </td>
                            <td><asp:RequiredFieldValidator ID="reqValidatorImage" runat="server" ErrorMessage="Please, select an image." ControlToValidate="fileUpload_image" ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th>Description</th>
                            <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <th>Tour Status</th>
                            <td><asp:DropDownList ID="dropDownList_tourStatus" runat="server" AutoPostBack="false" class="form-control">
                                </asp:DropDownList>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3"><asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300"></asp:ValidationSummary></td>
                        </tr>
                    </table>
             </div>
        </center>
    </main>
</asp:Content>
