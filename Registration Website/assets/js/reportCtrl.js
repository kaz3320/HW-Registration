angular.module('app.controllers', [])
    .controller('adminReportCtrl', function ($scope, $http) {
        $scope.userList = [];

        $http({
            method : "GET",
            url : "http://localhost:55655/Registrations/GetReport"
        }).then(function (response) {
            
            $scope.userList = JSON.parse(response.data);
            var derp = 'e';
        }, function (error) {
            var derp2 = 'e';
        });
});