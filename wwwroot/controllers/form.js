(function () {
  var app = angular.module("formModule", ['ngRoute']);


app.controller("formController", function($scope,$http,$rootScope,$location,ModalService) {
  
  
 $scope.message = $http.post('https://testing.danishtest.ml/api/cms/viewbypage','"' + $rootScope.pageName + '"').
            then(function (response) {
                $scope.cms = response.data;
                console.log($scope.cms);

            });

$scope.request=function()
{
  $scope.problem.service=$rootScope.savedService;
  
  console.log($scope.problem);

  // muqeet call your api here
 $scope.message = $http.post('https://testing.danishtest.ml/api/contactus/create',$scope.problem).
            then(function (response) {
                console.log(response.data);
                $scope.problem.name="";
                $scope.problem.email="";
                $scope.problem.address="";
                $scope.problem.phone="";
                $scope.problem.comments="";
            });

 
}
$scope.BookNow= function()
{

  ModalService.showModal({
    templateUrl:'modal.html',
    controller: "featureController"
  }).then(function(modal) {

   modal.element.modal();
    modal.close.then(function(result) {
      console.log(result);
    });
  });


}
$scope.fillForm=function(serviceName)
{
 var name =serviceName;
				if (name == "AC Service & Repair") {
                    $rootScope.savedService=name;
                       $location.path('/ac-repair');
                                      return;
                }
                else if (name == "CCTV Camera") {
                    $rootScope.savedService=name;
                   $location.path('/cctv-camera');
                    return;
                }
                else if (name == "Marble Tiles & Sanitary") {
                    $rootScope.savedService=name;
                     $location.path('/marble-tiles');
                    return;
                  }
                else if (name == "Electrician") {
                   $rootScope.savedService=name;
                     $location.path('/electrician');
                return;    
            }
                else if (name == "House Painters") {
                   $rootScope.savedService=name;
                    $location.path('/painters');
                return;
             
        }
                else if (name == "Aluminum & Glass Work") {
                    $rootScope.savedService=name;
                    $location.path('/glass');
                 return;   
             }
                else if (name == "Carpenter") {
                    $rootScope.savedService=name;
                  $location.path('/carpenter');
                 return;   
             }
                else if (name == "Drilling & Hanging") {
                  $rootScope.savedService=name;
                   $location.path('/drilling');

return;
}


               else if (name == "Plumbing") {
                  $rootScope.savedService=name;
                   $location.path('/plumbing');

return;
}


               else if (name == "Bathroom Deep Cleaning") {
                  $rootScope.savedService=name;
                   $location.path('/bathroom');

return;
}


               else if (name == "Ceiling") {
                  $rootScope.savedService=name;
                   $location.path('/ceiling');

return;
}

}

 });




////

  
})();
