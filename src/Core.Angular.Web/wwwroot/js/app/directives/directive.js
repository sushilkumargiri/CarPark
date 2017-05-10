var CarParkApp;
(function (CarParkApp) {
    var Directives;
    (function (Directives) {
        'use strict';
        var MyDirective = (function () {
            function MyDirective($location) {
                this.$location = $location;
                this.restrict = 'A';
                this.require = 'ngModel';
                this.templateUrl = '';
                this.replace = true;
                this.link = function (scope, element, attrs, ctrl) {
                    $(element[0]).datepicker({ dateFormat: 'dd/mm/yy' }).on("change", function (e) {
                        var date = element.val();
                        scope.$apply(function () {
                            ctrl.$setViewValue(date);
                        });
                    });
                };
            }
            MyDirective.factory = function () {
                var directive = function ($location) { return new MyDirective($location); };
                directive.$inject = ['$location'];
                return directive;
            };
            return MyDirective;
        }());
        Directives.MyDirective = MyDirective;
        angular.module('CarParkApp')
            .directive('ccDatePicker', MyDirective.factory());
    })(Directives = CarParkApp.Directives || (CarParkApp.Directives = {}));
})(CarParkApp || (CarParkApp = {}));
