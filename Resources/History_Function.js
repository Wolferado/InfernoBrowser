$(function () {
    $('.wmd-view-topscroll').on('scroll', function (e) {
        $('.wmd-view').scrollLeft($('.wmd-view-topscroll').scrollLeft());
    }); 
    $('.wmd-view').on('scroll', function (e) {
        $('.wmd-view-topscroll').scrollLeft($('.wmd-view').scrollLeft());
    });
});
$(window).on('load', function (e) {
    $('.container').width( $('.historyList')[0].scrollWidth)
    $('.scroll-div').width( $('.historyList')[0].scrollWidth)
});