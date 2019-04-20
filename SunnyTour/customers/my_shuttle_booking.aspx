<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="my_shuttle_booking.aspx.cs" Inherits="SunnyTour.WebForm30" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<main class="cd-main-content">
	<div class="title">My Shuttle Booking Detail</div>
    <table class="table">
        <tr>
            <td colspan="2" style="border-top:0;">
                <asp:Button ID="btnList" runat="server" Text="List" Class="btn btn-info" OnClick="btnList_Click" CausesValidation="False"></asp:Button>
            </td>
        </tr>
    </table>

    <div class="feature_div">
		
		<div class="form_title">Where</div>
		<div>
		    <asp:DropDownList ID="dropDownWhere" runat="server" class="form-control" AutoPostBack = "false" OnSelectedIndexChanged ="dropdownChaged">
            </asp:DropDownList>
		</div>

        <div id="pickUpLocation">
		    <div class="form_title">Pick up location<asp:RequiredFieldValidator ControlToValidate="txtPickUpLocation" ID="reqValidator_pickupLocation" runat="server" ErrorMessage="Please, enter pick up location" ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		    <div>
		        <asp:TextBox ID="txtPickUpLocation" runat="server" class="form-control" placeholder="Please enter an address" ClientIDMode="Static"></asp:TextBox>
                
            </div>
        </div>
		<div class="clearfix"></div>
            
        <div id="dropOffLocation">
		    <div class="form_title">Drop off location<asp:RequiredFieldValidator ControlToValidate="txtDropOffLocation" ID="reqValidator_dropOffLocation" runat="server" ErrorMessage="Please, enter drop off location" ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		    <div>
		        <asp:TextBox ID="txtDropOffLocation" runat="server" class="form-control" placeholder="Please enter an address" ClientIDMode="Static"></asp:TextBox>
                
            </div>
        </div>

		<div class="form_title">What time would like to picked up?
            <asp:RequiredFieldValidator ControlToValidate="txtShuttleDate"  ID="reqValidator_ShuttleDate" runat="server" ErrorMessage="Please, select pick up date." Text="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ControlToValidate="txtShuttleTime"  ID="reqValidator_ShuttleTime" runat="server" ErrorMessage="Please, select pick up time." Text="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
		</div>
		    
        <div>
            <asp:TextBox ID="txtShuttleDate" runat="server" TextMode="Date" class="form-control"></asp:TextBox><asp:TextBox ID="txtShuttleTime" runat="server" TextMode="Time" class="form-control"></asp:TextBox>
        </div>

		<div class="form_title">Number of Passenger
            <asp:RequiredFieldValidator ControlToValidate="txtNumberOfPassenger"  ID="reqValidator_NumberOfPassenger" runat="server" ErrorMessage="Please, enter number of passenger." Text="*" ForeColor="#FF3300"></asp:RequiredFieldValidator></div>
		    
        <div>
            <asp:TextBox ID="txtNumberOfPassenger" runat="server" TextMode="Number" class="form-control"></asp:TextBox>
        </div>
        <div class="form_title">Status</div>
        <div>
            <asp:Label ID="labelStatus" runat="server" ForeColor="#FF3300"></asp:Label>
        </div>
        <div>
            <asp:Label ID="labelNotice" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
        </div>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="true" ForeColor="#FF3300" />
        <div style="padding-top:30px;text-align:center">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel The Travel" Class="btn btn-secondary" OnClick="btnCancel_Click" OnClientClick="confirmAspButton(this); return false;" CausesValidation="False"></asp:Button>
            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" style="width:200px;" OnClick="btnSave_Click" />
        </div>
		<div class="clearfix"></div>
	</div>
    
</main>
</asp:Content>
