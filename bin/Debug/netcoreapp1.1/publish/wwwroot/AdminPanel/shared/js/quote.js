
(function () {
    var app = angular.module('quoteModule', []);

 app.controller("quoteController", function ($scope, ModalService,$http ) {

$scope.sendQuote=function()
{
$scope.contact.sendTo=$rootScope.email;
    $scope.message = $http.post('http://localhost:5000/api/task/quoteemail/',$scope.contact).
                then(function (response) {
                    
                    alert(response.data.developerMessage);


                });
    
}

    });


    
})();