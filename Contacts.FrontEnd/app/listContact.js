
var contactApp = angular.module('contactApp', ['ngRoute']);

contactApp.controller('loginController', ['$scope', '$http', function ($scope, $http) {
    $scope.providers = [];
    var self = this;
    var uriLogin = 'http://localhost:50691';
    $scope.searchPattern = "";

    /*$scope.onGoogleLogin = function () {
        $http.get(uriLogin)
            .then(function (response) { self.google = response.data; });
    }*/
    $scope.onGoogleLogin = function () {


        $window.location.href = uriLogin + '/api/loginGoogle';

    };

}]);

contactApp.controller('contactController', ['$scope', '$http', function ($scope, $http) {
    var self = this;

    var uri = 'http://localhost:50691/api/ContactApi';

    var contact = {};
    self.contacts = [];

    self.getContacts = function () {
        $http.get(uri)
            .then(function (response) { self.contacts = response.data; });
    };

    self.getContacts();

    var uriDelete = '/api/ContactApi';

    $scope.deleteFunc = function (contact) {
        $http.delete(uri + '/' + contact.Id).then(function (response) {
            var index = self.contacts.indexOf(contact);
            self.contacts.splice(index, 1);
        });
    };
}]);

contactApp.controller('contactCreateController', function ($scope, $http, $location) {
    var self = this;
    var uriCreate = 'http://localhost:50691/api/ContactApi';


    self.create = function () {
        $http.post(uriCreate, self.contact).then(
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
        $http({
            method: 'POST',
            url: 'http://localhost:50691/api/MessageApi',
            params: { id: contactId },
            data: self.message
        }).then(function (response) {
            $location.url("/");
        });
    };


});

contactApp.controller('messageListController', function ($http, $location) {
    var self = this;
    var uri = 'http://localhost:50691/api/MessageApi';

    $http.get(uri)
        .then(function (response) { self.messages = response.data; });

    var contacts = {};

    //get meail, name
    
});


contactApp.config(function ($routeProvider, $locationProvider, $httpProvider) {
    $locationProvider.html5Mode(true);
    $httpProvider.defaults.withCredentials = true;

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
        })
        .when('/messageList', {
            controller: 'messageListController',
            templateUrl: 'app/templates/messageList.html'
        }).when('/login', {
            controller: 'loginController',
            templateUrl: 'app/templates/login.html'
        });

});

contactApp.service('authInterceptor', function ($q) { //custom interceptorius
    var service = this;

    service.responseError = function (response) {
        if (response.status === 401) {
            window.location = "/login";
        }
        if (response.status === 302) {
            window.location = "/login";
        }
        return $q.reject(response);
    };
});

contactApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptor');
});


// http://localhost:50712/login
//contactApp.config(['$qProvider', function ($qProvider) {
//    $qProvider.errorOnUnhandledRejections(false);
//}]);