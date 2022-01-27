/// <reference path="angular.min.js" />
/// <reference path="jquery.signalr-2.4.2.min.js" />


(function () {
    var app = angular.module("chat-app", []);

    app.controller("ChatController", function ($scope, $filter) {
        $scope.name = "ShotoAsha";
        $scope.message = "";
        $scope.messages = [];
        $scope.empChatHub = null;
        $scope.id = null;

        $scope.empChatHub = $.connection.empChatHub;
        $.connection.hub.start();
        $scope.empChatHub.client.broadcastMessage = function (name, message) {
            var newmessage = name + " says  : " + message;
            $scope.messages.push(newmessage);

            $scope.$apply();
        };
        $scope.newMessage = function () {
            $scope.empChatHub.server.sendMessage($scope.name, $scope.message);
            $scope.message = "";
        }

    });

}());