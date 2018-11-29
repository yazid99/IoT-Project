var app = angular.module('Module_HomePage', []);
app.controller("Controller_Devices", 
function($scope, $http)
{
    $http({
        method: 'GET',
        url: "http://103.236.201.99/Device/GetDevices",
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem("key")
             //or
             //'Authorization': 'Basic ' + 'token'
        },
        //data: someData
        })
    .then(
        function successCallback(response) 
        {
            $scope.result = response.data;
            $scope.result.forEach(element => {
                element.DeviceState = JSON.parse(element.DeviceState);
                //console.log(element.DeviceState);
            });
        }
    ,   function errorCallback(response) 
        {
            alert("oh no");
        }
    );
});
