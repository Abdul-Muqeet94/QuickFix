(function () {
  var app = angular.module("mainModule", ['ui.router','ngRoute','thanksModule','ngAnimate','ngMap','calendarModule','mp.datePicker','homeModule','formModule','featureModule','angularModalService','angucomplete-alt','addressModule']);
//
//
 app.run(function($rootScope) {

    $rootScope.features = [];
    $rootScope.pageName="";
    $rootScope.task={location:""};
    
});

// ,,$routeProvider
app.config(['$urlRouterProvider','$stateProvider' ,function($urlRouterProvider,$stateProvider) {
    $urlRouterProvider.otherwise('/');


    $stateProvider
    .state('home',{
        url:'/',
        templateUrl:'views/main-child.html',
        controller:'homeController'
    })
    .state('ac-repair',{
        url:'/ac-repair',
        templateUrl:'views/services-ac.html',
        controller:'formController'
    })
    .state('cctv-camera',{
        url:'/cctv-camera',
        templateUrl:'views/services-cctv.html',
        controller:'formController'
    })
    .state('electrician',{
        url:'/electrician',
        templateUrl:'views/services-electrician.html',
        controller:'formController'
    })
    .state('Electrical Equipments',{
        url:'/Electrical Equipments',
        templateUrl:'views/services-aluminum-glass-work.html',
        controller:'formController'
    })
    .state('carpanter',{
        url:'/carpenter',
        templateUrl:'views/services-carpenter.html',
        controller:'formController'
    }).state('Plumbing',{
        url:'/plumbing',
        templateUrl:'views/services-plumbing.html',
        controller:'formController'
    }).state('generator',{
        url:'/generator',
        templateUrl:'views/services-drilling-hanging.html',
        controller:'formController'
    }).state('Refrigerator and Dispenser',{
        url:'/Refrigerator and Dispenser',
        templateUrl:'views/services-ceiling.html',
        controller:'formController'
    }).state('about-us',{
        url:'/about-us',
        templateUrl:'views/about-us.html',
        controller:'formController'
    })

//     $routeProvider
//     .when("/", {
//         controller : "homeController",
//         templateUrl : "main.html"
//     })
//      .when("/ac-repair", {
//         templateUrl : "views/services-ac.html",
//         controller : "formController"
      
//     })
//      .when("/cctv-camera", {
//         controller : "formController",
//         templateUrl : "views/services-cctv.html"
//     })
//      .when("/marble-tiles", {
//         controller : "formController",
//         templateUrl : "views/services-marble-tiles-sanitary.html"
//     })
//      .when("/electrician", {
//         controller : "formController",
//         templateUrl : "views/services-electrician.html"
//     })
//      .when("/painters", {
//         controller : "formController",
//         templateUrl : "views/services-house-painters.html"
//     })
//      .when("/glass", {
//         controller : "formController",
//         templateUrl : "views/services-aluminum-glass-work.html"
//     })
//      .when("/carpenter", {
//         controller : "formController",
//         templateUrl : "views/services-carpenter.html"
//     })
//      .when("/drilling", {
//         controller : "formController",
//         templateUrl : "views/services-drilling-hanging.html"
//     })
//      .when("/ceiling", {
//         controller : "formController",
//         templateUrl : "views/services-ceiling.html"
//     })
//      .when("/plumbing", {
//         controller : "formController",
//         templateUrl : "views/services-plumbing.html"
//     })
//      .when("/bathroom", {
//         controller : "formController",
//         templateUrl : "views/services-bathroom-deep-cleaning.html"
//     }).when("/aboutus", {
//         controller : "formController",
//         templateUrl : "views/about-us.html"
//     })
// .when("/services", {
//         controller : "formController",
//         templateUrl : "views/our-services.html"
//     })
//      .when("/blogs", {
//         controller : "formController",
//         templateUrl : "views/our-blog.html"
//     })
//      .when("/contacts", {
//         controller : "formController",
//         templateUrl : "views/contact-us.html"
//     })
//      .when("/about", {
//         controller : "formController",
//         templateUrl : "views/about-us.html"
//     })   
}]);  


app.controller("mainController", function($scope,$http,$location) {

 $location.path('/');
});
  
})();
