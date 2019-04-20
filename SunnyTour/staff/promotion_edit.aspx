<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="promotion_edit.aspx.cs" Inherits="SunnyTour.WebForm23" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;"><asp:Label ID="labelTitle" runat="server" Text="Edit"></asp:Label> Promotion</div>
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
                        <th>Promotion Title</th>
                        <td colspan="4"><asp:TextBox ID="txtPromotionTitle" runat="server" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredFieldValidator_PromotionTitle" runat="server" ControlToValidate="txtPromotionTitle" ErrorMessage="Please, enter the promotion title." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <th>Promotion Image</th>
                        <td colspan="4">
                            <asp:FileUpload ID="fileUpload_image" runat="server"></asp:FileUpload>
                            <br />
                            <asp:TextBox ID="txtImageUrl" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                            <asp:HiddenField ID="hiddenThumbnailImage" runat="server"></asp:HiddenField>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <th>Promotion Contents</th>
                        <td colspan="4"><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" class="form-control" style="height:100px;"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredFieldValidator_Content" runat="server" ControlToValidate="txtContent" ErrorMessage="Please, enter the promotion content." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <th>Discount Type</th>
                        <td><asp:DropDownList ID="DropDownListDiscountType" runat="server" AutoPostBack="false" class="form-control"></asp:DropDownList></td>
                        <td style="width:10px;"><asp:RequiredFieldValidator ID="requiredFieldValidator_DiscountType" runat="server" ControlToValidate="DropDownListDiscountType" ErrorMessage="Please, select discount type." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                        <th>Discount Value</th>
                        <td><asp:TextBox ID="txtDiscountValue" runat="server" class="form-control"></asp:TextBox></td>
                        <td style="width:10px;"><asp:RequiredFieldValidator ID="requiredFieldValidator_DiscountValue" runat="server" ControlToValidate="txtDiscountValue" ErrorMessage="Please, enter discount value." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <th>Start Date</th>
                        <td><asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredFieldValidator_StartDate" runat="server" ControlToValidate="txtStartDate" ErrorMessage="Please, enter start date." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                        <th>End Date</th>
                        <td><asp:TextBox ID="txtEndDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredFieldValidator_EndDate" runat="server" ControlToValidate="txtEndDate" ErrorMessage="Please, enter end date." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <th>Link URL</th>
                        <td><asp:TextBox ID="txtLinkUrl" runat="server" class="form-control"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredFieldValidator_LinkUrl" runat="server" ControlToValidate="txtLinkUrl" ErrorMessage="Please, enter link url." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                        <th>Status</th>
                        <td><asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="false" class="form-control"></asp:DropDownList></td>
                        <td><asp:RequiredFieldValidator ID="requiredFieldValidator_Status" runat="server" ControlToValidate="DropDownListStatus" ErrorMessage="Please, select promotion status." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <th>Product</th>
                        <td><asp:DropDownList ID="DropDownListProduct" runat="server" AutoPostBack="false" class="form-control"></asp:DropDownList></td>
                        <td><asp:RequiredFieldValidator ID="requiredFieldValidator_Product" runat="server" ControlToValidate="DropDownListProduct" ErrorMessage="Please, select product." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                        <th>Promotion Type</th>
                        <td><asp:DropDownList ID="DropDownListPromotionType" runat="server" AutoPostBack="false" class="form-control"></asp:DropDownList></td>
                        <td><asp:RequiredFieldValidator ID="requiredFieldValidator_PromotionType" runat="server" ControlToValidate="DropDownListPromotionType" ErrorMessage="Please, select promotion type." ForeColor="#FF3300">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td colspan="6"><asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300"></asp:ValidationSummary></td>
                    </tr>
                </table>
            </div>
        </center>
    </main>
</asp:Content>
