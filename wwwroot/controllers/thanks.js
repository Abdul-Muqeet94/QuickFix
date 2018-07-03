
(function () {
  var app = angular.module("thanksModule", ['ngRoute']);


app.controller("thanksController", function($scope,close,ModalService,$http,$rootScope,$location) {
$scope.heading=$rootScope.service.name;
 $rootScope.service.features = $rootScope.service.feature;
    delete $rootScope.service.feature;

$rootScope.task.selected_services=[];
$rootScope.task.selected_services.push($rootScope.service);
console.log($rootScope.task);

$scope.close = function(result) {

	 close(result, 500);
   $location.path('/ac-repair');

   $rootScope.task.id=0;
console.log($rootScope.task);

 
$scope.message = $http.post('http://localhost:5000/api/task/create',$scope.task).
    then(function (response){
      console.log(response.data);
    });

 

}

});

////

  
})();
