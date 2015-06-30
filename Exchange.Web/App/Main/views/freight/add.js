(function () {
    var controllerId = 'app.views.freight.add';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.orders', function ($scope, ordersService) {
            var vm = this;
            
            $scope.car_body = "Plandeka";
            $scope.capacity = 1.0;
            $scope.length = 1.0;
            $scope.price = 100;
            $scope.currency = "PLN";
            $scope.visibility = "all";
            $scope.partial = false;

            $scope.country_from = "PL";
            $scope.city_from = "(30-072) Kraków";
            $scope.loading_date = "";

            $scope.country_to = "PL";
            $scope.city_to = "(39-200) Dębica";
            $scope.unloading_date = "";
            
            $scope.submit = function () {

                var loading = new Date($scope.loading_date);
                var unloading = new Date($scope.unloading_date);

                if (loading > unloading) {
                    abp.notify.error('Data załadunku musi poprzedzać datę rozładunku!');
                }
                else {

                    var config = {
                        headers: {
                            'X-Token': 'Wytekf/t76/wNvYbgDYzr3pVnATXeI3vmbB1QZzOAuSSE69bIDyWM9GdozFkp81H7xFkZPab8vhqacCJbE7qMM/ZQPEEHeqBL4gTrcPj6dfp5B0Ll2Ck9tKDN6sEfcQdrFHFgSR2q56Iw1O6yR0i7D4zhA4zDQZA3L050yv8P1aLK8zydL5LGQCF9tg3RUvXQQLbsIW9I0poRnNVg2Pt9maLd474+SgWjqGAwk2OfrzMGI06Vy6KSf+YYeTZy73CF7EbMYxrT8rn8ZWWRBSliePxCNSvdt5HIJp7En3BBbOHTMHdn5QJy4Cb4CfXsg+59UVsYkL82Ys+SO1bb3DruA=='
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
                        Type: 'Ładunek'
                    };

                    abp.ui.setBusy(null,
                    ordersService.addOrder(data, config).success(function () {
                        abp.notify.info('Dodano nowy ładunek!');
                    }));

                }
                
            };
        }
    ]);
})();