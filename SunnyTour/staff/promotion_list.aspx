<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="promotion_list.aspx.cs" Inherits="SunnyTour.WebForm21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">Promotion</div>
                

                <div style="text-align:right;padding:10px;"><asp:Button ID="btnCreatePromotion" runat="server" Text="Create Promotion" Class="btn btn-primary" OnClick="btnCreatePromotion_Click"></asp:Button></div>

                <nav class="navbar navbar-expand-lg navbar-light bg-light" style="text-align:right;">
                  <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <div class="form-group row" style="margin-right:30px;margin-bottom:0; ">
                        <span style="font-size:9pt;margin-right:30px;margin-top:5px;">Promotion Date</span>
                        <input id="txtStartDate" type="date" class="form-control mr-sm-2" style="width:150px;display:inline;">&nbsp;-&nbsp;<input id="txtEndDate" type="date" class="form-control mr-sm-2" style="width:150px;display:inline;">
                    </div>
                    <div class="input-group mb-3" style="width:25%;margin-right:30px;margin-bottom:0 !important;">
                      <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Promotion Type</label>
                      </div>
                      <select class="custom-select custom-select-sm" style="font-size:1rem;height:auto;" id="promotionType">
                        <option value="1" selected>Tour</option>
                        <option value="2">Shuttle</option>
                       </select>
                    </div>

                    <input id="txtSearch" class="form-control mr-sm-2" type="search" placeholder="Tour title" aria-label="Search" style="width:30%;">
                    <input type="button" value="Search" class="btn btn-outline-success my-2 my-sm-0" id="btnSearch">
                  </div>
                </nav>

                <asp:GridView ID="GridView_PromotionList" runat="server" AutoGenerateColumns="False" DataKeyNames="promotionSeqNo" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="promotionSeqNo" HeaderText="No" InsertVisible="False" ReadOnly="True" SortExpression="promotionSeqNo" />
                        <asp:BoundField DataField="promotionTitle" HeaderText="Promotion Title" SortExpression="promotionTitle" />
                        <asp:BoundField DataField="promotionType" HeaderText="Promotion Type" SortExpression="promotionType" />
                        <asp:BoundField DataField="productSeqId" HeaderText="Product Id" SortExpression="productSeqId" />
                        <asp:BoundField DataField="startDate" HeaderText="Start Date" SortExpression="startDate" />
                        <asp:BoundField DataField="endDate" HeaderText="End Date" SortExpression="endDate" />
                        <asp:BoundField DataField="discountType" HeaderText="Discount Type" SortExpression="discountType" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input type="button" value="Detail" Class="btn btn-info" onclick=goDetailPage(<%#Eval("promotionSeqNo") %>) />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <center><strong>There is no data to show.</strong></center>
                    </EmptyDataTemplate>
                </asp:GridView>
                
                </div>
        </center>
    </main>
    
    <script>
        
    $(document).ready(function () {

        if ('<%=Request.QueryString["startDate"]%>' != null && '<%=Request.QueryString["startDate"]%>' != "") {
            $("#txtStartDate").val('<%=Request.QueryString["startDate"]%>');
        }
        if ('<%=Request.QueryString["endDate"]%>' != null && '<%=Request.QueryString["endDate"]%>' != "") {
            $("#txtEndDate").val('<%=Request.QueryString["endDate"]%>');
        }
        if ('<%=Request.QueryString["promotionType"]%>' != null && '<%=Request.QueryString["promotionType"]%>' != "") {
            $("#promotionType").val('<%=Request.QueryString["promotionType"]%>');
        }
        if ('<%=Request.QueryString["txtSearch"]%>' != null && '<%=Request.QueryString["txtSearch"]%>' != "") {
            $("#txtSearch").val('<%=Request.QueryString["txtSearch"]%>');
        }

        $("#btnSearch").on("click", function () {
            var promotionType = $("#promotionType option:selected").val();
            window.location.href = "/staff/promotion_list.aspx?startDate="+$("#txtStartDate").val()+"&endDate="+$("#txtEndDate").val()+"&promotionType="+promotionType+"&txtSearch="+$("#txtSearch").val();
        });
    });

        function goDetailPage(promotionSeqNo) {
            window.location.href = "/staff/promotion_detail.aspx?promotionSeqNo="+promotionSeqNo;
        }
    </script>
</asp:Content>
