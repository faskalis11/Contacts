var app = angular.module('contactApp', ['ngRoute']);

app.controller('contactController', ['$scope', '$http', function ($scope, $http) {
    var self = this;

    var uri = 'http://localhost:50691/api/ContactApi';

    $http.get(uri)
        .then(function (response) { self.contacts = response.data; });


    var uriDelete = '/api/ContactApi';
    $scope.deleteFunc = function (contact) {
        $http.delete(uri + '/' + contact.Id).then(function (response) {
            var index = self.contacts.indexOf(contact);
            self.contacts.splice(index, 1);
        });
    }

    var uriUpdate = '/api/ContactApi';
    $scope.updateFunc = function (contact) {
        $http.put().then(function (response) {
            
        });
    }

    var uriCreate = '/api/ContactApi';
    $scope.createFunc = function (contact) {
        $http.post().then(function (response) {
            self.contacts.appendTo(contact);
        });
    }
}]);

app.config(function ($routeProvider, +) {
    $locationProvider.html5Mode(true);
    $routeProvider.
        when('/', { controller: 'contactController', templateUrl: 'app/templates/list.html' });
});