<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="my_tour_booking.aspx.cs" Inherits="SunnyTour.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<main class="cd-main-content">
	<div class="title">My Travel Detail</div>
    <table class="table" style="width:90%;margin:auto;">
        <tr>
            <td style="border-top:0;">
                <asp:Button ID="btnList" runat="server" Text="List" Class="btn btn-secondary" OnClick="btnList_Click"></asp:Button>
            </td>
            <td style="border-top:0; text-align:right;">
                <asp:Button ID="btnSave" runat="server" Text="Save" Class="btn btn-info" OnClick="btnSave_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td rowspan="3" style="text-align:center;">
                <asp:Image ID="imageTour" runat="server" style="width:200px;" />
            </td>
            <td>
                <asp:Label ID="labelTitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Travel Date: <asp:TextBox ID="txtTravelDate" runat="server" TextMode="Date" class="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Traveler Number: <asp:TextBox ID="txtTravelerNumber" runat="server" TextMode="Number" class="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="labelLocation" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="labelStatus" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Register Date: 
                <asp:Label ID="labelRegisterDate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnCancel" runat="server" Text="Cancel The Travel" Class="btn btn-secondary" OnClick="btnCancel_Click" OnClientClick="confirmAspButton(this); return false;"></asp:Button></td>
        </tr>
    </table>
    
</main>
    
</asp:Content>
