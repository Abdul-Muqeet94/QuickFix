
(function () {
    var app = angular.module('quoteModule', []);

 app.controller("quoteController", function ($scope, ModalService,$http ) {

$scope.sendQuote=function()
{
$scope.contact.sendTo=$rootScope.email;
    $scope.message = $http.post('https://testing.danishtest.ml/api/task/quoteemail/',$scope.contact).
                then(function (response) {
                    
                    alert(response.data.developerMessage);


                });
    
}

    });


    
})();