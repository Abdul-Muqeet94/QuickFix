
(function () {
  var app = angular.module("formModule", ['ngRoute']);


app.controller("formController", function($scope,$http,$rootScope,$location,ModalService) {
  
  
 $scope.message = $http.post('http://184.168.146.148:88/api/cms/viewbypage','"' + $rootScope.pageName + '"').
            then(function (response) {
                $scope.cms = response.data;
                console.log($scope.cms);
            });

$scope.BookNow= function()
{
  ModalService.showModal({
    templateUrl:'modal.html',
    controller: "featureController"
  }).then(function(modal) {

     modal.element.modal();
    modal.close.then(function(result) {
      console.log(result);
    });
  });

}

  $scope.bookByRef1=function(ind)
        {         
  $scope.message = $http.post('http://184.168.146.148:88/api/service/view', ind).
            then(function (response) {
               $rootScope.service=  response.data[0];
                $rootScope.pageName=response.data[0].name;
                $rootScope.permService=ind;
                $scope.BookNow();   
         });
   
        }



$scope.request=function()
{
  $scope.problem.service=$rootScope.savedService;
  
  console.log($scope.problem);

  
 $scope.message = $http.post('http://184.168.146.148:88/api/contactus/create/',$scope.problem).
            then(function (response) {
                console.log(response.data);
                $scope.problem.name="";
                $scope.problem.email="";
                $scope.problem.address="";
                $scope.problem.phone="";
                $scope.problem.comments="";
            }); 
}



 });




////

  
})();
