(function () {
    var app = angular.module('featureModule',[]);



    app.controller("addFeature", function ($scope, $http, $log,$location) {
        
                $scope.save = function () {
            
            console.log($scope.feature);
            $scope.message = $http.post('http://assany.com/api/feature/create/', $scope.feature).
            then(function (response) {
              console.log(response.data);
              swal({
                    title: 'Saved',
                    text: 'Feature Added Successfully',
                    timer: 2000
                }).then(
                    function () { },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            console.log('.............')
                        }
                    }
                    )
              $location.path('/viewfeatures');
               // $location.url('billers');

            });
        }
    });
 app.controller("updateFeature", function ($scope, $http, $log,$rootScope,$location) {

     $scope.message = $http.post('http://assany.com/api/feature/view/', $rootScope.featureId).
            then(function (response) {
                $scope.feature=response.data[0];
                console.log($scope.feature);
                // 
            });
            $scope.update=function(){
                 $scope.message = $http.post('http://assany.com/api/feature/edit/', $scope.feature).
            then(function (response) {
                $scope.feature=response.data;
                console.log($scope.feature);
                swal({
                    title: 'Saved',
                    text: 'Feature Edit Successfully',
                    timer: 2000
                }).then(
                    function () { },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            console.log('.............')
                        }
                    }
                    )
                $location.path('/viewfeatures');
                // 
            });
            };
    
 });

})();