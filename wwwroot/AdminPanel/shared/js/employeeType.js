(function () {
    var app = angular.module('employeeTypeModule', ['datatables']);



    app.controller("addEmployeeType", function ($scope, $http, $log) {
        
        $scope.emp={name:""};
                $scope.save = function () {
            
            console.log($scope.emp);
            $scope.message = $http.post('http://localhost:5000/api/employeetype/create', $scope.emp).
            then(function (response) {
              console.log(response.data);
              
               // $location.url('billers');

            });
        }
    });

    app.controller("ViewEmployeeType", function ($scope, DTOptionsBuilder, $http, $rootScope) {
    $scope.users = {};
    // DataTables configurable options
    $scope.dtOptions = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);

    $http.post('http://localhost:5000/api/employeetype/view', 0)
        .then(function (response) {
            $scope.users = response.data;
            console.log($scope.users);
        });

    $scope.delete = function (val) {
        //  console.log(index);

        $scope.message = $http.post('http://localhost:5000/api/employeetype/delete', val).
            then(function (response) {
                $scope.model = response.data;
                console.log($scope.model);
               // window.location.href = "table-data.html";
            });
    };




    $scope.update = function (data) {
        $scope.message = $http.post('http://localhost:5000/api/employee/view', data).
            then(function (response) {
                $scope.userEdit = response.data;
                $rootScope.emp = $scope.userEdit[0].id;
                alert($rootScope.emp);

            });
        window.location.href = "updateEmployee.html";

    };



});


})();