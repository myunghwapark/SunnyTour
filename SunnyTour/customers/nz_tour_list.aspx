<%@ Page Title="" Language="C#" MasterPageFile="~/Tour.Master" AutoEventWireup="true" CodeBehind="nz_tour_list.aspx.cs" Inherits="SunnyTour.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <asp:ListView ID="listView_Tour" runat="server">
        <ItemTemplate>
            <table style="margin:10px;">
                <tr>
                    <td>
                        <a href="/customers/nz_tour.aspx?tourSeqNo=<%#Eval("tourSeqNo") %>">
		                  <img src="<%#Eval("imageUrl") %>" alt="<%#Eval("tourTitle") %>" style="width:400px;">
		                </a>
                    </td>
                    <td style="padding-left:10px;">
                        <%#Eval("tourTitle") %></br>
                        <%#Eval("tourRegion") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>
	
</asp:Content>
