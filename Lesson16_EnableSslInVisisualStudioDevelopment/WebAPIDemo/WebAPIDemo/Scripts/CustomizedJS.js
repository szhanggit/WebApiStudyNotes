$(document).ready(function () {
    var ulEmployees = $('#ulEmployees');
    $('#btn').click(function () {
        $.ajax({
            type: 'GET',
            url: "api/employees/",
            dataType: 'json',
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