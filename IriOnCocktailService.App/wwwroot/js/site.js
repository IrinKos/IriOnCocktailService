// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//$(document).ready(function () {
//    $('.js-example-basic-multiple').select2();
//});

//$("#e2").select2();

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

const barServerResponseHandler = (serverData) => {
    if (serverData) {
        $('#put-the-bars-here').html(`<h1 class="text-center bg-black mb-5">Serached Bars!</h1>` + serverData);
        $("#bar-partial").hide();
        $("#cocktail-partial").hide();
        //$("#hide-bars").hide();
    }
};

const cocktailServerResponseHandler = (serverData) => {
    if (serverData) {
        $('#put-the-cocktails-here').html(`<h1 class="text-center bg-black mt-5">Serached Cocktails!</h1>` + serverData);
        $("#bar-partial").hide();
        $("#cocktail-partial").hide();
    }
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

//function moreInfo() {
//    $('#more-info').show()
//}


//$('#show-comments').click(function () {
//    console.log('zaredi se be')
//    $('#show-comments').hide()
//    $('#hide-comments').removeAttr('style')
//    $('#div-comments').removeAttr('style')
//});

//$('#show-comments').click(function () {
//    const url = $(this).attr('formaction');

//    const commentContainer = $('div-comments');

//    commentContainer.html(`<div class="spinner-border text-success" role="status">
//        <span class="sr-only">Loading...</span>
//    </div>`);

//    $.get(url, function (partialFromTheServerAsAsyncResponse) {
//        reviewContainer.html(partialFromTheServerAsAsyncResponse);
//    });
//})

//$("#comment").click(function () {
//    $.get('/Bar/GetComments', serverResponseHandler());
//});

//const serverResponseHandler = function (serverData) {
//    console.log(serverData);
//}