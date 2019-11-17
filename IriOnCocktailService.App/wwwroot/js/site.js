// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

const serverResponseHandler = (serverData) => {
    if (serverData) {
        $('#put-the-bars-here').html(serverData);
        $("#bar-partial").hide();
        $("#cocktail-partial").hide();
    }
};

$('#search-text').on('keyup', function () {
    console.log($(this).val());
});

$('#load-button').click(function () {
    const searchText = $('#search-text').val();
    $.get('/Home/Bars?name=' + searchText, serverResponseHandler);
});