<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="tour_management.aspx.cs" Inherits="SunnyTour.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">Tour Management</div>
                <div style="text-align:right;padding:10px;"><asp:Button ID="btnCreateTour" runat="server" Text="Create Tour" Class="btn btn-primary" OnClick="btnCreateTour_Click"></asp:Button></div>
                <asp:GridView ID="GridView_Tour" runat="server" AutoGenerateColumns="False" DataKeyNames="tourSeqNo" 
                    DataSourceID="SqlDataSource" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333"
                    GridLines="None" CssClass="table">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="tourSeqNo" HeaderText="Sequence No" SortExpression="userId"></asp:BoundField>
                        <asp:BoundField DataField="tourTitle" HeaderText="Title" SortExpression="bookingStatus"></asp:BoundField>
                        <asp:BoundField DataField="price" HeaderText="Price" SortExpression="travelerNumber"></asp:BoundField>
                        <asp:BoundField DataField="tourRegion" HeaderText="Tour Region" SortExpression="travelDate"></asp:BoundField>
                        <asp:BoundField DataField="tourStatus" HeaderText="Status" SortExpression="createDate"></asp:BoundField>
                        <asp:BoundField DataField="createDate" HeaderText="Create Date" ReadOnly="True" InsertVisible="False" SortExpression="tourBookingSeqNo"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input type="button" value="Detail" Class="btn btn-info" onclick=goDetailPage(<%#Eval("tourSeqNo") %>) />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <center><strong>There is no data to show.</strong></center>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource" ConnectionString='<%$ ConnectionStrings:dbSunnyTour %>' 
                    SelectCommand="SELECT tourSeqNo, tourTitle, price, tourRegion, imageUrl, tourStatus AS tourStatusCode, 
                    (select codeName from tbCommonCode where tourStatus = codeNo) AS tourStatus, createDate FROM [tbTour] order by tourSeqNo desc"></asp:SqlDataSource>
            </div>
        </center>
    </main>

    <script>
        
            function goDetailPage(tourSeqNo) {
                window.location.href = "/staff/tour_detail.aspx?tourSeqNo="+tourSeqNo;
            }
    </script>
</asp:Content>
