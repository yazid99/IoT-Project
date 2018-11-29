var app = angular.module('Module_Products', ["infinite-scroll"]);

app.controller("Controller_Items", 
function($scope, $http) 
{
    $scope.results = [];
    $scope.thumbs = [];
    $http.get("GetBarangs")
    .then(
        function(response) 
        {
            $scope.results = response.data;
            for (let index = 0; index < 4; index++) 
                $scope.thumbs.push($scope.results[index]);
            console.log($scope.thumbs);
        }
    );
    $scope.loadMore = function()
    {
        var
            last = $scope.thumbs[3];

        for (let index = 1; index < 4; index++) 
        {
            if(index>$scope.results.length) return;
            $scope.thumbs.push($scope.results[3+index]);    
        }
    }
});
