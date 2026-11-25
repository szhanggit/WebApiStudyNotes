$(document).ready(function () {
    var ulEmployees = $('#ulEmployees');
    $('#btn').click(function () {
        $.ajax({
            type: 'GET',
            url: "http://localhost:14746/api/employees/",
            dataType: 'json',
            headers: { 'Accept': 'application/json' },
            success: function (data) {
                ulEmployees.empty();
                $.each(data, function (index, val) {
                    var fullName = val.FirstName + ' ' + val.LastName;
                    ulEmployees.append('<li>' + fullName + '</li>');
                });
            }
        });
    });
    $('#btnClear').click(function () {
        ulEmployees.empty();
    });
});