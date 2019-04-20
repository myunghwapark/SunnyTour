<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SunnyTour.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Start WOWSlider.com HEAD section -->
<link rel="stylesheet" type="text/css" href="/js/wowslider/style.css" />
<script type="text/javascript" src="/js/wowslider/jquery.js"></script>
<!-- End WOWSlider.com HEAD section -->

	

<main class="cd-main-content">
	
    <center>
    <!-- Start WOWSlider.com BODY section -->
    <div id="wowslider-container1">
        <div class="ws_images">
            <ul>
                <asp:ListView ID="ListView_Promotion" runat="server" DataSourceID="SqlDataSourcePromotion">
		            <ItemTemplate>
		                <li><a href="<%#Eval("linkUrl") %>"><img src="<%#Eval("imageUrl") %>" alt="<img src="<%#Eval("promotionTitle") %>" title="<img src="<%#Eval("promotionTitle") %>" id="<%#Eval("promotionSeqNo") %>"/></a></li>
		            </ItemTemplate>
                </asp:ListView>
	        </ul>
        </div>
	    <div class="ws_bullets">
            <div>
                <asp:ListView ID="ListView_Bullets" runat="server" DataSourceID="SqlDataSourcePromotion">
		            <ItemTemplate>
		                <a href="#" title="<%#Eval("promotionTitle") %>"><span><img src="<%#Eval("thumbnailImageUrl") %>" alt="<%#Eval("promotionTitle") %>"/><%#Eval("rowNum") %></span></a>
                    </ItemTemplate>
                </asp:ListView>
	        </div>
	    </div>
        <div class="ws_script" style="position:absolute;left:-99%"></div>
        <div class="ws_shadow"></div>
        <asp:SqlDataSource ID="SqlDataSourcePromotion" runat="server" ConnectionString="<%$ ConnectionStrings:dbSunnyTour %>" 
            SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY promotionSeqNo ASC) AS rowNum, promotionSeqNo, promotionTitle, imageUrl, thumbnailImageUrl, linkUrl FROM tbPromotion where promotionStatus = 'G001_002' and convert(varchar, startDate, 23) <= convert(varchar, GETDATE(), 23) and convert(varchar, endDate, 23) >= convert(varchar, GETDATE(), 23)"></asp:SqlDataSource>
		
    </div>	
    </center>
    <script type="text/javascript" src="/js/wowslider/wowslider.js"></script>
    <script type="text/javascript" src="/js/wowslider/script.js"></script>
    <!-- End WOWSlider.com BODY section -->


	<div class="main_gallery">
		<div class="gallery_title">Explore attractions in New Zealand</div>

        <asp:ListView ID="TourListView" runat="server" DataSourceID="SqlDataSource">
		    <ItemTemplate>
                <div class="responsive">
		          <div class="gallery">
		            <a href="/customers/nz_tour.aspx?tourSeqNo=<%#Eval("tourSeqNo") %>">
		              <img src="<%#Eval("imageUrl") %>" alt="<%#Eval("tourTitle") %>">
		            </a>
		            &nbsp;&nbsp;<div class="desc"><%#Eval("tourTitle") %></div>
		          </div>
		        </div>
		    </ItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbSunnyTour %>" SelectCommand="SELECT tourSeqNo, tourTitle, tourRegion, imageUrl, tourStatus, createDate FROM [tbTour] where tourStatus='G001_002'"></asp:SqlDataSource>
		
		<div class="clearfix"></div>
	</div>
	<!--// Gallery -->
</main>

</asp:Content>
