(function () {
  var app = angular.module("featureModule", ['ngRoute']);
//

app.directive('myGoogleAutocomplete', function () {
	return {
		replace: true,
		require: 'ngModel',
		scope: {
			ngModel: '=',
			googleModel: '=',
			onSelect: '&',	// optional callback on selected successfully: 'onPostedBid(googleModel)'
		},
		template: '<input class="form-control" type="text" style="z-index: 100000;" autocomplete="on">',
		link: function ($scope, element, attrs, model) 
		{
			var googleOptions = {
				types: [] // change or empty it, if you want no restrictions
			};

			var autocomplete = new google.maps.places.Autocomplete(element[0], googleOptions);

			google.maps.event.addListener(autocomplete, 'place_changed', function () {


				/**
				 * Search gor the passed 'type' of info into the google place component
				 * @param {type} components
				 * @param {type} type
				 * @returns {type} 
				 */
				$scope.extract = function (components, type) {
					for (var i = 0; i < components.length; i++)
						for (var j = 0; j < components[i].types.length; j++)
							if (components[i].types[j] == type) return components[i].short_name;
					return '';
				};


				$scope.$apply(function () {
					var place = autocomplete.getPlace();
					if (!place.geometry)
					 {
						// User entered the name of a Place that was not suggested and pressed the Enter key, or the Place Details request failed.
						model.$setValidity('place', false);
						//console.log("No details available for input: '" + place.name + "'");
						return;
					}

					$scope.googleModel = {};
					$scope.googleModel.placeId = place.place_id;
					$scope.googleModel.latitude = place.geometry.location.lat();
					$scope.googleModel.longitude = place.geometry.location.lng();
					console.log($scope.googleModel.longitude);
				
					console.log($scope.googleModel.latitude);
					//function  call of controller..  

					$scope.googleModel.formattedAddress = place.formatted_address;
					if (place.address_components) {
						$scope.googleModel.address = [
							$scope.extract(place.address_components, 'route'),
							$scope.extract(place.address_components, 'street_number')
						].join(' ');
					
					}

					model.$setViewValue(element.val());
					model.$setValidity('place', true);
					if (attrs.onSelect)
					{ 
						$scope.onSelect({ $item: $scope.googleModel });
				}
				});
			});
		}
	}

});

app.controller("featureController", function($scope,$http,$rootScope,close,ModalService,NgMap) {

$scope.onSelect=function(val)
{
	
NgMap.getMap().then(function(map) { //Create the instance of map
     var latlng = new google.maps.LatLng(val.latitude, val.longitude);
 map.markers[0].setPosition(latlng);
		map.setCenter(latlng);	
			
       
});
}
$scope.getLoc=function(e)
{
	$scope.lati = e.latLng.lat();
	$scope.long=  e.latLng.lng();
 $scope.message = $http.get('	http://maps.googleapis.com/maps/api/geocode/json?latlng='+$scope.lati+','+$scope.long+'&sensor=true').
            then(function (response) {
				console.log(response.data.results[0].formatted_address);
				$scope.task.house_no=response.data.results[0].formatted_address;	
					});	
}
  $scope.message = $http.post('http://localhost:5000/api/service/view', $rootScope.permService).
            then(function (response) {
							
								$rootScope.service = response.data[0];
								console.log(response.data[0]);

	$scope.show=true;
  $scope.states=[];
	 $rootScope.task = {};
	 
    $scope.shifts = [];
  $scope.states.push(true);
  $scope.states.push(false);
  $scope.states.push(false);
  $scope.states.push(false);
  $scope.states.push(false);
console.log($scope.states);
  $scope.counter=0;
  $rootScope.task.callUpCharges=200;
$rootScope.task.paymentStatus=0;

$scope.message=$rootScope.service.feature;
$scope.a1=[];
  $scope.a2=[];
 $scope.a3=[];
 $scope.name= $rootScope.service.name;
if($rootScope.service.name=='AC Service & Repair')
{
console.log($rootScope.permService);
$scope.a1.push($scope.service.feature[0]);
$scope.a1.push($scope.service.feature[1]);
   
$scope.a2.push($scope.service.feature[2]);
$scope.a2.push($scope.service.feature[3]);
$scope.a2.push($scope.service.feature[4]);
$scope.a2.push($scope.service.feature[5]);
  
$scope.a3.push($scope.service.feature[6]);
$scope.a3.push($scope.service.feature[7]);
$scope.a3.push($scope.service.feature[8]);
$scope.a3.push($scope.service.feature[9]);
$scope.a3.push($scope.service.feature[10]);

}

$rootScope.service.feature=[];



    $scope.shifts.push("07-10 am");
    $scope.shifts.push("10-12 pm");
    $scope.shifts.push("12-02 pm");
    $scope.shifts.push("02-04 pm");
    $scope.shifts.push("04-06 pm");
    $scope.shifts.push("06-08 pm");

    console.log($scope.shifts);
    $rootScope.features = [];


  });
$scope.toggleSelection = function(id)
{
  if($rootScope.service.feature==0)
  {
$rootScope.service.feature.push(id);
  }
else
{
  if($rootScope.service.feature.indexOf(id) == -1)
  {   
$rootScope.service.feature.push(id);
}
else
{
 $rootScope.service.feature.splice($rootScope.service.feature.indexOf(id),1);
}
}
}
$scope.close = function(result) {

    close(result, 500); // close, but give 500ms for bootstrap to animate
}

$scope.next=function()
{
$scope.counter++;

if($scope.counter>4)
{
	return;
}

  for(var i=0;i<$scope.states.length;i++)
{
  $scope.states[i]=false;
}
$scope.states[$scope.counter]=true;
if($scope.counter==4)
{
$scope.show=false;
	$rootScope.task.location=$scope.model.googleAddress.latitude+","+$scope.model.googleAddress.longitude;

 $rootScope.service.features = $rootScope.service.feature;
 
$rootScope.task.selected_services=[];
$rootScope.task.selected_services.push($rootScope.service);
$rootScope.task.id=0;
console.log($rootScope.task);
			

$scope.message = $http.post('http://localhost:5000/api/task/create',$scope.task).
    then(function (response){
      console.log(response.data);
    });
	
}
	
}


$scope.prev=function()
{
$scope.counter--;

if($scope.counter<0 ||$scope.counter>4)
{$scope.counter++;
  //do nothing 
  return;
}
  for(var i=0;i<$scope.states.length;i++)
{
  $scope.states[i]=false;
}

$scope.states[$scope.counter]=true;
}
    $scope.SaveShift = function (id) {
      console.log(id);
      $rootScope.task.shift = $scope.shifts[id];
      console.log($rootScope.task.shift);


      for (var i = 0; i < $scope.shifts.length; i++) {
        if (i != id) {
          document.getElementById(i).style.backgroundColor = 'white';
        }
        else {
          document.getElementById(i).style.backgroundColor = 'lawngreen';
        }
      }
    }



});  
})();