$(window).scroll(function () {
    if ($(this).scrollTop() > 250) {
        $('#BreakingNewsNav').hide(500);
    }
    else {
        $('#BreakingNewsNav').show(500);
    }
});