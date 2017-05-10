var CarParkApp;
(function (CarParkApp) {
    var controllers;
    (function (controllers) {
        var CarParkController = (function () {
            function CarParkController($scope, $carParkService) {
                this.$scope = $scope;
                this.$carParkService = $carParkService;
                debugger;
                var self = this;
                self.$scope = $scope;
                self.$carParkService = $carParkService;
                self.$scope.SaveData = function () {
                    self.$carParkService.SaveData($scope.Vehicle)
                        .then(function (data) {
                        console.log(data);
                        self.$scope.rate = data.data.result;
                    }, function (data) {
                        console.log(data.data.result);
                    });
                };
            }
            CarParkController.$inject = ['$scope', 'CarkParkService'];
            return CarParkController;
        }());
        controllers.CarParkController = CarParkController;
        angular.module('CarParkApp')
            .controller('CarParkController', CarParkController);
    })(controllers = CarParkApp.controllers || (CarParkApp.controllers = {}));
})(CarParkApp || (CarParkApp = {}));
