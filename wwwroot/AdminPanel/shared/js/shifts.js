
var app = angular.module("shiftModule", []);
app.controller("cshiftController", function ($scope, $http, $rootScope,$location) {

    $scope.days = [{ id: 1, name: 'Monday' }, { id: 2, name: 'Tuesday' }, { id: 3, name: 'Wednesday' }, { id: 4, name: 'Thursday' },
    { id: 5, name: 'Friday' }, { id: 6, name: 'Saturday' }, { id: 7, name: 'Sunday' }];
    $scope.selected = [];

    $scope.toggle = function (item, selected) {
        var idx = selected.indexOf(item);
        if (idx > -1) {
            selected.splice(idx, 1);
        }
        else {
            selected.push(item);
        }
    };

    $scope.exists = function (item, selected) {
        return selected.indexOf(item) > -1;
    };
    //End here

    $scope.addShift = function () {
        $scope.shift.sTime = document.getElementById('stime').value;
        $scope.shift.eTime = document.getElementById('etime').value;
        $scope.shift.days = $scope.selected;

        console.log($scope.shift);
        $scope.message = $http.post('http://localhost:5000/api/shift/create/', $scope.shift).
            then(function (response) {
                console.log(response.data);
                 swal({
                    title: 'Saved',
                    text: 'Shift Created Successfully',
                    timer: 2000
                }).then(
                    function () { 
                         $location.path("/viewshift");
                    },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            console.log('.............');
                              $location.path("/viewshift");
                        }
                    }
                    )
               
            });
    }

});
app.controller("vshiftController", function ($scope, $http,$route, $rootScope, $location) {

    $scope.message = $http.post('http://localhost:5000/api/shift/view/', 0).
        then(function (response) {
            $scope.shifts = response.data;
            $rootScope.shifts = response.data;
            console.log($rootScope.shifts);
            
        });
    $scope.delete = function (id) {
        $scope.message = $http.post('http://localhost:5000/api/shift/delete/', id).
            then(function (response) {
                $route.reload();
                var row = document.getElementById(id);
                row.parentNode.removeChild(row);

            });
    }

    $scope.update = function (id) {
        for (var i = 0; i < $rootScope.shifts.length; i++) {
            if ($rootScope.shifts[i].id == id) {
                $rootScope.shift = $rootScope.shifts[i];
                $location.path("/updateShift");
                return;
            }
        }
        // $scope.message = $http.post('http://localhost:5000/api/shift/view',id).
        //       then(function (response){
        //           $rootScope.shift=response.data[0];
        //          console.log($rootScope.shift);
    }
});


app.controller("updateShiftController", function ($scope, $http, $rootScope, $location) {
    $scope.selected = [];
    $scope.days = [{ id: 1, name: 'Monday' }, { id: 2, name: 'Tuesday' }, { id: 3, name: 'Wednesday' }, { id: 4, name: 'Thursday' },
    { id: 5, name: 'Friday' }, { id: 6, name: 'Saturday' }
        , { id: 7, name: 'Sunday' }
    ];
    $scope.shifts = $rootScope.shift;
    console.log($scope.shifts);
    $scope.shifts.day.forEach(function (element) {
        if (element == "Monday") {
            $scope.selected.push(1);
        }
        if (element == "Tuesday") {
            $scope.selected.push(2);
        }
        if (element == "Wednesday") {
            $scope.selected.push(3);
        }
        if (element == "Thursday") {
            $scope.selected.push(4);
        }
        if (element == "Friday") {
            $scope.selected.push(5);
        }
        if (element == "Saturday") {
            $scope.selected.push(6);
        }
        if (element == "Sunday") {
            $scope.selected.push(7);
        }

    }, this);


    $scope.toggle = function (item, selected) {
        var idx = selected.indexOf(item);
        if (idx > -1) {
            selected.splice(idx, 1);
        }
        else {
            selected.push(item);
        }
    };

    $scope.exists = function (item, selected) {
        return selected.indexOf(item) > -1;
    };
    $scope.updateShift = function () {
        $scope.shifts.days = $scope.selected;
        console.log($scope.shifts);
        $scope.message = $http.post('http://localhost:5000/api/shift/edit/', $scope.shifts).
            then(function (response) {
                console.log(response.data);
                swal({
                    title: 'Saved',
                    text: 'Shift Edit SuccessFully',
                    timer: 2000
                }).then(
                    function () { 
                         $location.path("/viewshift");
                    },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            console.log('.............');
                              $location.path("/viewshift");
                        }
                    }
                    )
               
            });
    };

});