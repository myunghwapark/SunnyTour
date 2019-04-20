<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="promotion_detail.aspx.cs" Inherits="SunnyTour.WebForm22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">Promotion Detail</div>
            
                    <table class="table">
                        <tr>
                            <td style="border-top:0;"><asp:Button ID="btnList" runat="server" Text="List" Class="btn btn-info" OnClick="btnList_Click"></asp:Button></td>
                            <td style="text-align:right;border-top:0;" colspan="3">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Class="btn btn-secondary" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete?')"></asp:Button>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" Class="btn btn-info" OnClick="btnEdit_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <th>Promotion No</th>
                            <td><asp:Label ID="labelPromotionSeqNo" runat="server" Text=""></asp:Label></td>
                            <th>Promotion Title</th>
                            <td><asp:Label ID="labelPromotionTitle" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <th>Promotion Image</th>
                            <td colspan="3"><asp:Image ID="imagePromotion" runat="server"></asp:Image></td>
                        </tr>
                        <tr>
                            <th>Promotion Contents</th>
                            <td colspan="3"><asp:Label ID="labelContent" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <th>Discount Type</th>
                            <td><asp:Label ID="labelDiscountType" runat="server" Text=""></asp:Label></td>
                            <th>Discount Value</th>
                            <td><asp:Label ID="labelDiscountAmount" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <th>Start Date</th>
                            <td><asp:Label ID="labelStartDate" runat="server" Text="" /></td>
                            <th>End Date</th>
                            <td><asp:Label ID="labelEndDate" runat="server" Text="" /></td>
                        </tr>
                        <tr>
                            <th>Link URL</th>
                            <td><asp:Label ID="labelLinkUrl" runat="server" Text="" /></td>
                            <th>Status</th>
                            <td><asp:Label ID="labelStatus" runat="server" Text="" /></td>
                        </tr>
                        <tr>
                            <th>Product ID</th>
                            <td><asp:Label ID="labelProductId" runat="server" Text="" /></td>
                            <th>Product Title</th>
                            <td><asp:Label ID="labelProcuctTitle" runat="server" Text="" /></td>
                        </tr>
                        <tr>
                            <th>Promotion Type</th>
                            <td><asp:Label ID="labelPromotionType" runat="server" Text=""></asp:Label></td>
                            <th>Register Date</th>
                            <td><asp:Label ID="labelCreateDate" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
              </div>
        </center>
    </main>
</asp:Content>
