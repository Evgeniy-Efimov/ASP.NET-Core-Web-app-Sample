// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('input.datepicker').each(function () {
    $(this).datepicker({
        dateFormat: 'dd.mm.yy',
        changeYear: true
    });
});

$('.clear').click(function (event) {
    event.preventDefault();
    $(this).closest('form')
        .find('input')
        .each(function () {
            $(this).val('');
        });
    $(this).closest('form')
        .find('select')
        .each(function () {
            $(this).val('');
        });
});

function ShowLoader() {
    $('input').blur();
    $('select').blur();
    $('#loader').show();
};

$('.search').click(function () {
    ShowLoader();
});

$('.pages ul li button').click(function () {
    ShowLoader();
});

function HighlightActiveNavbarLink(title) {
    if (title) {
        $('.nav-item[title="' + title + '"] a').addClass('active');
    }        
};