(function () {
    var app = angular.module('taskModule', ['datatables', 'ngMap']);

    app.controller("addTask", function ($scope, $http, $log, $location) {

        $scope.emp = { name: "", email: "", code: "", nationality: "", contactNo: "", emiratesId: "", address: "", typeId: "" }
        $http.post('http://localhost:5000/api/service/view', 0)
            .then(function (response) {
                $scope.services = response.data;
                console.log($scope.services);

            });

        $scope.save = function () {

            console.log($scope.emp);
            $scope.message = $http.post('http://localhost:5000/api/employee/create/', $scope.emp).
                then(function (response) {
                    console.log(response.data);
                    $location.path('/order');
                    // $location.url('billers');

                });
        }
    });


    //View Task

    app.controller("viewTask", function ($scope, DTOptionsBuilder, $http, $rootScope, $location) {

        $scope.tasks = {};
        $scope.taskCount=0;
        // DataTables configurable options
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withDisplayLength(10)
            .withOption('bLengthChange', false);

        $http.post('http://localhost:5000/api/task/toassignview', 0)
            .then(function (response) {
                $scope.tasks = response.data;
                $scope.taskCount=$scope.tasks[0].count;
                console.log($scope.tasks);
            });

        $scope.delete = function (val) {
            //  console.log(index);

            $scope.message = $http.post('http://localhost:5000/api/task/delete', val).
                then(function (response) {
                    $scope.model = response.data;
                    console.log($scope.model);
                    $location.path('/order');
                });
        };
        $scope.checkEmp = function (val) {
            console.log($scope.tasks[val].assigned_employee.length);
            //$scope.tasks[val].selected_features.length
            if ($scope.tasks[val].assigned_employee.length > 0) {

                return false;
            }
            else {
                return true;
            }
        };

        $scope.assign = function (val) {
            //  console.log(index);

            $rootScope.taskId = val;
            $location.path("/orderassign");
        };




    });

    //End here
    app.controller("assignTask", function ($scope, $http, $log, $rootScope, $route, $sce, NgMap, $location) {
        $scope.emailFilter = { employee: 0, email: "", service: 0 };

        $scope.sendingEmail = function (val) {
            return $rootScope.sendEmail = val;
        };
        $scope.completeScope = { id: 0, comments: "" ,amount:""};
        $scope.sendingEmail(false);
        $scope.createTask = { task_id: "", service_employee: [], comments: "" };
        $scope.service_employee = { serviceId: 0, employeeId: 0 };
        $scope.index = 0;
        $scope.selected = [];

        NgMap.getMap().then(function (map) {
            console.log(map.getCenter());
            console.log('markers', map.markers);
            console.log('shapes', map.shapes);
        });


        $http.post('http://localhost:5000/api/task/viewforassign', $rootScope.taskId)
            .then(function (response) {
                $scope.tasksList = response.data;
                $scope.task = $scope.tasksList[0];
                console.log("this is the model to use");
                console.log($scope.task);
                getEmployees($scope.task.shiftId);
            }, function (response){
                console.log(response.statusText);
                if(response.statusText=="Internal Server Error"){
                    alert("You cannot continue forward without adding an employee! please add an employee first")
                    $location.path('/order');
                }
            });
        function getEmployees(val) {
            $http.post('http://localhost:5000/api/shift/getshiftemployees', val)
                .then(function (response) {
                    $scope.employees = response.data;
                    console.log($scope.employees);
                });
        }
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
        $scope.completeStatus = function () {
            if (angular.equals($scope.task.complete, "Completed")) {

                return false;
            }
            else {
                return true;
            }
        }
        $scope.complete = function () {
            $scope.completeScope.id = $scope.task.id;
            $scope.completeScope.comments = $scope.task.comments;
            console.log($scope.completeScope);
            $scope.message = $http.post('http://localhost:5000/api/task/complete', $scope.completeScope).
                then(function (response) {
                    $scope.model = response.data;
                    console.log($scope.model);
                    swal({
                        title: 'Saved',
                        text: 'Task Completed Successfully',
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
                    $location.path('/viewassignorder');
                });
            $route.reload();
        };
        $scope.getImage = function (data) {
            return 'data:image/jpeg;base64,' + data;

        };
        $scope.cancelledOrder = function () {
            $scope.completeScope.id = $scope.task.id;
            $scope.completeScope.comments = $scope.createTask.comments;
            console.log($scope.completeScope);
            $scope.message = $http.post('http://localhost:5000/api/task/cancel', $scope.completeScope).
                then(function (response) {
                    $scope.model = response.data;
                    console.log($scope.model);
                    swal({
                        title: 'Saved',
                        text: 'Task Cancelled Successfully',
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
                    $location.path('/viewassignorder');
                });
            $route.reload();
        };
        $scope.save = function () {
            console.log($scope.index);
            if ($scope.service_employee.serviceId == 0) {
                $scope.service_employee.serviceId = $scope.task.selected_features[0].id;
            }
            $scope.createTask.task_id = $scope.task.id;
            // $scope.createTask.service_employee.push($scope.service_employee);
            $scope.createTask.service_employee = $scope.selected;

            //
            console.log($scope.createTask);

            $scope.message = $http.post('http://localhost:5000/api/task/assignEmployee', $scope.createTask).
                then(function (response) {
                    console.log(response.data);
                    swal({
                        title: 'Saved',
                        text: 'Employee Assign to Task Successfully',
                        timer: 2000
                    }).then(
                        function () { },
                        // handling the promise rejection
                        function (dismiss) {
                            if (dismiss === 'timer') {
                                console.log('.............');

                            }
                        }
                        )
                });
            $scope.getHtml();
            $location.path("/order");
        };
        $scope.viewTask = function (val) {
            $rootScope.taskId = val;
            $location.path('/vieworder');

        };
        $scope.setTipId = function (loc) {
            console.log(loc);
            return $scope.detailFrame = $sce.trustAsResourceUrl("https://maps.googleapis.com/maps/api/staticmap?center=" + loc + "&markers=color:red%7Clabel:C%7C" + loc + "&zoom=16&size=600x400&zoom=12&size=600x400&key=AIzaSyDZsYO93iFNehzrBgw1kn4D7KJHgypxD0A");
        }

        $scope.getHtml = function () {
            $scope.sendingEmail(true);
            //  document.getElementById('dropDown').remove();
            document.getElementById('buttonSave').remove();
            var printContents = document.getElementById('getDiv').innerHTML;
            var pageContent = '<html><head><style> .div1 {width:300px;height:100px;border:1px;} table {border-collapse:collapse;border-spacing:0;} th,td{border:none;text-align:left;padding:8px;} .th_bg{background-color:#f5f5f5;} .first_row tr th{font-size:15px; } .first_row tr{border-top: 1px solid #ddd;padding:15px 8px;} .first_row tr td{padding:12px 8px;color: #878787;font-weight: 300;font-size: 15px;} table {border-collapse: collapse; border-spacing: 0;} th, td {border: none;text-align: left;padding: 8px;} .th_bg {   background-color: #f5f5f5;} .first_row tr th{ font-size:15px; } .first_row tr{border-top: 1px solid #ddd;padding:15px 8px;} .first_row tr td{ padding:12px 8px;color: #878787;font-weight: 300;font-size: 15px;} </style></head><body>' + printContents + '</body></html>';
            console.log(pageContent);
            console.log($scope.service_employee);
            $scope.emailFilter.employee = $scope.selected;
            $scope.emailFilter.service = $scope.task.id;
            $scope.emailFilter.email = pageContent;
            console.log($scope.emailFilter);
            $scope.message = $http.post('http://localhost:5000/api/task/sendemail', $scope.emailFilter).
                then(function (response) {
                    console.log(response.data);
                    $scope.sendingEmail(false);
                });
            //<link href="../shares/css/lib/font-awesome.min.css" rel="stylesheet"> <link href="../shared/css/style.css" rel="stylesheet"> <link href="../assets/css/lib/bootstrap.min.css" rel="stylesheet">
        };



    });


    app.controller("viewAssignTask", function ($scope, DTOptionsBuilder, $route, $http, $rootScope, $location) {

        $scope.tasks = {};
        $scope.completeScope = { id: 0, comments: "" };
        // DataTables configurable options
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withDisplayLength(10)
            .withOption('bLengthChange', false);

        $http.post('http://localhost:5000/api/task/viewassigntask', 0)
            .then(function (response) {
                $scope.tasks = response.data;
                console.log($scope.tasks);
            });

        $scope.delete = function (val) {
            //  console.log(index);

            $scope.message = $http.post('http://localhost:5000/api/task/delete', val).
                then(function (response) {
                    $scope.model = response.data;
                    console.log($scope.model);
                    $location.path('/order');
                });
        };
        $scope.viewTask = function (val) {
            $rootScope.taskId = val;
            $location.path('/vieworder');

        };
        $scope.completeStatus = function (val) {

            if (angular.equals($scope.tasks[val].complete, "Completed")) {

                return false;
            }
            else {
                return true;
            }
        };
        $scope.complete = function (val) {
            $scope.completeScope.id = val;
            console.log($scope.completeScope);
            $scope.message = $http.post('http://localhost:5000/api/task/complete', $scope.completeScope).
                then(function (response) {
                    $scope.model = response.data;
                    console.log($scope.model);
                    $route.reload();
                });
            $route.reload();
        };
        $scope.checkEmp = function (val) {
            console.log($scope.tasks[val].assigned_employee.length);
            //$scope.tasks[val].selected_features.length
            if ($scope.tasks[val].assigned_employee.length > 0) {

                return false;
            }
            else {
                return true;
            }
        };

        $scope.assign = function (val) {
            //  console.log(index);

            $rootScope.taskId = val;
            $location.path("/orderassign");
        };




    });


    app.controller("viewCompletedTask", function ($scope, DTOptionsBuilder, $route, $http, $rootScope, $location) {

        $scope.tasks = {};
        $scope.completeScope = { id: 0, comments: "" };
        // DataTables configurable options
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withDisplayLength(10)
            .withOption('bLengthChange', false);

        $http.post('http://localhost:5000/api/task/viewcompletedtask', 0)
            .then(function (response) {
                $scope.tasks = response.data;
                console.log($scope.tasks);
            });

        $scope.delete = function (val) {
            //  console.log(index);

            $scope.message = $http.post('http://localhost:5000/api/task/delete', val).
                then(function (response) {
                    $scope.model = response.data;
                    console.log($scope.model);
                    $location.path('/order');
                });
        };
        $scope.viewTask = function (val) {
            $rootScope.taskId = val;
            $location.path('/vieworder');

        };


        $scope.checkEmp = function (val) {
            console.log($scope.tasks[val].assigned_employee.length);
            //$scope.tasks[val].selected_features.length
            if ($scope.tasks[val].assigned_employee.length > 0) {

                return false;
            }
            else {
                return true;
            }
        };

        $scope.assign = function (val) {
            //  console.log(index);

            $rootScope.taskId = val;
            $location.path("/orderassign");
        };
    });
    app.controller("viewCancelledTask", function ($scope, DTOptionsBuilder, $route, $http, $rootScope, $location) {

        $scope.tasks = {};
        $scope.completeScope = { id: 0, comments: "" };
        // DataTables configurable options
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withDisplayLength(10)
            .withOption('bLengthChange', false);

        $http.post('http://localhost:5000/api/task/viewcancelledtask', 0)
            .then(function (response) {
                $scope.tasks = response.data;
                console.log($scope.tasks);
            });

        $scope.delete = function (val) {
            //  console.log(index);

            $scope.message = $http.post('http://localhost:5000/api/task/delete/', val).
                then(function (response) {
                    $scope.model = response.data;
                    console.log($scope.model);
                    $location.path('/order');
                });
        };
        $scope.viewTask = function (val) {
            $rootScope.taskId = val;
            $location.path('/vieworder');

        };


        $scope.checkEmp = function (val) {
            console.log($scope.tasks[val].assigned_employee.length);
            //$scope.tasks[val].selected_features.length
            if ($scope.tasks[val].assigned_employee.length > 0) {

                return false;
            }
            else {
                return true;
            }
        };

        $scope.assign = function (val) {
            //  console.log(index);

            $rootScope.taskId = val;
            $location.path("/orderassign");
        };




    });



})();