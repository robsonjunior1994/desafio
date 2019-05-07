// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const uri = "https://localhost:44393/api/item";
let items = null;

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
            url: uri,
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

/* --------------------------------------------------------------------------------------------- */
$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#items");

            $(tBody).empty();
            
            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.type))
                    .append($("<td></td>").text(item.name))
                    .append($("<td></td>").text(item.state))
                    .append($("<td></td>").text(item.year))
                    .append($("<td></td>").text(item.genres))
                    .append($("<td></td>").text(item.description))
                  
                    .append(
                        $("<td></td>").append(
                            $("<button>Emprestar</button>").on("click", function () {
                                emprestarItem(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Pegar</button>").on("click", function () {
                                pegarItem(item.id);
                            })
                        )
                ).append(
                    $("<td></td>").append(
                        $("<a href='#my-top'><button class='editar' >Editar</button></a>").on("click", function () {
                            editItem(item.id);
                        })
                    )
                ).append(
                    $("<td></td>").append(
                        $("<button class='btn-danger'>X</button>").on("click", function () {
                            deleteItem(item.id);
                        })
                    )
                );

                tr.appendTo(tBody);
            });

            items = data;
        }
    });
}

function editItem(id) {
    $.each(items, function (key, item) {
        if (item.id === id) {
            $("#edit-id").val(item.id);
            $("#edit-type").val(item.type);
            $("#edit-name").val(item.name);
            $("#edit-state").val(item.state);
            $("#edit-year").val(item.year);
            $("#edit-genres").val(item.genres);
            $("#edit-description").val(item.description);
        }
    });
    $("#spoiler").css({ display: "block" });
}

$(".my-form").on("submit", function (e) {
    e.preventDefault();

    const item = {
        id: $("#edit-id").val(),
        type: $("#edit-type").val(),
        name: $("#edit-name").val(),
        state: $("#edit-state").val(),
        year: $("#edit-year").val(),
        genres: $("#edit-genres").val(),
        description: $("#edit-description").val()
    };
    console.log(item);
    $.ajax({
        url: uri + "/" + $("#edit-id").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $("#spoiler").css({ display: "none" });
}


function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: function (result) {
            getData();
        }
    });
}
