angular.module('app.controllers', [])
    .controller('adminReportCtrl', function ($scope, $http) {
        $scope.userList = [];

        $http({
            method : "GET",
            url : "http://68.34.110.240:3002/Registrations/GetReport"
        }).then(function (response) {
            
            $scope.userList = JSON.parse(response.data);
        }, function (error) {
        });
});