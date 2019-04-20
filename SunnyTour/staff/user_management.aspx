<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="user_management.aspx.cs" Inherits="SunnyTour.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <center>
	        <div class="content_div">
	            <div class="title" style="text-align:center;">User Management</div>
                <div style="padding:20px 0 40px 0;">

                    <div class="input-group mb-3" style="width:15%;margin-right:30px;margin-bottom:0 !important;float:left;">
                      <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">User Type</label>
                      </div>
                      <select class="custom-select custom-select-sm" style="font-size:1rem;height:auto;" id="userType">
                        <option value="all" selected>All</option>
                        <option value="G002_001">Customer</option>
                        <option value="G002_002">Staff</option>
                       </select>
                    </div>

                    <div class="btn-group btn-group-toggle" data-toggle="buttons" style="text-align:left;float:left;">
                      <label class="btn btn-secondary active">
                        <input type="radio" name="btnUserReport" value="allUsers" id="allUsers" autocomplete="off" checked> All Users
                      </label>
                      <label class="btn btn-secondary">
                        <input type="radio" name="btnUserReport" value="topPurchased" id="topPurchased" autocomplete="off"> 10 most purchased customers in a month
                      </label>
                      <label class="btn btn-secondary">
                        <input type="radio" name="btnUserReport" value="topBooked" id="topBooked" autocomplete="off"> 10 most booked customers in a month
                      </label>
                    </div>

                    <div style="text-align:right;float:right;">
                        <asp:Button ID="btnRegisterUser" runat="server" Text="Register User" Class="btn btn-primary" OnClick="btnRegisterUser_Click"></asp:Button>
                    </div>
                    
                </div>
		        <div class="clearfix"></div>

                <asp:GridView ID="GridView_Tour" runat="server" AutoGenerateColumns="False" DataKeyNames="userSeqNo" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="userSeqNo" HeaderText="Sequence No" SortExpression="userSeqNo"></asp:BoundField>
                        <asp:BoundField DataField="userId" HeaderText="User ID" SortExpression="userId"></asp:BoundField>
                        <asp:BoundField DataField="firstName" HeaderText="First Name" SortExpression="firstName"></asp:BoundField>
                        <asp:BoundField DataField="lastName" HeaderText="Last Name" SortExpression="lastName"></asp:BoundField>
                        <asp:BoundField DataField="phoneNumber" HeaderText="phoneNumber" SortExpression="phoneNumber"></asp:BoundField>
                        <asp:BoundField DataField="userType" HeaderText="User Type" SortExpression="userType"></asp:BoundField>
                        <asp:BoundField DataField="createDate" HeaderText="Create Date" SortExpression="createDate"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input type="button" value="Detail" Class="btn btn-info" onclick="goDetailPage('<%#Eval("userId") %>')" />
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


            if ('<%=Request.QueryString["userType"]%>' != null && '<%=Request.QueryString["userType"]%>' != "") {
                $("#userType").val('<%=Request.QueryString["userType"]%>');
            }
            else {
                $("#userType").val("all");
            }
            
            if ('<%=Request.QueryString["searchType"]%>' != null && '<%=Request.QueryString["searchType"]%>' != "") {
                
                $("#<%=Request.QueryString["searchType"]%>")
                    .prop('checked', true)
                    .parents()
                    .addClass('active')
                    .siblings()
                    .removeClass('active');  
                
            }
            
            
            $("input[type=radio][name=btnUserReport]").change(function() {
                var url = getSearchText();
                window.location.href = url+"&searchType="+this.value;
            });

            $("#userType").on("change", function () {
                var url = getSearchText();
                window.location.href = url+"&searchType=all";
            });
        });

    function getSearchText() {
        var searchText = "/staff/user_management.aspx?";
        var userType = $("#userType option:selected").val();
        if (userType != null && userType != "" && userType != "all") {
            searchText += "userType=" + userType;
        }
        return searchText;
    }
        
    function goDetailPage(userId) {
        window.location.href = "/staff/user_detail.aspx?userId="+userId;
    }
    </script>
</asp:Content>
