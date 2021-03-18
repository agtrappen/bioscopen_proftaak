// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function DisplayGoogleMap() {

    //Set the Latitude and Longitude of the Map
    var myAddress = new google.maps.LatLng(51.58425641517101, 4.798083988657903);

    //Create Options or set different Characteristics of Google Map
    var mapOptions = {
        center: myAddress,
        zoom: 15,
        minZoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    //Display the Google map in the div control with the defined Options
    var map = new google.maps.Map(document.getElementById("myDiv"), mapOptions);

    //Set Marker on the Map
    var marker = new google.maps.Marker({
        position: myAddress,
        animation: google.maps.Animation.DROP,
    });

    marker.setMap(map);
}

DisplayGoogleMap();

