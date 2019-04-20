<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="shuttle_booking.aspx.cs" Inherits="SunnyTour.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">Shuttle Booking</div>
            
                <asp:GridView ID="GridView_shuttleBooking" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="shuttleBookingSeqNo" DataSourceID="SqlDataSource" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="shuttleBookingSeqNo" HeaderText="NO" InsertVisible="False" ReadOnly="True" SortExpression="shuttleBookingSeqNo" />
                        <asp:BoundField DataField="userId" HeaderText="userId" SortExpression="userId" />
                        <asp:BoundField DataField="bookingStatus" HeaderText="Status" SortExpression="bookingStatus" />
                        <asp:BoundField DataField="pickupLocation" HeaderText="Pickup Location" SortExpression="pickupLocation" />
                        <asp:BoundField DataField="dropOffLocation" HeaderText="Drop Off Location" SortExpression="dropOffLocation" />
                        <asp:BoundField DataField="pickupTime" HeaderText="Pickup Time" SortExpression="pickupTime" />
                        <asp:BoundField DataField="createDate" HeaderText="Register Date" SortExpression="createDate" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input type="button" value="Detail" Class="btn btn-info" onclick=goDetailPage(<%#Eval("shuttleBookingSeqNo") %>) />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <center><strong>There is no data to show.</strong></center>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbSunnyTour %>" SelectCommand="SELECT [shuttleBookingSeqNo], passengerNumber, [userId], (select codeName from tbCommonCode where bookingStatus = codeNo) AS bookingStatus, (select codeName from tbCommonCode where shuttleType = codeNo) AS shuttleType, [pickupLocation], [dropOffLocation], [pickupTime], [createDate] FROM [tbShuttleBooking]"></asp:SqlDataSource>
            </div>
        </center>
    </main>
    
    <script>
        
            function goDetailPage(shuttleBookingSeqNo) {
                window.location.href = "/staff/shuttle_booking_detail.aspx?shuttleBookingSeqNo="+shuttleBookingSeqNo;
            }
    </script>
</asp:Content>
