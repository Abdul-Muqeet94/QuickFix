
(function () {
  var app = angular.module("mainModule", ['ngRoute','ng-weekday-selector']);


app.controller("homeController", function($scope,$http,$rootScope,$location) {

$scope.message = $http.post('http://assany.com/api/services/view',0).
    then(function (response){
    $scope.services=response.data;
         
             });

$scope.selected= function()
{
    $location.url='';
}


});



////

  
})();
