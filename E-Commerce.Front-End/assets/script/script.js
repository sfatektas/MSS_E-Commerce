$(".navbar-toggle-button").click(function (e) { 
    e.preventDefault();
    $(".mobile-navlink").addClass("navbar-active shadow");
});

$(".navbar-toggle-close").click(function (e) { 
    e.preventDefault();
    $(".mobile-navlink").removeClass("navbar-active shadow");

});

$(".search-open").click(function (e) { 
    e.preventDefault();
    $(".s_pop").css("display", "block");
    $(".s_pop").css("opacity", "1");
});

$(".search-close").click(function (e) { 
    e.preventDefault();
    $(".s_pop").css("display", "none");
    $(".s_pop").css("opacity", "0");
});