<%@ Page Title="" Language="C#" MasterPageFile="~/Tour.Master" AutoEventWireup="true" CodeBehind="nz_tour.aspx.cs" Inherits="SunnyTour.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	    <div class="title" style="text-align:left;">
            <asp:Label ID="labelTitle" runat="server" Text=""></asp:Label>
	    </div>
        <div class="sub_title">
            <asp:Label ID="labelTourRegion" runat="server" Text=""></asp:Label>
        </div>
        <div class="left">
            <asp:Image ID="imgTour" runat="server" style="width:780px;height:430px;" /></div>
        <div class="left gray_box">
            <div class="title_black">
                <asp:Panel ID="panelPromotion" runat="server" Visible="false">
                    <div style="line-height:15pt"><asp:Label ID="labelDiscount" runat="server" Text="Discount Price" CssClass="discountText"></asp:Label></div>
                    <div style="line-height:20pt"><asp:Label ID="labelPromotionPeriod" runat="server" Text="" CssClass="promotionPeriod"></asp:Label></div>
                 </asp:Panel>
                <div>from NZ$<span id="amount"><asp:Label ID="labelPrice" runat="server" Text="Label"></asp:Label></span>
                    <asp:Panel ID="panelOriginalPrice" runat="server" Visible="false">
                        <div style="line-height:15pt"><asp:Label ID="labelOriginalPrice" runat="server" Text="" CssClass="promotionPeriod"></asp:Label></div>
                    </asp:Panel>
                </div>
            </div>
            <hr class="dark_hr" />
            <div class="subTitle_gray">Select Date and Travelers</div>
            <div id="btnDate" class="box_white">
                <img src="/images/icon_date.png" />
                <span><asp:TextBox ID="txtTravelDate" runat="server" TextMode="Date" class="form-control" style="display:inline;width:75%;"></asp:TextBox></span>
                <asp:RequiredFieldValidator ID="reqValidator_travelDate" runat="server" ErrorMessage="Please, enter travel date" ControlToValidate="txtTravelDate" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            </div>
            <div class="box_white">
                <img src="/images/icon_person.png" />
                <span>Number of travelers <asp:TextBox ID="txtTravelerNumber" TextMode="Number" runat="server" MaxLength="1" class="form-control" style="display:inline;width:60px;margin-left:5px;"></asp:TextBox></span>
                <asp:RequiredFieldValidator ID="reqValidator_travelNumber" runat="server" ErrorMessage="Please, enter the number of travelers" ControlToValidate="txtTravelerNumber" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="center" ForeColor="#FF3300" />
                <asp:Label ID="labelNotice" runat="server" CssClass="center" ForeColor="#FF3300" Text="Maximum number of traveler is 4." Visible="False"></asp:Label>
            </div>
            <div style="padding-top:30px;text-align:center">
                <asp:Button ID="btnSubmit" runat="server" Text="Add my cart" class="btn btn-primary" style="width:200px;" OnClick="FormViewTour_ItemCommand" />
            </div>
        </div>
        <div style="clear:both;"></div>
        <div style="margin-top:30px;">
            <div class="sub_title_blue">Description</div>
            <div>
                <asp:Label ID="labelDescription" runat="server" Text=""></asp:Label>
            </div>
        </div>


</asp:Content>
