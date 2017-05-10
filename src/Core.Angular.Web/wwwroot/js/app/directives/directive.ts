module CarParkApp.Directives {
    'use strict';

    export class MyDirective implements ng.IDirective {
        restrict = 'A';
        require = 'ngModel';
        templateUrl = '';
        replace = true;

        constructor(private $location: ng.ILocationService) {
        }

        link = (scope: ng.IScope, element: ng.IAugmentedJQuery, attrs: ng.IAttributes, ctrl: any) => {
            $(element[0]).datepicker({ dateFormat: 'dd/mm/yy' }).on("change", function (e) {
                var date = element.val();
                scope.$apply(function () {
                    ctrl.$setViewValue(date);
                });
            });
        }

        static factory(): ng.IDirectiveFactory {
            const directive = ($location: ng.ILocationService) => new MyDirective($location);
            directive.$inject = ['$location'];
            return directive;
        }
    }

    angular.module('CarParkApp')
        .directive('ccDatePicker', MyDirective.factory());
   
}