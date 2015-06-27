﻿(function () {
    var controllerId = 'app.views.freight.add';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.orders', function ($scope, ordersService) {
            var vm = this;
            
            $scope.car_body = "tilt";
            $scope.capacity = 1.0;
            $scope.length = 1.0;
            $scope.price = 100;
            $scope.currency = "PLN";
            $scope.visibility = "all";
            $scope.partial = false;

            $scope.country_from = "PL";
            $scope.city_from = "(30-072) Kraków";
            $scope.loading_date = "2015-07-01 20:00";

            $scope.country_to = "PL";
            $scope.city_to = "(39-200) Dębica";
            $scope.unloading_date = "2015-07-02 15:00";
            
            $scope.submit = function () {
                var config = {
                    headers: {
                        'X-Token': 'qDROm7en6GZBQchSXWuPAQ5tlLwpEoSc4/nBXWZH2+RzyX9zdi/VlPCJ2GqhIFhXJNJkHADlstcF8TfkBfMgIS2VGrj9Iiu+5ewPEUDYx19C/Jeujke8y20aUOpInkWuroK8Ts5C3zRumvMGyVHS9Y6vTbfWLaEwfGn1rBwLov/QFeEvcFRi1FNh+xR2JTTlD82Mmp/K4E6kHY/iRHDvwVmUcDBq/ol8qE0IMz0tGUt3S4u/nnLPChHSHVdksf28xxGq2X+/oWjCIp+YBqJn3qL6V0ASp0bRqp+yXdKLyFM8Swi4If1Jg8MtnC57Roo6rXAWYWUdytEWqAsx4jRBMw=='                        
                    }
                };

                var data = {
                    
                        CarBody: $scope.car_body,
                        Capacity: $scope.capacity,
                        Length: $scope.length,
                        Price: $scope.price,
                        Currency: $scope.currency,
                        Visibility: $scope.visibility,
                        Partial: $scope.partial,                   
                        CountryFrom: $scope.country_from,
                        CityFrom: $scope.city_from,
                        LoadingDate: $scope.loading_date,
                        CountryTo: $scope.country_to,
                        CityTo: $scope.city_to,
                        UnloadingDate: $scope.unloading_date,
                        Type: 'freight'                    
                };                

                ordersService.addOrder(data, config);
            };
        }
    ]);
})();