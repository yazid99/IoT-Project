angular.module('Module_LoginPage', [])
.controller('Controller_Login', 
['$scope', 
	function($scope, $http) 
	{
		$scope.submitted = true;
		$scope.LogMeIn = function() 
		{
			var
				token = "";
			function Login()
			{
				var xhttp = new XMLHttpRequest();
				xhttp.open("POST", "http://103.236.201.99/Token/Create", false);
				xhttp.setRequestHeader("Content-type", "application/json");
				xhttp.send(`{ "Email" : "${$scope.Email}", "Password":  "${$scope.Password}"}`);
				window.location.href = "103.236.201.99/";
				localStorage.setItem("key", xhttp.responseText);
				if (xhttp.readyState == 4 && xhttp.status == 200) 
				{
					//alert("OK"+xhttp.responseText);
					localStorage.setItem("key", xhttp.responseText);
					token = xhttp.responseText;
					console.log(xhttp.responseText);
					alert("OK");

				}
			}
			Login();
			
//			alert("OK2");
			
		};
}]);

function wait(ms){
	var start = new Date().getTime();
	var end = start;
	while(end < start + ms) {
		end = new Date().getTime();
 }
}