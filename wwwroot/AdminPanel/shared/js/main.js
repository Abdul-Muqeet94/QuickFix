
(function () {
    var app = angular.module("mainModule", ['ngRoute','angularjs-datetime-picker','contactUsModule','reportModule','cmsModule', 'taskModule', 'featureModule', 'datatableModule','shiftModule', 'serviceModule', 'ng-weekday-selector', 'employeeModule']);

    app.run(function ($rootScope) {
        $rootScope.taskId = 0;
        $rootScope.shift = {};
        $rootScope.empid = 0;
        $rootScope.featureId = 0;
        $rootScope.serviceId = 0;
        $rootScope.sendEmail = false;
        $rootScope.cmsId=0;
    });

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/shift", {
                controller: "cshiftController",
                templateUrl: "../views/cshift.html"
            })
            .when("/viewshift", {
                controller: "vshiftController",
                templateUrl: "../views/vshift.html"
            }).when("/updateShift", {
                controller: "updateShiftController",
                templateUrl: "../views/updateShift.html"
            })
            ///updateShift
            .when("/addemployee", {
                controller: "addEmployee",
                templateUrl: "../views/addemployee.html"
            })

            .when("/viewemployee", {
                controller: "datatableController",
                templateUrl: "../views/viewemployee.html"
            })
            .when("/updateEmployee", {
                controller: "updateEmployee",
                templateUrl: "../views/updateEmployee.html"
            })

            .when("/addservice", {
                controller: "addService",
                templateUrl: "../views/addServices.html"
            })

            .when("/viewservice", {
                controller: "serviceController",
                templateUrl: "../views/viewServices.html"
            })
            .when("/addfeatures", {
                controller: "addFeature",
                templateUrl: "../views/createFeatures.html"
            })
            .when("/viewfeatures", {
                //featureController
                controller: "featureController",
                templateUrl: "../views/ViewFeatures.html"
            })
            .when("/order", {
                //viewTask
                controller: "viewTask",
                templateUrl: "../views/orders.html"
            })
            .when("/updateFeature", {
                controller: "updateFeature",
                templateUrl: "../views/updateFeatures.html"
            })
            .when("/orderassign", {
                controller: "assignTask",
                templateUrl: "../views/ordersassign.html"
            }).when("/completedorder", {
                controller: "viewCompletedTask",
                templateUrl: "../views/viewCompletedOrder.html"
            })
            .when("/updateService", {
                controller: "updateService",
                templateUrl: "../views/updateService.html"
            }).when("/taskService", {
                controller: "updateService",
                templateUrl: "../views/updateService.html"
            }).when("/manager", {
                controller: "manageCms",
                templateUrl: "../views/manage.html"
            }).when("/viewcms", {
                controller: "viewcms",
                templateUrl: "../views/viewcms.html"
            })
            .when("/viewassignorder", {
                controller: "viewAssignTask",
                templateUrl: "../views/viewassignorders.html"
            }).when("/report", {
                controller: "searchReport",
                templateUrl: "../views/Reports.html"
            }).when("/vieworder", {
                controller: "vieworder",
                templateUrl: "../views/vieworder.html"
            }).when("/updatecms", {
                controller: "updateCms",
                templateUrl: "../views/updatecms.html"
            }).when("/contact", {
                //viewTask
                controller: "viewContacts",
                templateUrl: "../views/contactUsView.html"
            }).when("/cancelledorder", {
                //viewTask
                controller: "viewCancelledTask",
                templateUrl: "../views/viewCancelledOrder.html"
            })

///cancelledorder
            //report  vieworder
//viewcms
            //manager
        //updateService
    });













  

    ////


})();
