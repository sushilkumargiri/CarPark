module CarParkApp.controllers {
    export class CarParkController {
        static $inject = ['$scope','CarkParkService'];

        constructor(private $scope: any, private $carParkService: CarParkApp.services.CarkParkService) {
            debugger;
            var self = this;
            self.$scope = $scope;
            self.$carParkService = $carParkService;
          
            self.$scope.SaveData = function () {
                self.$carParkService.SaveData($scope.Vehicle)
                    .then(function (data) {//success
                        console.log(data);
                        self.$scope.rate = data.data.result;
                    },
                    function (data) {//error
                        console.log(data.data.result);
                    });
            }
        }
    }
    angular.module('CarParkApp')
        .controller('CarParkController', CarParkController);

}