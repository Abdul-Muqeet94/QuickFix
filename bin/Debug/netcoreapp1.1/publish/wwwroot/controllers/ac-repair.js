
(function () {
  var app = angular.module("mainModule", ['ngRoute','ng-weekday-selector']);


app.controller("homeController", function($scope,$http,$rootScope,$location) {

$scope.message = $http.post('http://184.168.146.148:88/api/services/view',0).
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
