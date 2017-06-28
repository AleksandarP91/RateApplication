var app = angular.module('RateApp', ['ui.bootstrap']);
app.controller('RateCtrl', function ($scope, $http) {
    $http.get("/api/values")
        .then(function (response) {
            $scope.skills = response.data;
        });

    $scope.addSkill = function () {
        var skill = {
            Name: $scope.skillName,
            Level: $scope.skillLevel
        };
        
       $http.post(
            "/api/values",
            skill,
            {
                headers: {
                   'Content-Type': 'application/json'
               }
            }).then(function (response) {
           $scope.skills = response.data;
       });
    };

    $scope.delete = function (data) {
        var skill = {
            Name: data.Name,
            Level: data.Level
        };

        $http({
            method: 'DELETE',
            url: '/api/values',
            data: skill,
            headers: {
                'Content-type': 'application/json;charset=utf-8'
            }
        }).then(function (response) {
              $scope.skills = response.data;
           });
        
    }

    $scope.changeLevel = function (data, modifiedLevel) {
        var skill = {
            Name: data.Name,
            Level: data.Level
        };
        $http({
            method: 'PUT',
            url: '/api/values',
            data: skill,
            headers: {
                'Content-type': 'application/json;charset=utf-8'
            },
            params: {modifiedLevel: modifiedLevel},

        }).then(function (response) {
            $scope.skills = response.data;
            });

           }
});
