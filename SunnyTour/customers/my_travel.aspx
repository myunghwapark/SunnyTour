<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="my_travel.aspx.cs" Inherits="SunnyTour.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<main class="cd-main-content" style="margin-bottom:100px;">
	<div class="title">My Travel</div>
    <div>
        <div style="text-align:right;margin:0 20px;">
            <input id="btnCheckOut" type="button" value="Check Out" Class="btn btn-success btn-lg" onclick="goCheckOut()" />
        </div>
        <div class="sub_title_blue" style="margin-left:200px;">Tour Booking</div>
        <asp:ListView ID="ListView_MyTravel" runat="server">
            <ItemTemplate>
                <table style="margin:auto;padding-top:5px;">
                    <tr>
                        <td>
                            <div class="form-check"><input name="checkboxTour" type="checkbox" value="<%#Eval("tourBookingSeqNo") %>" class="form-check-input"/></div>
                        </td>
                        <td class="myTourList">
                            <img src="<%#Eval("imageUrl") %>" alt="<%#Eval("tourTitle") %>" style="width:100px;height:100px;">
                        </td>
		                <td class="myTourList" style="width:700px">
                            <table>
                                <tr>
                                    <td style="width:350px;"><span class="strongText"><%#Eval("tourTitle") %></span></td>
                                    <td><span class="strongText">Travel Date:</span> <%#Eval("travelDate") %></td>
                                </tr>
                                <tr>
                                    <td><span class="strongText">Traveler Number:</span> <%#Eval("travelerNumber") %></td>
                                    <td><span class="strongText">Status:</span> <%#Eval("bookingStatus") %></td>
                                </tr>
                            </table>
		                </td>
                        <td class="myTourList" style="width:200px;">
                            <input type="button" value="Edit" Class="btn btn-info" onclick=goTourEditPage(<%#Eval("tourBookingSeqNo") %>) />
                        </td>
                    </tr>
		        </table>
		    </ItemTemplate>
            <EmptyDataTemplate>
                <center><strong>There is no data to show.</strong></center>
            </EmptyDataTemplate>
        </asp:ListView>
        
        <div class="sub_title_blue" style="margin-top:50px;margin-left:200px;">Shuttle Booking</div>
        <div style="margin-left:200px;margin-bottom:10px;font-size:14px;color:gray;">We will contact you after calculating the amount of shuttle service in proportion to distance.</div>
        <asp:ListView ID="ListView_MyShuttle" runat="server">
            <ItemTemplate>
                <table class="table" style="width:80%;margin:auto;">
                    <tr>
                        <td><%#Eval("shuttleBookingSeqNo") %></td>
                        <td>From <%#Eval("pickupLocation") %></td>
                        <td>To <%#Eval("dropOffLocation") %></td>
                        <td><%#Eval("passengerNumber") %> people</td>
                        <td><%#Eval("pickupTime") %></td>
                        <td><%#Eval("bookingStatus") %></td>
                        <td class="myTourList" style="width:200px;">
                            <input type="button" value="Edit" Class="btn btn-info" onclick=goShuttleEditPage(<%#Eval("shuttleBookingSeqNo") %>) />
                        </td>
                    </tr>
                </table>
		    </ItemTemplate>
            <EmptyDataTemplate>
                <center><strong>There is no data to show.</strong></center>
            </EmptyDataTemplate>
        </asp:ListView>
     </div>
</main>
    
    <script>
        
        function goTourEditPage(tourBookingSeqNo) {
            window.location.href = "/customers/my_tour_booking.aspx?tourBookingSeqNo="+tourBookingSeqNo;
        }

        function goShuttleEditPage(shuttleBookingSeqNo) {
            window.location.href = "/customers/my_shuttle_booking.aspx?shuttleBookingSeqNo="+shuttleBookingSeqNo;
        }

        function goCheckOut() {
            var checkoutTourList = "";
            $("input[name=checkboxTour]:checked").each(function () {
                if (checkoutTourList != "") {
                    checkoutTourList += "_";
                }
				checkoutTourList += $(this).val();
            });

            
            if (checkoutTourList == "") {
                alert("Please, select the services you would like to check out.");
                return;
            }
            window.location.href = "/customers/checkout.aspx?tourBookingSeqNo="+checkoutTourList;
        }
    </script>
</asp:Content>
