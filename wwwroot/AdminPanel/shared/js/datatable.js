var app = angular.module('datatableModule', ['datatables']);


//Employee View

app.controller("datatableController", function ($scope,$route, DTOptionsBuilder, $http, $rootScope,$location) {
    $scope.users = {};
    // DataTables configurable options
    $scope.dtOptions = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);

    $http.post('http://localhost:5000/api/employee/view', 0)
        .then(function (response) {
            $scope.users = response.data;
            console.log($scope.users);
        });

    $scope.delete = function (val) {
        //  console.log(index);

        $scope.message = $http.post('http://localhost:5000/api/employee/delete', val).
            then(function (response) {
                $scope.model = response.data;
                console.log($scope.model);
                swal({
                    title: 'Saved',
                    text: 'Employee Deleted Successfully',
                    timer: 2000
                }).then(
                    function () { },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            $route.reload();
                        }
                    }
                    )
                    
                $location.path('/viewemployee').replace();
            });
            $route.reload();
    };


    $scope.update = function (data) {
       
       $rootScope.empid=data;
       $location.path("/updateEmployee");

    };



});

//End Here

//Feature View 
app.controller("featureController", function ($scope, DTOptionsBuilder, $http,  $route,$rootScope,$location) {
    $scope.features = {};
    // DataTables configurable options
    $scope.dtOptions = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);

    $http.post('http://localhost:5000/api/feature/view', 0)
        .then(function (response) {
            $scope.features = response.data;
            console.log($scope.features);
        });

    $scope.delete = function (val) {
        //  console.log(index);

        $scope.message = $http.post('http://localhost:5000/api/feature/delete', val).
            then(function (response) {
                $scope.model = response.data;
                console.log($scope.model);
                 swal({
                    title: 'Saved',
                    text: 'Feature Deleted Successfully',
                    timer: 2000
                }).then(
                    function () { },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                           $route.reload();
                        }
                    }
                    )
                $location.path('/viewFeatures');
            });
             $route.reload();
    };
      $scope.update = function (data) {
       
       $rootScope.featureId=data;
       $location.path('/updateFeature');

    };



});

//End Here


//service View


app.controller("serviceController", function ($scope, DTOptionsBuilder, $route, $http, $rootScope,$location) {
    $scope.services = {};
    // DataTables configurable options
    $scope.dtOptions = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);

    $http.post('http://localhost:5000/api/service/view', 0)
        .then(function (response) {
            $scope.services = response.data;
            console.log($scope.services);
        });

    $scope.delete = function (val) {
        //  console.log(index);

        $scope.message = $http.post('http://localhost:5000/api/service/delete', val).
            then(function (response) {
                $scope.model = response.data;
                console.log($scope.model);
                 swal({
                    title: 'Saved',
                    text: 'Service Deleted Successfully',
                    timer: 2000
                }).then(
                    function () { },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            $route.reload();
                        }
                    }
                    )
              
            });
             $route.reload();
    };




    $scope.update = function (data) {
        $rootScope.serviceId = data;
        $location.path('/updateService');
    };
});


//end Here

