(function () {
    var app = angular.module('serviceModule', []);



    app.controller("addService", function ($scope, $http, $log, $location) {
        $scope.service = { id: 0, name: '', description: '', features: [] }
        $scope.options=["AC Service & Repair","CCTV Camera","Electrician","Carpenter",
    "generator","Refrigerator and Dispenser","Plumbing"];
        $scope.selected = [];
        $http.post('http://assany.com/api/feature/view/', 0)
            .then(function (response) {
                $scope.features = response.data;
                console.log($scope.features);
            });
        $scope.toggle = function (item, selected) {
            var idx = selected.indexOf(item);
            if (idx > -1) {
                selected.splice(idx, 1);
            }
            else {
                selected.push(item);
            }
        };

        $scope.exists = function (item, list) {
            return list.indexOf(item) > -1;
        };
        $scope.save = function () {
            $scope.service.features = $scope.selected;
            console.log($scope.service);
            $scope.message = $http.post('http://assany.com/api/service/create/', $scope.service).
                then(function (response) {
                    console.log(response.data);
                    swal({
                        title: 'Saved',
                        text: 'Service Created Successfully',
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
                    $location.path('/viewservice');
                    // $location.url('billers');

                });
        }
    });

    app.controller("updateService", function ($scope, $http, $log, $rootScope, $location) {
        $scope.selected=[];
        $http.post('http://assany.com/api/feature/view/', 0)
            .then(function (response) {
                $scope.features = response.data;
                console.log($scope.features);
            });

        $http.post('http://assany.com/api/service/view/', $rootScope.serviceId)
            .then(function (response) {
                $scope.service = response.data[0];
                console.log($scope.service.feature);
                $scope.service.feature.forEach(function(element) {
                    $scope.selected.push(element.id);
                }, this);
                
                console.log($scope.service);
            });
        $scope.toggle = function (item, selected) {
            var idx = selected.indexOf(item);
            if (idx > -1) {
                selected.splice(idx, 1);
            }
            else {
                selected.push(item);
            }
        };

        $scope.exists = function (item, list) {
            return list.indexOf(item) > -1;
        };
        $scope.update = function () {
            $scope.service.features=$scope.selected;
            console.log($scope.service);
            $http.post('http://assany.com/api/service/edit/', $scope.service)
                .then(function (response) {
                    $scope.result = response.data;
                    console.log($scope.result);
                    swal({
                        title: 'Saved',
                        text: 'Service Edit Successfully',
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
                    $location.path('/viewservice');
                });
        };
    });


})();