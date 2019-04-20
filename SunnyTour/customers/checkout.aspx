<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="SunnyTour.WebForm31" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <div class="content_div" style="padding:20px 3% 8em;">
	        <div class="title" style="text-align:center;">Secure Checkout</div>
            <div class="subTitle">Fill in the fields below to complete your older</div>
            <div style="text-align:right;margin:0 20px;">
                <input id="btnBack" type="button" value="Back to Cart" Class="btn btn-secondary" onclick="goBack()" />
            </div>
            <div class="checkout_box">
                <div style="width:25%;float:left;">
                    <div class="sub_title_blue">Customer Information</div>
                    <div class="form_label">First Name<asp:RequiredFieldValidator ControlToValidate="txtFirstName" ID="reqValidator_firstName" runat="server" ErrorMessage="Please enter your first name." ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		            <div>
		                <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="Please enter your first name." ></asp:TextBox>
                    </div>
                    <div class="form_label">Last Name<asp:RequiredFieldValidator ControlToValidate="txtLastName" ID="reqValidator_lastName" runat="server" ErrorMessage="Please enter your last name." ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		            <div>
		                <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Please enter your last name."></asp:TextBox>
                    </div>
		            <div class="form_label">Telephone<asp:RequiredFieldValidator ControlToValidate="txtPhone" ID="reqValidator_phone" runat="server" ErrorMessage="Please enter your phone number" ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		            <div>
		                <asp:TextBox ID="txtPhone" TextMode="Number" runat="server" class="form-control" placeholder="Please enter your phone number" ></asp:TextBox>
                    </div>
                </div>
                <div style="width:25%;margin-left:4%;float:left;">
                    <div class="sub_title_blue">Payment</div>
                    <label class="radio-inline" style="margin-right:50px;">
                        <asp:RadioButton ID="payTypeBanking" runat="server" GroupName="payType" Text="Internet Banking" Checked="true" AutoPostBack="true" OnCheckedChanged="payTypeCheckedChanged" /></label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="payTypeCreditCard" runat="server" GroupName="payType" Text="creditCard" AutoPostBack="true" OnCheckedChanged="payTypeCheckedChanged" />
                    </label>
                    <asp:Panel ID="internetBanking" runat="server">
                        <div style="margin-top:10px;color:dimgray;">
                            Account Name: Alice and Sean Enterprise Ltd<br />
                            Bank of New Zealand Account Number: 12-3066-0019517-00<br />
                            Please use your order number as a reference!
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="creditCard" runat="server" Visible="false">
                        <div class="form_label">Name on Card<asp:RequiredFieldValidator ControlToValidate="txtNameOnCard" ID="reqValidator_nameOnCard" runat="server" ErrorMessage="Please enter name on your card." ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		                <div>
		                    <asp:TextBox ID="txtNameOnCard" runat="server" class="form-control"/>
                        </div>
                        <div class="form_label">Credit Card Type<asp:RequiredFieldValidator ControlToValidate="dropDownCardType" ID="reqValidator_cardType" runat="server" ErrorMessage="Please select card type." ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		                <div>
		                    <asp:DropDownList ID="dropDownCardType" runat="server" class="form-control" AutoPostBack = "false">
                            </asp:DropDownList>
                        </div>
                        <div class="form_label">Credit Card Number<asp:RequiredFieldValidator ControlToValidate="txtCardNumber" ID="reqValidator_cardNumber" runat="server" ErrorMessage="Please enter card number." ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		                <div>
		                    <asp:TextBox ID="txtCardNumber" runat="server" TextMode="Number" class="form-control"/>
                        </div>
                        <div class="form_label">Expiration Date</div>
		                <div>
		                    <asp:DropDownList ID="dropDownMonth" runat="server" class="form-control expirationDate" AutoPostBack = "false">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="dropDownMonth" ID="reqValidator_expirationMonth" runat="server" class="expirationDateRequireVaridator" ErrorMessage="Please select expiration month." ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator>
		                    <asp:DropDownList ID="dropDownYear" runat="server" class="form-control expirationDate" AutoPostBack = "false">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="dropDownYear" ID="reqValidator_expirationYear" runat="server" class="expirationDateRequireVaridator" ErrorMessage="Please select expiration year." ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator>
                        </div>
                        <div class="form_label">Card Verification Number<asp:RequiredFieldValidator ControlToValidate="txtCardVerificationNumber" ID="reqValidator_cardVerNumber" runat="server" ErrorMessage="Please enter card verification number." ForeColor="red">&nbsp;*&nbsp;</asp:RequiredFieldValidator></div>
		                <div>
		                    <asp:TextBox ID="txtCardVerificationNumber" runat="server" TextMode="Number" class="form-control"/>
                        </div>
                        <div>
                            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300" />
                        </div>
                    </asp:Panel>
                    
                </div>
                <div style="width:40%;margin-left:4%;float:left;">
                    <div class="sub_title_blue">Review</div>
                    <asp:GridView ID="reviewGrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="tourBookingSeqNo" HeaderText="No" InsertVisible="False" ReadOnly="True" SortExpression="tourBookingSeqNo" />
                            <asp:BoundField DataField="tourTitle" HeaderText="Tour Title" SortExpression="tourTitle" />
                            <asp:BoundField DataField="travelDate" HeaderText="Travel Date" SortExpression="travelDate" />
                            <asp:BoundField DataField="travelerNumber" HeaderText="Traveler Number" SortExpression="travelerNumber" />
                            <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                        </Columns>
                        <EmptyDataTemplate>
                            <center><strong>There is no data to show.</strong></center>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <div style="text-align:right;">Total Price: <asp:Label ID="labelTotalPrice" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hiddenTotalPrice" runat="server" />
                    </div>
                    <div style="padding-top:30px;text-align:center">
                        <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" class="btn btn-primary" style="width:200px;" OnClick="btnCheckOut_Click" />
                    </div>
                </div>
		        <div class="clearfix"></div>
            </div>
                    
        </div>
    </main>

    <script>
        function goBack() {
            window.location.href = "/customers/my_travel.aspx";
        }

        $(document).ready(function () {

             $('input[name="payType"]').click(function () {
                var radioVal = $('input[name="payType"]:checked').val();
                 if (radioVal == "banking") {
                     $("#internetBanking").show();
                     $("#creditCard").hide();
                 }
                 else {
                     $("#internetBanking").hide();
                     $("#creditCard").show();
                 }
            });
        });
    </script>
</asp:Content>
