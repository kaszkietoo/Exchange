(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('start', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Start' //Matches to name of 'Home' menu in ExchangeNavigationProvider
                })
                .state('reportFreight', {
                    url: '/freight/add',
                    templateUrl: '/App/Main/views/freight/add.cshtml',
                    menu: 'ReportFreight'
                })
                .state('searchFreights', {
                    url: '/freight/search',
                    templateUrl: '/App/Main/views/freight/search.cshtml',
                    menu: 'SearchFreights'
                })
                .state('reportTruck', {
                    url: '/truck/add',
                    templateUrl: '/App/Main/views/truck/add.cshtml',
                    menu: 'ReportTruck'
                })
                .state('searchTrucks', {
                    url: '/truck/search',
                    templateUrl: '/App/Main/views/truck/search.cshtml',
                    menu: 'SearchTrucks'
                })
                .state('myOffers', {
                    url: '/offers',
                    templateUrl: '/App/Main/views/offers/offers.cshtml',
                    menu: 'MyOffers'
                });
        }
    ]);
})();