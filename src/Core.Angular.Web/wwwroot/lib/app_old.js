(function () {
    'use strict';

    angular.module('app', ['ngRoute'])
    .controller('CarParkController', ['$scope', '$http', function ($scope, $http) {
        $scope.Vehicle = {};
        $scope.SendHttpPostData = function () {
            var data = $.param({
                ParkingStartDate: $scope.Vehicle.ParkingStartDate,
                EntryTimeHr: $scope.Vehicle.EntryTimeHr,
                EntryTimeMn: $scope.Vehicle.EntryTimeMn,
                ParkingEndDate: $scope.Vehicle.ParkingEndDate,
                ExitTimeHr: $scope.Vehicle.ExitTimeHr,
                ExitTimeMn: $scope.Vehicle.ExitTimeMn
            });

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }
            $http.post('/Home/Calculate', data, config)
            .success(function (data, status, headers, config) {
                debugger;
                $scope.ServerResponse = data;
            })
            .error(function (data, status, header, config) {
                $scope.ServerResponse = "Data: " + data +
                    "<hr />status: " + status +
                    "<hr />headers: " + header +
                    "<hr />config: " + config;
            });
        };
    }])
    .directive('ccDatePicker', function ($compile) {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModelCtrl) {
                $(element[0]).datepicker({ dateFormat: 'dd/mm/yy' }).on("change", function (e) {
                    var date = element.val();
                    scope.$apply(function () {
                        ngModelCtrl.$setViewValue(date);
                    });

                });
            }
        };
    });

})();