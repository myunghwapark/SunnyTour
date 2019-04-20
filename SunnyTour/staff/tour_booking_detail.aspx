<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="tour_booking_detail.aspx.cs" Inherits="SunnyTour.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">Tour Booking Detail</div>
            
                    <table class="table">
                        <tr>
                            <td style="border-top:0;"><asp:Button ID="btnList" runat="server" Text="List" Class="btn btn-info" OnClick="btnList_Click"></asp:Button></td>
                            <td style="text-align:right;border-top:0;">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Class="btn btn-secondary" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete?')"></asp:Button>
                                <asp:Button ID="btnSave" runat="server" Text="Save" Class="btn btn-info" OnClick="btnSave_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <th>Booking No</th>
                            <td><asp:Label ID="labelTourBookingSeqNo" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <th>User ID</th>
                            <td><asp:Label ID="labelUserId" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <th>User Name</th>
                            <td><asp:Label ID="labelName" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <th>Phone number</th>
                            <td><asp:Label ID="labelPhone" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <th>Register Date</th>
                            <td><asp:Label ID="labelRegisterDate" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <th>Price</th>
                            <td><asp:Label ID="labelPrice" runat="server" Text="" /></td>
                        </tr>
                        <tr>
                            <th>Travel Date</th>
                            <td><asp:Label ID="labelTravelDate" runat="server" Text="" /></td>
                        </tr>
                        <tr>
                            <th>Travel Region</th>
                            <td><asp:Label ID="labelTourRegion" runat="server" Text="" /></td>
                        </tr>
                        <tr>
                            <th>Traveler Number</th>
                            <td><asp:Label ID="labelTravelerNumber" runat="server" Text="" /></td>
                        </tr>
                        <tr>
                            <th>Status</th>
                            <td>
                                <asp:DropDownList ID="dropDownList_status" runat="server" AutoPostBack="True" class="form-control">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
              </div>
        </center>
    </main>
</asp:Content>
