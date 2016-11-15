var app = angular.module("tweet", []);

app.controller("RegisterCtrl", [$scope, $http], function ($scope, $http){

    var checkUsername = function (username, method){

        return $http({
            url: "/api/TwitUsername/5",
            method: "GET"
        })
    } 

})