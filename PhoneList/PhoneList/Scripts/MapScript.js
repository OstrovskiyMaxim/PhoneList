
function initMap(mapId, address) {
   
    var mapPosition;
    var geocoder = geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            mapPosition =  results[0].geometry.location;
            var marker = new google.maps.Marker({
                map: map,
                position:mapPosition,
            });

            var infowindow = new google.maps.InfoWindow({
                content: results[0].formatted_address
            })
        }
    });

    var map = new google.maps.Map(document.getElementById(mapId), {
        center: mapPosition,
        zoom: 12
    });
}

function CreatePersonFieldChange(e) {
    var country = $('#countries').find('option:selected').text();
    var city = $('#cities').find('option:selected').text();
    var street = $('#street').val();
    var houseNo = $('#houseNo').val();
    var adressValues = [country,city,street,houseNo];

    var address = adressValues.join(', ');
    var mapId = "mapCreatePerson";

    $('#mapCreatePerson').removeClass('hidden');
    initMap(mapId, address);
}



