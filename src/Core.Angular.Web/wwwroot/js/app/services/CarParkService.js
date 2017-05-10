var CarParkApp;
(function (CarParkApp) {
    var services;
    (function (services) {
        'use strict';
        var CarkParkService = (function () {
            function CarkParkService($http) {
                this.$http = $http;
                this.GET_METHOD = "GET";
                this.POST_METHOD = "POST";
                this.SaveDataUrl = "/Home/CalculateNew";
            }
            CarkParkService.prototype.SaveData = function (newRec) {
                console.log(newRec);
                debugger;
                return this.$http({
                    method: this.POST_METHOD,
                    url: this.SaveDataUrl,
                    headers: { 'Content-Type': 'application/json' },
                    data: newRec
                });
            };
            CarkParkService.$inject = ['$http'];
            return CarkParkService;
        }());
        services.CarkParkService = CarkParkService;
        angular.module('CarParkApp')
            .service('CarkParkService', CarkParkService);
    })(services = CarParkApp.services || (CarParkApp.services = {}));
})(CarParkApp || (CarParkApp = {}));
