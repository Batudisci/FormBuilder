var url = window.location.pathname;
var segments = url.split('/');
var value = segments[segments.length - 1];

angular.module('form', [])
    .controller('formController', function ($scope, $http) {
        var form = this;
        form.id = value
        $http.get(`/Form/GetFormsById/${form.id}`, { withCredentials: true }).then((res) => {
            form.data = JSON.parse(res.data)
            console.log(form.data)
        })
    })

    