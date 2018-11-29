var app = angular.module('Module_HomePage', []);

app.controller('myCtrl', 
function($scope, $http) 
{
  $http.get("/")
  .then(
        function(response) 
        {
            $scope.myWelcome = response.data;
        }
    );
});
