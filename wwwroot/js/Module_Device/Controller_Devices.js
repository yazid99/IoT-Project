var app = angular.module('Module_Device', []);


app.filter("LastUpdate", 
function(){
    return function(date){
        var
            date1 = new Date(date),
            date2 = new Date(),
            deltaT = 0;
        date2 = (date2.getTime() + date2.getTimezoneOffset*60*1000); 
        deltaT = Math.abs(date1 - date2);
        if( deltaT < 600000 )
            return "Device masih Online, terkahir diupdate " + date1 + " " + date2 ;
        return "Device kemungkinan offline, terkahir diupdate " + date1 + " " + date2 ;
    }
 });

app.controller("Controller_Devices", 
function($scope, $http, $interval)
{
    $scope.SelectedList = null;
    $scope.pick = function(keyword)
    {
        var 
            i =0;
        $scope.modeList.forEach(element => 
        {
            console.log(element.value);
            if(element.value==keyword) return element;
        });
    }
    $scope.modeList = [
    {
        value: "WEATHER",
        label: "Weather"
    }, 
    {
        value: "SCHEDULED",
        label: "Schedule"
    }]; 

    
    $scope.Capitalise = function (input)
    {
        var
            firstChar = input[0];
            out = input.toLowerCase();
        out = out.substring(1);
        out = firstChar+out;
        return out;
    };
    $scope.showSelectValue = function(SelectedList)
    {
        $scope.SelectedList;
    };

    $scope.Siram = function(id)
    {
        
        
        $http({
            method: "PUT",
            url: "/Device/SendSiramCommand/"+id,
            headers:
            {
                "Authorization": "Bearer " + localStorage.getItem("key")
            },
            })
            .then(
            function successCallback(response) 
            {
                alert("Alat akan menyiram dalam 5 menit dari sekarang");
                LoadData();
                $scope.$apply();
            }, 
            function errorCallback(response) 
            {
                alert("Gagal dalam mengakses API");
                LoadData();
                $scope.$apply();
            });
    };

    $scope.Update = function (id) {

        if (!confirm("Akan melakukan update firmware! Lanjut?")) return;
        $http({
            method: "PUT",
            url: "/Device/SendUpdateCommand/" + id,
            headers:
            {
                "Authorization": "Bearer " + localStorage.getItem("key")
            },
        })
            .then(
                function successCallback(response) {
                    alert("Alat akan update dalam 5 menit dari sekarang");
                    LoadData();
                    $scope.$apply();
                },
                function errorCallback(response) {
                    alert("Gagal dalam mengakses API");
                    LoadData();
                    $scope.$apply();
            });


    };

    $scope.Reboot = function(o)
    {
        alert(o);
    };

    function LoadData()
    {
        $http({
            method: 'GET',
            url: "Device/GetDevices",
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
    }
    LoadData();
    setInterval(
        function()
        {
            LoadData(); 
            $scope.$apply();
        }, 1000*60*1);
    
});
