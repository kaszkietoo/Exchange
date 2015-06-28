(function () {
    var controllerId = 'app.views.truck.search';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.orders', function ($scope, ordersService) {
            var vm = this;

            vm.trucks = [];

            var config = {
                headers: {
                    'X-Token': 'Wejq5wVE4Hh3QmPPm7kEqqOne2DE4mDc2vrrVsnFAtVH+t6pdNRbS/c1a2TKveS/3EUb4QfBNKLuyZmmHc1u9HFImT/6mMV8GKFhghXSeMU0CD15/ky7iH8brdgenudQmaqGoY/qZ6D1lN0TAEtATLSB4mqPN3Jh1r90LZkJlxp+/Yst+48PS4ih0+WAQat0LZ/kxtUMzq8DHbZiK61AZW31ODHuDYGH4xFxuZC4k6/DpmWOQar7m+mPuA93rFjzoAZihduCSOsI6Cylw5QKCiYkEX0uw0JEnw0zvoByBP6cRRuzl7twvEvNaYhj0TINl9is6CvoqdDy23Ck9c7wPg=='
                    //'X-Token': 'qDROm7en6GZBQchSXWuPAQ5tlLwpEoSc4/nBXWZH2+RzyX9zdi/VlPCJ2GqhIFhXJNJkHADlstcF8TfkBfMgIS2VGrj9Iiu+5ewPEUDYx19C/Jeujke8y20aUOpInkWuroK8Ts5C3zRumvMGyVHS9Y6vTbfWLaEwfGn1rBwLov/QFeEvcFRi1FNh+xR2JTTlD82Mmp/K4E6kHY/iRHDvwVmUcDBq/ol8qE0IMz0tGUt3S4u/nnLPChHSHVdksf28xxGq2X+/oWjCIp+YBqJn3qL6V0ASp0bRqp+yXdKLyFM8Swi4If1Jg8MtnC57Roo6rXAWYWUdytEWqAsx4jRBMw=='
                }
            };

            ordersService.getTrucks(config).success(function (data) {
                vm.trucks = data.orders;
            });
        }
    ]);
})();