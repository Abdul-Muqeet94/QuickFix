(function () {
    var app = angular.module('employeeModule', []);



    app.controller("addEmployee", function ($scope, $http, $log,$location) {
        $scope.emp={name:"",email:"",code:"",nationality:"",contactNo:"",emiratesId:"",address:"",typeId:[]}
        $scope.selected = [];
        $scope.selectedShift=[];
         $http.post('http://localhost:5000/api/service/view', 0)
        .then(function (response) {
            $scope.services = response.data;
            console.log($scope.services);
        });
         $http.post('http://localhost:5000/api/shift/view', 0)
        .then(function (response) {
            $scope.shifts = response.data;
            console.log($scope.shifts);
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


      $scope.toggleShift = function (item, selectedShift) {
        var idx = selectedShift.indexOf(item);
        if (idx > -1) {
          selectedShift.splice(idx, 1);
        }
        else {
          selectedShift.push(item);
        }
      };

      $scope.existsShift = function (item, list) {
        return list.indexOf(item) > -1;
      };

                $scope.save = function () {
                 $scope.emp.typeId=$scope.selected;
                 $scope.emp.shifts=$scope.selectedShift;
                 console.log($scope.emp);
            $scope.message = $http.post('http://localhost:5000/api/employee/create', $scope.emp).
            then(function (response) {
              console.log(response.data);
               swal({
                    title: 'Saved',
                    text: 'Employee added Successfully'
                }).then(
                    function () { },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            console.log('.............')
                        }
                    }
                    )
              $location.path("/viewemployee");
               // $location.url('billers');

            });
        }
    });

     app.controller("updateEmployee", function ($scope, $http, $log,$rootScope,$location) {
         if($rootScope.empid==0)
         {
             $location.path("/viewemployee");
         }
            $scope.selected=[];
            $scope.selectedShift=[];
          $http.post('http://localhost:5000/api/service/view', 0)
        .then(function (response) {
            $scope.services = response.data;
            console.log($scope.services);
        });
        $http.post('http://localhost:5000/api/shift/view', 0)
        .then(function (response) {
            $scope.shifts = response.data;
            console.log($scope.shifts);
            
        });
          $http.post('http://localhost:5000/api/employee/view', $rootScope.empid)
        .then(function (response) {
            
            $scope.employeeList = response.data;
            $scope.employee=$scope.employeeList[0];
            $scope.employee.typeId.forEach(function(element) {
                $scope.selected.push(element.id);
            }, this);
            $scope.employee.shift.forEach(function(element) {
                $scope.selectedShift.push(element.id);
            }, this);
            console.log($scope.employee);
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

      $scope.exists = function (item, selected) {
        return selected.indexOf(item) > -1;
      };
        $scope.toggleShift = function (item, selectedShift) {
        var idx = selectedShift.indexOf(item);
        if (idx > -1) {
          selectedShift.splice(idx, 1);
        }
        else {
          selectedShift.push(item);
        }
      };

      $scope.existsShift = function (item, list) {
        return list.indexOf(item) > -1;
      };
        $scope.update=function(){
            $scope.employee.typeId=$scope.selected;
            $scope.employee.shifts=$scope.selectedShift;
            console.log($scope.employee);
            //api/employee/edit
             $http.post('http://localhost:5000/api/employee/edit', $scope.employee)
        .then(function (response) {
            $scope.data = response.data;
            console.log($scope.data);
             swal({
                    title: 'Saved',
                    text: 'Employee Edit Successfully',
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
        }, function myError(response) {
         swal({
                    title: 'Error',
                    text: 'Unable to Edit Employee'
                }).then(
                    function () { },
                    // handling the promise rejection
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            console.log('.............')
                        }
                    }
                    )
    });
                 $location.path("/viewemployee");
        };
     });


})();