
var uri = '/api/ContactApi';

$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem(item) }).appendTo($('#contacts'));
            });
        });
});

function formatItem(item) {
    return item.Name + ' ' + item.Phone + ' ' + item.Email;
}

var app = angular.module('contactApp', []);
app.controller('contactController', function ($scope, $http) {
    var self = this;

    $http.get(uri)
        .then(function (response) { self.contacts = response.data; });


    var uriDelete = '/api/ContactApi'
    $scope.deleteFunc = function (contact) {
        $http.delete(uriDelete + '/' + contact.Id).then(function (response) {
            var index = self.contacts.indexOf(contact);
            self.contacts.splice(index, 1);
        });
    }

    var uriUpdate = '/api/ContactApi'
    $scope.updateFunc = function (contact) {
        $http.put().then(function (response) {
            
        });
    }

    var uriCreate= '/api/ContactApi'
    $scope.createFunc = function (contact) {
        $http.post().then(function (response) {
            
        });
    }
});



