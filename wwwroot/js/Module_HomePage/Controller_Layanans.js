app.controller("Controller_Layanans", function ($scope, $http) 
{
    $scope.results = [];
    $scope.thumbs = [];
    $scope.current = 0;
    $http.get("Product/GetLayanans")
    .then(
        function(response) 
        {
            $scope.results = response.data;
            for (let index = 0; index < response.data.length; index++) 
                $scope.thumbs.push($scope.results[index]);
            console.log($scope.thumbs);
        }
    );
});
