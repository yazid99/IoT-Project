var app = angular.module('Module_Products', ["infinite-scroll"]);
app.controller("Controller_Layanans", 
function($scope, $http) 
{
    $scope.results = [];
    $scope.thumbs = [];
    $scope.current = 0;
    $http.get("GetLayanans")
    .then(
        function(response) 
        {
            $scope.results = response.data;
            for (let index = 0; index < response.data.length; index++) 
                $scope.thumbs.push($scope.results[index]);
            console.log($scope.thumbs);
        }
    );
    $scope.selectThumb = function(index)
    {
        $scope.current = index;
    }
    $scope.loadMore = function()
    {
        var
            last = $scope.thumbs[3];

        /*for (let index = 1; index < 4; index++) 
        {
            if(index>$scope.results.length) return;
            $scope.thumbs.push($scope.last[3+index]);    
        }*/
    }
});
