(function () {
    var controllerId = 'app.views.truck.search';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.orders', 'abp.services.app.offers', function ($scope, ordersService, offersService) {
            var vm = this;

            vm.trucks = [];

            var config = {
                headers: {
                    //'X-Token': 'waY6ybEUGUbQ4NgNFohlCWxamoXkCGjA3apK9K2XJ9a1Tim+yCfIUHBGYYuw9QyxccALhpu8Gk7a+B8e//Dyc/jOn3VOJmADd6pONRaDGx43HTvifYnI0nnP0xp5GSe9y+cyQgbyzqVRIR0B+9Q3yew9JRpKbyUiHcY+apd/wlWTx6WQfOIdft9L5Wbd6RM/WguMizO76Kq+kMgTYdxGQu+Ak5rf3CdmYqnL9Af9RLRxO/LiniIOCxT60x/9AzymSI7kSU9ppamP5npcJo6mc/RRK7/j5hKFriBqrsa4pl8nI8c5jMA1YHT/aISu0M+hR8BVT1yjzrtTC9D4+LiRBg=='
                    'X-Token': 'Wejq5wVE4Hh3QmPPm7kEqqOne2DE4mDc2vrrVsnFAtVH+t6pdNRbS/c1a2TKveS/3EUb4QfBNKLuyZmmHc1u9HFImT/6mMV8GKFhghXSeMU0CD15/ky7iH8brdgenudQmaqGoY/qZ6D1lN0TAEtATLSB4mqPN3Jh1r90LZkJlxp+/Yst+48PS4ih0+WAQat0LZ/kxtUMzq8DHbZiK61AZW31ODHuDYGH4xFxuZC4k6/DpmWOQar7m+mPuA93rFjzoAZihduCSOsI6Cylw5QKCiYkEX0uw0JEnw0zvoByBP6cRRuzl7twvEvNaYhj0TINl9is6CvoqdDy23Ck9c7wPg=='
                    //'X-Token': 'qDROm7en6GZBQchSXWuPAQ5tlLwpEoSc4/nBXWZH2+RzyX9zdi/VlPCJ2GqhIFhXJNJkHADlstcF8TfkBfMgIS2VGrj9Iiu+5ewPEUDYx19C/Jeujke8y20aUOpInkWuroK8Ts5C3zRumvMGyVHS9Y6vTbfWLaEwfGn1rBwLov/QFeEvcFRi1FNh+xR2JTTlD82Mmp/K4E6kHY/iRHDvwVmUcDBq/ol8qE0IMz0tGUt3S4u/nnLPChHSHVdksf28xxGq2X+/oWjCIp+YBqJn3qL6V0ASp0bRqp+yXdKLyFM8Swi4If1Jg8MtnC57Roo6rXAWYWUdytEWqAsx4jRBMw=='
                }
            };

            abp.ui.setBusy(null,                

            ordersService.getTrucks(config).success(function (data) {
                vm.trucks = data.orders;
            }));

            $scope.sendOffer = function (truck) {

                var data = {
                    orderId: truck.id
                };

                abp.ui.setBusy(null,

                offersService.addOffer(data, config).success(function () {
                    abp.notify.info('Oferta została wysłana!');
                }));
                truck.wasOfferSent = true;
            };
        }
    ]);
})();