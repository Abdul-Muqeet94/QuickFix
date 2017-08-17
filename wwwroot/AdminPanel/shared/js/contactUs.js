
(function () {
    var app = angular.module('contactUsModule', ['datatables']);

 app.controller("viewContacts", function ($scope,$route, DTOptionsBuilder,$location, $http, $rootScope, $location,$log) {

$scope.dtOptions = DTOptionsBuilder.newOptions()
            .withDisplayLength(10)
            .withOption('bLengthChange', false);
            $scope.message = $http.post('http://localhost:5000/api/contactus/view', 0).
                then(function (response) {
                    $scope.contacts=response.data;
                    console.log($scope.contacts);

                });

                 $scope.delete=function(val){
                     console.log(val);
             $scope.message = $http.post('http://localhost:5000/api/contactus/delete',val).
                then(function (response) {
                    console.log(response.data);
                    $route.reload();
                });
                
        };

        $scope.update=function(val){
            $rootScope.cmsId=val;
            $location.path("/updatecms");
        };
    });
})();