(function () {
    var app = angular.module("homeModule", ['ngRoute']);


    app.controller("homeController", function ($scope, $http, $location, $rootScope,ModalService) {
        $scope.message = $http.post('https://testing.danishtest.ml/api/service/view', 0).
            then(function (response) {
                $scope.services = response.data;
            });
        $scope.message = $http.post('https://testing.danishtest.ml/api/cms/viewbypage', "'index'").
            then(function (response) {
                $scope.cms = response.data;
                console.log($scope.cms);
            });


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

//        $scope.places = ["Abu Dabi", "Ajman", "Dubai", "Sharjah"];
        // $scope.myPlace="City";
        
        // $scope.$watch("selectedService", function (newValue, oldValue) {
        //     // your code goes here...
        //     if (newValue != oldValue) {
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
$scope.book=function()
{
    $rootScope.contact=$scope.contact;
    $rootScope.email=$scope.email;
        var name = $scope.selectedService.originalObject.name;
				$rootScope.permService=$scope.selectedService.originalObject.id;
                if (name == "AC Service & Repair") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "AC Service & Repair";
                 //   $location.path('/ac-repair');
                   $scope.BookNow();
                    return;
                }
                else if (name == "CCTV Camera") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "CCTV Camera";
                  //  $location.path('/cctv-camera');
                        $scope.BookNow();
                    return;
                }
                else if (name == "Marble Tiles & Sanitary") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "Marble Tiles & Sanitary";
                    // $location.path('/marble-tiles');
                         $scope.BookNow();
                }
                else if (name == "Electrician") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "Electrician";
                    // $location.path('/electrician');
                 $scope.BookNow();    
            }
                else if (name == "House Painters") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "House Painters";
                //    $location.path('/painters');
                
             $scope.BookNow();    
        }
                else if (name == "Aluminum & Glass Work") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "Aluminum & Glass Work";
                    // $location.path('/glass');
                 $scope.BookNow();   
             }
                else if (name == "Carpenter") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "Carpenter";
                    // $location.path('/carpenter');
                 $scope.BookNow();   
             }
                else if (name == "Drilling & Hanging") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "Drilling & Hanging";
                    // $location.path('/drilling');
             $scope.BookNow();        
            
        }
                else if (name == "Ceiling") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "Ceiling";
                    // $location.path('/ceiling');
                 $scope.BookNow();    
            }
                else if (name == "Plumbing") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "Plumbing";
                    // $location.path('/plumbing');
     $scope.BookNow();
                }
                else if (name == "Bathroom Deep Cleaning") {
                    $rootScope.service = $scope.selectedService.originalObject;
                    $rootScope.pageName = "Bathroom Deep Cleaning";
                    // $location.path('/bathroom');
                 $scope.BookNow();   
             }

}
        
        $scope.serviceClicked = function (name) {
            console.log(name);

            for (var i = 0; i < $scope.services.length; i++) {
                console.log($scope.services[i].name);
                if ($scope.services[i].name == name) {
					$rootScope.permService=$scope.services[i].id;
                    $rootScope.service = $scope.services[i];
                    break;

                }
            }

            if (name == 'AC Service & Repair') {
                $rootScope.pageName="AC Service & Repair";
                // $location.path('/ac-repair');
                $scope.BookNow();

            }
            else if (name == "CCTV Camera") {
                $rootScope.pageName="CCTV Camera";
                // $location.path('/cctv-camera');
                $scope.BookNow();
                return;
            }
            else if (name == "Marble Tiles & Sanitary") {
                $rootScope.pageName="Marble Tiles & Sanitary";
                // $location.path('/marble-tiles');
                $scope.BookNow();
                return;
            }
            else if (name == "Electrician") {
                $rootScope.pageName="Electrician";
                // $location.path('/electrician');
                $scope.BookNow();
                return;
            }
            else if (name == "House Painters") {
                $rootScope.pageName="House Painters";
                // $location.path('/painters');
                $scope.BookNow();
                return;
            }
            else if (name == "Aluminum & Glass Work") {
                $rootScope.pageName="Aluminum & Glass Work";
                // $location.path('/glass');
                $scope.BookNow();
                return;
            }
            else if (name == "Carpenter") {
                $rootScope.pageName="Carpenter";
                // $location.path('/carpenter');
              $scope.BookNow();
                return;
            }
            else if (name == "Drilling & Hanging") {
                $rootScope.pageName="Drilling & Hanging";
                // $location.path('/drilling');
                $scope.BookNow();
                
                return;
            }
            else if (name == "Ceiling") {
                $rootScope.pageName="Ceiling";
                // $location.path('/ceiling');
               $scope.BookNow();
                return;
            }
            else if (name == "Plumbing") {
                $rootScope.pageName="Plumbing";
                // $location.path('/plumbing');
                $scope.BookNow();
                return;
            }
            else if (name == "Bathroom Deep Cleaning") {
                $rootScope.pageName="Bathroom Deep Cleaning";
                // $location.path('/bathroom');
               $scope.BookNow();
                return;
            }


        }
    });

})();
