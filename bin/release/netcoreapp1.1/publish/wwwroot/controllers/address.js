
(function () {
  var app = angular.module("addressModule", ['ngRoute']);

//


//
app.controller("addressController", function($scope,$http,$rootScope,$location,close,ModalService) {
$scope.heading=$rootScope.service.name;
$rootScope.task.callUpCharges=200;
$rootScope.task.paymentStatus=0;

$scope.loadmap=function()
{
  document.getElementById("content").innerHTML='<object type="text/html" data="views/myplace.html" ></object>';
}

$scope.close = function(result) {
  // $scope.task.location=document.getElementById("lat").value+","+document.getElementById("lng").value;
 	console.log($scope.model.googleAddress);

   close(result, 500);


}
//
   

//

});

////

  
})();
