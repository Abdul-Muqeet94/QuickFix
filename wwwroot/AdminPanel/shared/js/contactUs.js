
(function () {
    var app = angular.module('contactUsModule', ['datatables']);

 app.controller("viewContacts", function ($scope,$route, DTOptionsBuilder,$location, ModalService,$http, $rootScope, $location,$log) {

$scope.dtOptions = DTOptionsBuilder.newOptions()
            .withDisplayLength(10)
            .withOption('bLengthChange', false);
            $scope.message = $http.post('https://testing.danishtest.ml/api/contactus/view/', 0).
                then(function (response) {
                    $scope.contacts=response.data;
                    console.log($scope.contacts);

                });

                 $scope.delete=function(val){
                     console.log(val);
             $scope.message = $http.post('https://testing.danishtest.ml/api/contactus/delete/',val).
                then(function (response) {
                    console.log(response.data);
                    $route.reload();
                });
                
        };

        $scope.update=function(val){
            $rootScope.cmsId=val;
            $location.path("/updatecms");
        };

        $scope.quote=function(emailToSend)
    {
$rootScope.email=emailToSend;
ModalService.showModal({
    templateUrl:'quote.html',
    controller: "quoteController"
  }).then(function(modal) {

   modal.element.modal();
    modal.close.then(function(result) {
      console.log(result);
    });
  });


    };

    $scope.view=function(val){
        $rootScope.contactView=val;
        $location.path("/contactView");
    };
    });

 app.controller("viewInnerContact", function ($scope,$route, DTOptionsBuilder,$location,$http, $rootScope, $location,$log) {
    
    $scope.message = $http.post('https://testing.danishtest.ml/api/contactus/view/', $rootScope.contactView).
                then(function (response) {
                    $scope.contacts=response.data;
                    $scope.contact=$scope.contacts[0];
                    console.log($scope.contact);

                });
 });
    
})();