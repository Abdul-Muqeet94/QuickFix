(function () {
    var app = angular.module('cmsModule', ['datatables']);



    app.controller("manageCms", function ($scope, $http, $log,$location,$rootScope) {
   $scope.options=["index","AC Service & Repair","CCTV Camera","Marble Tiles & Sanitary","Electrician","House Painters","Electrical Equipments Repairing","Carpenter",
    "Drilling & Hanging","Ceiling","Plumbing","Bathroom Deep Cleaning"];
        $scope.save = function () {

            console.log($scope.cms);
            $scope.message = $http.post('http://184.168.146.148:88/api/cms/create/', $scope.cms).
                then(function (response) {
                    console.log(response.data);

                });
        };
        
        
    });

    app.controller("viewcms", function ($scope, DTOptionsBuilder, $http, $rootScope, $location,$log) {

$scope.dtOptions = DTOptionsBuilder.newOptions()
            .withDisplayLength(10)
            .withOption('bLengthChange', false);
            $scope.message = $http.post('http://184.168.146.148:88/api/cms/view/', 0).
                then(function (response) {
                    $scope.cmss=response.data;
                    console.log(response.cmss);

                });

                 $scope.delete=function(val){
             $scope.message = $http.post('http://184.168.146.148:88/api/cms/delete/',val).
                then(function (response) {
                    console.log(response.data);

                });
                
        };

        $scope.update=function(val){
            $rootScope.cmsId=val;
            $location.path("/updatecms");
        };
    });

       app.controller("updateCms", function ($scope, $http, $log,$location,$rootScope) {

         $scope.message = $http.post('http://184.168.146.148:88/api/cms/view/',$rootScope.cmsId).
                then(function (response) {
                    $scope.cms=response.data[0];
                    console.log($scope.cms);

                });


                $scope.update=function(){
                    $scope.message = $http.post('http://184.168.146.148:88/api/cms/edit',$scope.cms).
                then(function (response) {
                    $scope.result=response.data;
                    console.log($scope.result);

                }); 
                };
       });


})();