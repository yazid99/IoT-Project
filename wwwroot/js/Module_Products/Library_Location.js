var map, directionsManager, searchManager, address;

document.getElementById("lib_location_konfirmasi").disabled = true; 

function GetMap()
{
    map = new Microsoft.Maps.Map('#lib_location_myMap', {
    credentials: "AmzjLunYzGapuS-9NbzWNIV9kOWcad25A5ugctgmsi2pdbiMRjLxT50uy7vVhkCc"
});

    //Load the directions module.
    Microsoft.Maps.loadModule('Microsoft.Maps.Directions', function () {
        //Create an instance of the directions manager.
        directionsManager = new Microsoft.Maps.Directions.DirectionsManager(map);

        //Specify where to display the route instructions.
        directionsManager.setRenderOptions({ itineraryContainer: '#directionsItinerary' });

        //Specify the where to display the input panel
        directionsManager.showInputPanel('directionsPanel');
    });

//Create an instance of the search manager and call the reverseGeocode function again.
        Microsoft.Maps.loadModule('Microsoft.Maps.Search', function () {
            searchManager = new Microsoft.Maps.Search.SearchManager(map);
            //reverseGeocode();
        });

navigator.geolocation.getCurrentPosition(function (position) {
        var loc = new Microsoft.Maps.Location(
            position.coords.latitude,
            position.coords.longitude);

        //Add a pushpin at the user's location.
        var pin = new Microsoft.Maps.Pushpin(loc);
        map.entities.push(pin);

        //Center the map on the user's location.
        map.setView({ center: loc, zoom: 15 });
    });

}

function reverseGeocode() {
    //If search manager is not defined, load the search module.
    if (!searchManager) {
        alert("not loadefd");
    } 
    else
    {
        document.getElementById("lib_location_address").innerText = "Mohon tunggu...";
        document.getElementById("lib_location_cek_alamat").disabled = true; 
        var searchRequest = {
            location: map.getCenter(),
            callback: function (r) {
                //Tell the user the name of the result.
                if(confirm( "Apakah alamat anda disini: " + r.name + "?"))
                 {
                    address = r.name;
                    document.getElementById("lib_location_address").innerText = "Alamat anda: " + address;
                    document.getElementById("lib_location_konfirmasi").disabled = false; 
                 }   
                 else
                {
                    document.getElementById("lib_location_address").innerText = "Klik cek alamat kembali";
                }
                document.getElementById("lib_location_cek_alamat").disabled = false; 
            },
            errorCallback: function (e) {
                //If there is an error, alert the user about it.
                alert("Gagal menetukan lokasi alamat anda. Pastikan lokasi aktif");
                document.getElementById("lib_location_cek_alamat").disabled = false; 
            }
        };
        //Make the reverse geocode request.
        searchManager.reverseGeocode(searchRequest);

    }
}

function GetDirections() {
    //Clear any previously calculated directions.
    directionsManager.clearAll();
    directionsManager.clearDisplay();

    //Create waypoints to route between.
    var start = new Microsoft.Maps.Directions.Waypoint({ address: address});
    directionsManager.addWaypoint(start);

    var end = new Microsoft.Maps.Directions.Waypoint({ address: document.getElementById('toTbx').value });
    directionsManager.addWaypoint(end);

    //Calculate directions.
    directionsManager.calculateDirections();
}