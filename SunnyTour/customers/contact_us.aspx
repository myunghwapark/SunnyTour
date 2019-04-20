<%@ Page Title="" Language="C#" MasterPageFile="~/Sunny.Master" AutoEventWireup="true" CodeBehind="contact_us.aspx.cs" Inherits="SunnyTour.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cd-main-content">
	    <div class="title">Contact Us</div>
	    <div class="subTitle">Get in touch with us today. We'd love to hear from you.</div>
        <div class="contact_box">
            <div class="in">
                <div class="left">
                    <!--<img src="/images/contact_us.jpg" />-->
                    <div id="googleMap" style="width:500px;height:400px;"></div>
                </div>
                <div class="left right_box">
                    Phone: +64 021-0889-6807<br />
                    <a href = "mailto: cgh11134567@gmail.com">Email: cgh11134567@gmail.com</a>
                </div>
            </div>
        </div>
    </main>
<script>
    function myMap() {
        var location = new google.maps.LatLng('-36.846123', '174.770291');
        var mapProp= {
          center:location,
          zoom:18,
        };
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

        
        var marker;
        marker = new google.maps.Marker({
               position: location, // location of marker
               map: map,
               info: 'Sunny Tour',
               title: 'Sunny Tour' // Popup title when a mouse pointer is placed on a marker.
        });
         
        var content = "Sunny Tour"; // Popup content
         
        // When marker click, the popup will be shown.
        var infowindow = new google.maps.InfoWindow({ content: content});
 
        google.maps.event.addListener(marker, "click", function() {
            infowindow.open(map,marker);
        });
         
      
      google.maps.event.addDomListener(window, 'load', initialize);
    }
</script>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6B_YXpDRGfMFeiLoQRLhHZf-urH9QlqU&callback=myMap"></script>
</asp:Content>
