(function () {
  var app = angular.module("calenderModule", ['ui.calendar', 'angularModalService']);

  app.controller("calenderController", function ($scope, $http, ModalService) {
    $scope.eventstemp = [];
    $scope.message = $http.post('http://localhost:5000/api/shift/view/', 0).
      then(function (response) {
        console.log(response.data);
        for (var i = 0; i < response.data.length; i++) {
          var id = response.data[i].id;
          var title = response.data[i].name;
          var start = response.data[i].sDate;
          var TimeIn = response.data[i].sTime;
          var TimeOut = response.data[i].eTime;

          var obj = { title: title, start: start, id: id };
          var objtemp = { id: id, title: title, start: TimeIn, end: TimeOut };
          console.log("sdsd" + obj);
          $scope.events.push(obj);
          $scope.eventstemp.push(objtemp);
        }
        console.log($scope.events);

      });

    $scope.events = [{ title: 'Event1', start: '2017-06-05' }];

    $scope.clickEvent = function (event, jsEvent, view) {

      for (var i = 0; i < $scope.eventstemp.length; i++) {
        if ($scope.eventstemp[i].id == event.id) {
          $scope.start = $scope.eventstemp[i].start;
          $scope.end = $scope.eventstemp[i].end;
          $scope.title = $scope.eventstemp[i].title;
          console.log($scope.end);
          console.log($scope.start);
          console.log($scope.title);

          break;
        }

      }

      //

      ModalService.showModal({
        templateUrl: "modal.html",
        controller: "ModalController",
        inputs: {
          title: $scope.title,
          start: $scope.start,
          end: $scope.end
        }
      }).then(function (modal) {

        //it's a bootstrap element, use 'modal' to show it
        modal.element.modal();
        modal.close.then(function (result) {
          console.log(result);
        });
      });
    };
    $scope.alertOnDrop = function (event, jsEvent, view) {
      for (var i = 0; i < $scope.events.length; i++) {
        if ($scope.events[i].id == event.id) {
          var ind = $scope.events.indexOf(event);
          $scope.events.splice(ind, 1);
          $scope.message = $http.post('http://localhost:5000/api/shift/delete', event.id).
            then(function (response) {
              console.log(response.data);

            });
          break;
        }

      }
    }

    $scope.uiConfig = {
      calendar: {
        height: 450,
        editable: true,
        droppable: true,
        header: {
          left: 'month basicWeek basicDay agendaWeek agendaDay',
          center: 'title',
          right: 'today prev,next'
        },
        eventClick: $scope.clickEvent,
        eventDrop: $scope.alertOnDrop,
        eventResize: $scope.alertOnResize,
        events: $scope.events
      }
    };

    $scope.days = [
      { 'id': 1, 'label': 'Sunday' },
      { 'id': 2, 'label': 'Monday' },
      { 'id': 3, 'label': 'Tuesday' },
      { 'id': 4, 'label': 'Wednesday' },
      { 'id': 5, 'label': 'Thursday' },
      { 'id': 6, 'label': 'Friday' },
      { 'id': 7, 'label': 'Saturday' }
    ]


    //UI.Clock Picker
   
    //save
    $scope.addEvent = function () {
      $scope.new.id = 0;
      $scope.new.enable = true;
      console.log($scope.new);
      $scope.message = $http.post('http://localhost:5000/api/shift/create/', $scope.new).
        then(function (response) {
          console.log(response.data);


          $scope.message = $http.post('http://localhost:5000/api/shift/view/', '-1').
            then(function (response) {
              console.log("qwertyuioplkjhg" + response.data);
              for (var i = 0; i < response.data.length; i++) {
                var id = response.data[i].id;
                var title = response.data[i].name;
                var start = response.data[i].sDate;
                var TimeIn = response.data[i].sTime;
                var TimeOut = response.data[i].eTime;

                var obj = { id: id, title: title, start: start };
                $scope.events.push(obj);
                var objtemp = { id: id, title: title, start: TimeIn, end: TimeOut };
                $scope.eventstemp.push(objtemp);
              }
            });

        });
    }
    //
  }
  );

  app.controller('ModalController', function ($scope, close, title, start, end) {
    $scope.title = title;
    $scope.start = start;
    $scope.end = end;
    // when you need to close the modal, call close
    $scope.close = function (result) {
      close(result, 500);
    }
  });
  //
})();
