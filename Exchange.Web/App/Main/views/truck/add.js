(function () {
    var controllerId = 'app.views.truck.add';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.orders', function ($scope, ordersService) {
            var vm = this;

            $scope.car_body = "Firanka";
            $scope.capacity = 1.0;
            $scope.length = 1.0;
            $scope.price = 10.0;
            $scope.currency = "EUR";
            $scope.visibility = "all";
            $scope.partial = true;

            $scope.country_from = "PL";
            $scope.city_from = "(30-072) Kraków";
            $scope.loading_date = "2015-07-01 20:00";

            $scope.country_to = "PL";
            $scope.city_to = "(39-200) Dębica";
            $scope.unloading_date = "2015-07-02 15:00";

            $scope.submit = function () {
                var config = {
                    headers: {
                        //'X-Token': 'waY6ybEUGUbQ4NgNFohlCWxamoXkCGjA3apK9K2XJ9a1Tim+yCfIUHBGYYuw9QyxccALhpu8Gk7a+B8e//Dyc/jOn3VOJmADd6pONRaDGx43HTvifYnI0nnP0xp5GSe9y+cyQgbyzqVRIR0B+9Q3yew9JRpKbyUiHcY+apd/wlWTx6WQfOIdft9L5Wbd6RM/WguMizO76Kq+kMgTYdxGQu+Ak5rf3CdmYqnL9Af9RLRxO/LiniIOCxT60x/9AzymSI7kSU9ppamP5npcJo6mc/RRK7/j5hKFriBqrsa4pl8nI8c5jMA1YHT/aISu0M+hR8BVT1yjzrtTC9D4+LiRBg=='
                        'X-Token': 'Wejq5wVE4Hh3QmPPm7kEqqOne2DE4mDc2vrrVsnFAtVH+t6pdNRbS/c1a2TKveS/3EUb4QfBNKLuyZmmHc1u9HFImT/6mMV8GKFhghXSeMU0CD15/ky7iH8brdgenudQmaqGoY/qZ6D1lN0TAEtATLSB4mqPN3Jh1r90LZkJlxp+/Yst+48PS4ih0+WAQat0LZ/kxtUMzq8DHbZiK61AZW31ODHuDYGH4xFxuZC4k6/DpmWOQar7m+mPuA93rFjzoAZihduCSOsI6Cylw5QKCiYkEX0uw0JEnw0zvoByBP6cRRuzl7twvEvNaYhj0TINl9is6CvoqdDy23Ck9c7wPg=='
                        //'X-Token': 'qDROm7en6GZBQchSXWuPAQ5tlLwpEoSc4/nBXWZH2+RzyX9zdi/VlPCJ2GqhIFhXJNJkHADlstcF8TfkBfMgIS2VGrj9Iiu+5ewPEUDYx19C/Jeujke8y20aUOpInkWuroK8Ts5C3zRumvMGyVHS9Y6vTbfWLaEwfGn1rBwLov/QFeEvcFRi1FNh+xR2JTTlD82Mmp/K4E6kHY/iRHDvwVmUcDBq/ol8qE0IMz0tGUt3S4u/nnLPChHSHVdksf28xxGq2X+/oWjCIp+YBqJn3qL6V0ASp0bRqp+yXdKLyFM8Swi4If1Jg8MtnC57Roo6rXAWYWUdytEWqAsx4jRBMw=='
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
                    Type: 'Pojazd'
                };

                abp.ui.setBusy(null,                    
                ordersService.addOrder(data, config).success(function () {
                    abp.notify.info('Dodano nowy pojazd!');
                }));
            };
        }
    ]);
})();