<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="tour_booking.aspx.cs" Inherits="SunnyTour.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">Tour Booking</div>
                <asp:GridView ID="GridView_TourBooking" runat="server" AutoGenerateColumns="False" DataKeyNames="tourBookingSeqNo" 
                    DataSourceID="SqlDataSource" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333"
                    GridLines="None" CssClass="table">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="userId" HeaderText="User ID" SortExpression="userId"></asp:BoundField>
                        <asp:BoundField DataField="bookingStatus" HeaderText="Status" SortExpression="bookingStatus"></asp:BoundField>
                        <asp:BoundField DataField="travelerNumber" HeaderText="Traveler Number" SortExpression="travelerNumber"></asp:BoundField>
                        <asp:BoundField DataField="travelDate" HeaderText="Travel Date" SortExpression="travelDate"></asp:BoundField>
                        <asp:BoundField DataField="createDate" HeaderText="Register Date" SortExpression="createDate"></asp:BoundField>
                        <asp:BoundField DataField="tourBookingSeqNo" HeaderText="Booking No" ReadOnly="True" InsertVisible="False" SortExpression="tourBookingSeqNo"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input type="button" value="Detail" Class="btn btn-info" onclick=goDetailPage(<%#Eval("tourBookingSeqNo") %>) />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <center><strong>There is no data to show.</strong></center>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource" ConnectionString='<%$ ConnectionStrings:dbSunnyTour %>' 
                    SelectCommand="SELECT [userId], (select codeName from tbCommonCode where bookingStatus = codeNo) AS bookingStatus, [travelerNumber], [travelDate], [createDate], [tourBookingSeqNo] FROM [tbTourBooking]"></asp:SqlDataSource>
            </div>
        </center>
    </main>

    <script>
        
            function goDetailPage(tourBookingSeqNo) {
                window.location.href = "/staff/tour_booking_detail.aspx?tourBookingSeqNo="+tourBookingSeqNo;
            }
    </script>
</asp:Content>
