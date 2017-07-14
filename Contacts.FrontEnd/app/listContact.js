var contactApp = angular.module('contactApp', ['ngRoute']);

contactApp.controller('contactController', ['$scope', '$http', function ($scope, $http) {
    var self = this;

    var uri = 'http://localhost:50691/api/ContactApi';

    var contact = {};

    $http.get(uri)
        .then(function (response) { self.contacts = response.data; })
        ;


    var uriDelete = '/api/ContactApi';
    $scope.deleteFunc = function (contact) {
        $http.delete(uri + '/' + contact.Id).then(function (response) {
            var index = self.contacts.indexOf(contact);
            self.contacts.splice(index, 1);
        });
    };

    var uriEdit = 'http://localhost:50691/api/ContactApi';

}]);

contactApp.controller('contactCreateController', function ($scope, $http, $location) {
    $scope.contact = {};

    var self = this;
    var uriCreate = 'http://localhost:50691/api/ContactApi';

    $scope.create = function () {
        $http.post(uriCreate, $scope.contact).then(
            function (response) {
                $location.path("/");
            });
    };
});

contactApp.controller('contactEditController', function ($http, $routeParams, $location) {
    var self = this;
    $http({
        method: 'GET',
        url: 'http://localhost:50691/api/ContactApi',
        params: { id: $routeParams.id }

    }).then(function (response) {
        self.contact = response.data;
    });



    self.edit = function () {
        $http({
            method: 'PUT',
            url: 'http://localhost:50691/api/ContactApi',
            params: { id: $routeParams.id },
            data: self.contact

        }).then(function (response) {
            $location.url("/");
        });
    };
});

contactApp.controller('messageController', function ($http, $location, $routeParams) {
    var self = this;

    self.send = function (contactId) {
        alert("fd");
        $http({
            method: 'POST',
            url: 'http://localhost:50691/api/MessageApi',
            params: { id: contactId},
            data: self.message
        }).then(function (response) {
            $location.url("/");
        });
        
    };
    
});

contactApp.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);
    $routeProvider
        .when('/', {
            controller: 'contactController',
            templateUrl: 'app/templates/list.html'
        })
        .when('/create', {
            controller: 'contactCreateController',
            templateUrl: 'app/templates/create.html'
        })
        .when('/edit/:id', {
            templateUrl: "app/templates/edit.html",
            controller: "contactEditController"
        })
        .when('/newMessage', {
            controller: 'messageController',
            templateUrl: 'app/templates/newMessage.html'
        });
});

contactApp.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);