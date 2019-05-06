// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    $('#form').bind('submit', function (e) {

        let item = {
            type: $("#type").val(),
            name: $("#name").val(),
            state: $("#state").val(),
            year: $("#year").val(),
            genres: $("#genres").val(),
            description: $("#description").val()
        };

        e.preventDefault();
        console.log(item);

        $.ajax({
            url: "https://localhost:44393/api/item",
            type: 'POST',
            contentType: "application/json",
            data: JSON.stringify(item),
            dataType: 'json',
            success: function(item) {
                console.log(item);
            },
            error: function (item) {
                console.log("Falhou");
            }

        });
    });
});