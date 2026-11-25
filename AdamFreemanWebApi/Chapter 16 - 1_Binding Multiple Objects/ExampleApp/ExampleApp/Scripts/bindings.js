var viewModel = ko.observable({ first: 2, second: 5, third: 10, fourth: 100 });
var response = ko.observable("Ready");
var gotError = ko.observable(false);

var sendRequest = function (requestType) {
    $.ajax("/api/bindings/sumnumbers", {
        type: "GET",
        data: {
            "numbers1.first": viewModel().first,
            "numbers1.second": viewModel().second,
            "numbers2.first": viewModel().third,
            "numbers2.second": viewModel().fourth
        },            
        success: function (data) {
            gotError(false);
            response("Total: " + data);
        },
        error: function (jqXHR) {
            gotError(true);
            response(jqXHR.status + " (" + jqXHR.statusText + ")");
        }
    });
};

$(document).ready(function () {
    ko.applyBindings();
});
