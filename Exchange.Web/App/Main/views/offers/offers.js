(function () {
    var controllerId = 'app.views.offers';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.orders', 'abp.services.app.offers', function ($scope, ordersService, offersService) {
            var vm = this;

            vm.orders = [];

            var config = {
                headers: {                    
                    'X-Token': 'Wytekf/t76/wNvYbgDYzr3pVnATXeI3vmbB1QZzOAuSSE69bIDyWM9GdozFkp81H7xFkZPab8vhqacCJbE7qMM/ZQPEEHeqBL4gTrcPj6dfp5B0Ll2Ck9tKDN6sEfcQdrFHFgSR2q56Iw1O6yR0i7D4zhA4zDQZA3L050yv8P1aLK8zydL5LGQCF9tg3RUvXQQLbsIW9I0poRnNVg2Pt9maLd474+SgWjqGAwk2OfrzMGI06Vy6KSf+YYeTZy73CF7EbMYxrT8rn8ZWWRBSliePxCNSvdt5HIJp7En3BBbOHTMHdn5QJy4Cb4CfXsg+59UVsYkL82Ys+SO1bb3DruA=='                    
                }
            };

            getOrders();

            $scope.acceptOffer = function (offer, orderId) {

                var data = {
                    orderId: orderId,
                    id: offer.id
                };

                abp.ui.setBusy(null, offersService.acceptOffer(data, config).success(function () {

                    getOrders();
                    abp.notify.info('Oferta została zaakceptowana!');

                }));

            }

            function getOrders() {
                abp.ui.setBusy(null, ordersService.getUserOrders(config).success(function (data) {
                    vm.orders = data.orders;
                }));
            }
        }
    ]);
})();