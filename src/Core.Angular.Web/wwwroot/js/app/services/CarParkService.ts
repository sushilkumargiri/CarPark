module CarParkApp.services {
    'use strict';

    export interface ICarkParkService {
        SaveData(newRec: any): ng.IPromise<any>
    }

    export class CarkParkService implements ICarkParkService {
        private GET_METHOD: string = "GET";
        private POST_METHOD: string = "POST";
        private SaveDataUrl: string = "/Home/CalculateNew";

        static $inject = ['$http'];
        
        constructor(private $http: ng.IHttpService) {
        }

        SaveData(newRec: any): ng.IPromise<any> {
            console.log(newRec);
            debugger;
            return this.$http({
                method: this.POST_METHOD,
                url: this.SaveDataUrl,
                headers: { 'Content-Type': 'application/json' },
                data: newRec
            });
        }
    }

    angular.module('CarParkApp')
        .service('CarkParkService', CarkParkService);
}