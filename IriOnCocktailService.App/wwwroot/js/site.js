// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
$(document).ready(function () {
    $('.js-example-basic-multiple').select2();
});
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

const barServerResponseHandler = (serverData) => {
    //console.log(serverData);
    if (serverData) {
        $('#put-the-bars-here').html(`<h1 class="text-center bg-black mb-5">Serached Bars!</h1>` + serverData);
        //$('#put-the-cocktails-here').html(serverData);
        $("#bar-partial").hide();
        $("#cocktail-partial").hide();
    }
};

const cocktailServerResponseHandler = (serverData) => {
    //console.log(serverData);
    if (serverData) {
        //$('#put-the-bars-here').html(serverData);
        $('#put-the-cocktails-here').html(`<h1 class="text-center bg-black mt-5">Serached Cocktails!</h1>` + serverData);
        $("#bar-partial").hide();
        $("#cocktail-partial").hide();
    }
    //serverData = '<h3 class="text-center bg-white text-black-50">No cocktails found!</h3>'
    //$('#put-the-cocktails-here').html(`<h1 class="text-center bg-black mt-5">Serached cocktails!</h1>` + serverData);
};

$('#search-text').on('keyup', function () {
    console.log($(this).val());
});

$('#load-button').click(function () {
    const searchText = $('#search-text').val();
    $.get('/Home/Bars?name=' + searchText, barServerResponseHandler);
    $.get('/Home/BarsAddress?address=' + searchText, barServerResponseHandler);
    $.get('/Home/Cocktails?name=' + searchText, cocktailServerResponseHandler);
    $.get('/Home/CocktailsIngredients?ingredient=' + searchText, cocktailServerResponseHandler);
});