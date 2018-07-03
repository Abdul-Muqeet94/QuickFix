(function () {
    var app = angular.module('reportModule', ['datatables', 'ngMap']);

    app.controller("searchReport", function ($scope, $http, $log,$location,$rootScope) {
        $scope.toShow=false;
        $scope.filter = { orderId:0, employeeId: 0, serviceId: 0, featureId: 0,fromDate: "", toDate: ""}
        $http.post('http://184.168.146.148:88/api/service/view/', 0)
            .then(function (response) {
                $scope.services = response.data;
                console.log($scope.services);

            });

            $http.post('http://184.168.146.148:88/api/feature/view/', 0)
            .then(function (response) {
                $scope.features = response.data;
                console.log($scope.features);

            });

            $http.post('http://184.168.146.148:88/api/employee/view/', 0)
            .then(function (response) {
                $scope.employee = response.data;
                console.log($scope.employee);

            });

        $scope.search = function () {

            console.log($scope.filter);
            $scope.toShow=true;
            $scope.message = $http.post('http://184.168.146.148:88/api/report/taskview/', $scope.filter).
                then(function (response) {
                    console.log(response.data);
                    $scope.tasks=response.data;
                    // $location.url('billers');

                });
        };
        $scope.viewTask=function(val){
            $rootScope.taskId=val;
            $location.path('/vieworder');

        };
        
    });

 app.controller("vieworder", function ($scope, $http, $log,$location,$rootScope) {
    $http.post('http://184.168.146.148:88/api/task/viewforassign/', $rootScope.taskId)
            .then(function (response) {
                $scope.tasksList = response.data;
                $scope.task = $scope.tasksList[0];
                console.log($scope.task);
            });
 });
  

})();