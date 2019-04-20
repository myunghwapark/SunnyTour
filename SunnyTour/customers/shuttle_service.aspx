<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="shuttle_service.aspx.cs" Inherits="SunnyTour.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <div class="title">Private Shuttle Service</div>
	    <div class="subTitle">Your passenger transport solution for airport & wharf transfers, touring, conferences, events and more.</div>
        <!-- Gallery -->
	    <div class="feature_div">
		
		    <div class="form_title">Where</div>
		    <div>
		        <asp:DropDownList ID="dropDownWhere" runat="server" class="form-control" AutoPostBack = "true" OnSelectedIndexChanged ="dropdownChaged">
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
                <asp:RequiredFieldValidator ControlToValidate="txtShuttleDateTime"  ID="reqValidator_ShuttleDateTime" runat="server" ErrorMessage="Please, select pick up date and time." Text="*" ForeColor="#FF3300"></asp:RequiredFieldValidator></div>
		    
            <div>
                <asp:TextBox ID="txtShuttleDateTime" runat="server" TextMode="DateTimeLocal" class="form-control"></asp:TextBox>
            </div>

		    <div class="form_title">Number of Passenger
                <asp:RequiredFieldValidator ControlToValidate="txtNumberOfPassenger"  ID="reqValidator_NumberOfPassenger" runat="server" ErrorMessage="Please, enter number of passenger." Text="*" ForeColor="#FF3300"></asp:RequiredFieldValidator></div>
		    
            <div>
                <asp:TextBox ID="txtNumberOfPassenger" runat="server" TextMode="Number" class="form-control"></asp:TextBox>
            </div>
            <div>
                <div id="picker"> </div>
                <input type="hidden" id="result" value="" class="form-control" />
            </div>
            <div>
                <asp:Label ID="labelNotice" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
            </div>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="true" ForeColor="#FF3300" />
            <div style="padding-top:30px;text-align:center">
                <asp:Button ID="btnSubmit" runat="server" Text="SEND" class="btn btn-primary" style="width:200px;" OnClick="btnSubmit_Click" />
            </div>
		    <div class="clearfix"></div>
	    </div>


    </main>

   
</asp:Content>
