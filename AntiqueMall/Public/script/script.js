$(document).ready(function () {

    $(".menu_b").click(function () {
        $(".swipe").css({ "left": "0px", "transition": "0.5s" })
    })
    $(".close").click(function () {
        $(".swipe").css({ "left": "-285px", "transition": "0.5s" })
    })

    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $(".scrollup").fadeIn();
        } else {
            $(".scrollup").fadeOut();
            return false;
        }
    });



    $('.scrollup').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
        $(this).css({ "color": "white" })
        return false;
    });
    // Accord
    $(".registr_c").click(function () {

        $(".registr_page").fadeIn(400);

    })
    $(".login_c").click(function () {

        $(".login_page").fadeIn(400);
    })
    $(".question").click(function () {
        $(".login_page").fadeOut();
        $(".reset_page").fadeIn(400);
    })
    $(".close_r").click(function () {
        $(".registr_page").fadeOut(400);
        $(".login_page").fadeOut(400);
        $(".reset_page").fadeOut(400);
        $(".search_page").fadeOut(400);
        $(".compare").fadeOut();
    })
    $(".log").click(function () {
        $(".reset_page").fadeOut();
        $(".login_page").fadeIn(400);
    })
    $(".reg_p").click(function () {
        $(".reset_page").fadeOut();
        $(".registr_page").fadeIn(400);
    })
    $(".f_login").click(function () {
        $(".registr_page").fadeOut();
        $(".login_page").fadeIn(400);
    })
    $(".signin").click(function () {
        $(".login_page").fadeIn(400);
    })
    $(".f_register").click(function () {
        $(".login_page").fadeOut();
        $(".registr_page").fadeIn(400);
    })
    $(".pencile").click(function () {
        $(".registr_page").fadeIn(400);
    })
    $(".sres_hide").click(function () {
        $(".search_page").fadeIn(400);
    })
    $(".s_search").click(function () {
        $(".search_page").fadeIn(400);
    })
    $(window).click(function (event) {
        if (event.target.className == "registr_page" || event.target.className == "login_page" || event.target.className == "reset_page" || event.target.className == "search_page"){
            $(".registr_page").fadeOut(500);
            $(".login_page").fadeOut(500);
            $(".reset_page").fadeOut(500);
            $(".search_page").fadeOut(500);
        }

    });
    //-----------Login------------------//
    $("#log").click(function () {
        var username = $(".username").val();
        var password = $(".password").val();
       
        if (username != null && password != null) {
            $.ajax({
                type: "Get",
                data: {
                    pass: password,
                    use: username,
                },
                url: "http://localhost:51618/Main/CheckLog",
                contentType: "Html",
                success: function (re) {
                    return JavaScript("location.reload(true)");
                }
            })  
        }
            $(".hidden_p").show();
    })
    
    // ----------------------------compare----------------------------------
   
    $(".fCompare").click(function () {
        $(".compare").fadeIn();
        return false;
    })
    $(window).click(function (event) {
        if (event.target.className == "compare") {
            $(".compare").fadeOut(500);
            $(".quickview").fadeOut();
        }
    });
    $(window).click(function (event) {
        if (event.target.className == "quickview") {
            $(".quickview").fadeOut(500);
        }
    });
    $(".close_r").click(function () {
        $(".compare").fadeOut();
        $(".quickview").fadeOut();
    })
    
    $(".fCompare").click(function () {
        var a = $(this).attr("dataset");
        $.ajax({
            type: "Get",
            data: {
                prod: a,
            },
            url: "http://localhost:51618/Main/Home1/",
            contentType: "Html",
            success: function (res) {
                $("#choos").html(res)
            }

        })
    })
    
    $(".removeV").click(function () {
        $(".visibleBox").hide();
        $(".visLeft").hide();
        $(".noproduct").fadeIn(400);
    })
    //-----------------item adding-----------------------//
    $(".addItem").click(function () {
        var a = $(this).attr("dataset");
        $.ajax({
            type: "Get",
            data: {
                prod: a,
            },
            url: "http://localhost:51618/Main/itemAdd/",
            contentType: "Html",
            success: function (res){
                $("#add").append(res)
                $(".wishlistBox").fadeIn().fadeOut(900).css({"z-index":"9999"});
                $(".itemB p").css({ "display": "none" }); 
                $(".main").css({ "display": "block" });
                $(".itemB").css({ "opacity": "1" });
                
            }
        })
       
        if ($(".static").text().length >=0) {
            $(".main").prev().children().css({ "display": "none" })
            $(".main").next().children().css({ "display": "none" })
        }
    });
    $(".addItem").click(function () {
        var a = $(this).attr("dataset");
        $.ajax({
            type: "Get",
            data: {
                prod: a,
            },
            url: "http://localhost:51618/Main/ViewCart/",
            contentType: "Html",
            success: function (res) {
                $("#addView").append(res);
                
            }
        })
        return false;
    });
 
    var index = $(".main").length;
    $(".wishlist").click(function () {
        index++;
        $(".itemNumber").length += index;
        return false;
    })
    $(window).scroll(function () {
      $(".wishlistBox").hide(100);
    })
   
  
    $(".fQuickview").click(function () {
        $("#Selec").fadeIn();
        return false;

    })
    
    //---------------------------------------- resize function--------------------------------//
    function sliderInit() {
        slideC = $(".slide_c img").width($(".slider").width());
        newwidth = $(".slide_c").width();
        slideC = newwidth;
        smallwidth = $(".slide_s").width();
        length = $(".slide_in").children().length;
        smallength = $(".slide_small").children().length;
        prev = 0; margin = 0;
        small = 0; swipe = 0; prev_b = 0;
        slideB = $(".slide_b img").width($(".hide_b").width());
        bwidth = $(".slide_b").width();
        slideB = bwidth;
        blength = $(".res_b").children().length;
        slideS = $(".f_small").width(550);
    }
    sliderInit();
    $(window).on('resize', function () {

        sliderInit();
    })
    //---------------------------------------- resize function--------------------------------

    //--------------------------------next click function----------------------------------
    $("#next").click(function () {
        prev++;
        margin += newwidth;
        small += smallwidth;

        if (prev >= length) {
            margin = newwidth * (length - 1);
            small = smallwidth * (smallength - 1);
            prev = length;
            $(".big_box").css({ "visibility": "visible" });
            return false;
            $(".slide_s:last-child").addClass("actives")
        }
        $(".slide_c img").css({ "margin-left": -margin, "transition": "0.3s ease" })
        $(".slide_small").css({ "margin-left": -small, "transition": "0.3s ease" })
        $(".slide_s.actives").removeClass("actives").next(".slide_s").addClass("actives");
        return false;
    })
    //----------------------------next click function----------------------------------
    $(window).click(function (event) {
        if (event.target.className == "big_box") {
            $(".big_box").css({ "visibility": "hidden" });
            $("html").css({ "overflow": "scroll" });
        }
    });
    //------------------next_click function-------------------------
    function nextb_click() {
        prev_b++;
        swipe += bwidth;
        if (prev_b >= blength) {
            swipe = 0;
            prev_b = 0
        }
        $(".slide_b img").css({ "margin-left": -swipe })
    }
    function prevb_click() {
        prev_b--;
        swipe -= bwidth;
        if (prev_b <= 0) {
            swipe = bwidth * (blength - 1);
            prev_b = blength;
        }
        $(".slide_b img").css({ "margin-left": -swipe })

    }
    //-------------------------- b slide--------------------------
    $(".slide_b img").click(function () {
        nextb_click();
    })
    $("#next_b").click(function () {
        nextb_click();
        return false;

    })
    $("#prev_b").click(function () {
        prevb_click()
        return false;

    })
    //------------------------ b slide--------------------------------

    //---------------------------- prev click-----------------------------
    $("#prev").click(function () {
        prev--;
        margin -= newwidth;
        small -= smallwidth;
        if (prev <= 0) {
            $(".slide_s:first-child").addClass("actives")
            margin = 0;
            small = 0;
            prev = 0;

            $(".big_box").css({ "visibility": "visible" });
     

        }
        $(".slide_c img").css({ "marginLeft": -margin, "transition": "0.3s ease" })
        $(".slide_small").css({ "margin-left": -small, "transition": "0.3s ease" })
        $(".slide_s.actives").removeClass("actives").prev(".slide_s").addClass("actives");
        return false;

    })
    //---------------------------- prev click-----------------------------
    //window click function
    $(window).click(function (event) {
        if (event.target.className == "big_box") {
            $(".big_box").css({ "visibility": "hidden" });
            $("html").css({ "overflow": "scroll" });
        }
    });



    $(".slide_s img").click(function () {
        prev++;
        margin += newwidth;
        small += smallwidth;
        var source = $(this).attr('src');

        if (prev >= length) {
            margin = newwidth * 4;
            small = smallwidth * 4;
            prev = length;
            $(".slide_small:last-chid").addClass("actives")
        }
        var slidesmall = $(".slide_small").index();

        $(".slide_c img").css({ "marginLeft": -margin, "transition": "0.3s ease" });
        $(".slide_small").css({ "margin-left": -small, "transition": "0.3s ease" });
        $(".slide_s.actives").removeClass("actives").next(this).addClass("actives");
    });
    $('.foldable .sec_li').click(function () {
        if ($('.sec_act').css({ 'display': 'none' })) {
            $(this).css({ 'border-top': '1px solid #993816' })
            $(".foldable .active_li").css({ "border-top": "none" })
            $('.active').slideUp();
            $('.sec_act').slideDown();
        }
        else {
            $(".foldable .active_li").css({ "border-top": "1px solid #993816" })
            $('.active').slideDown();
            $('.sec_act').slideUp();
        }
    })
    $('.foldable .sec_li').click(function () {
        if ($('.sec_act').css({ 'display': 'none' })) {
            $(this).css({ 'border-top': '1px solid #993816' })
            $(".foldable .active_li").css({ "border-top": "none" })
            $('.active').slideUp();
            $('.sec_act').slideDown();
        }
        else {
            $(".foldable .active_li").css({ "border-top": "1px solid #993816" })
            $('.active').slideDown();
            $('.sec_act').slideUp();
        }
    })
    $('.foldable .active_li').click(function () {
        if ($('.active').css({ 'display': 'none' })) {
            $(this).css({ 'border-top': '1px solid #993816' })
            $(".foldable .sec_li").css({ "border-top": "none" })
            $('.active').slideDown();
            $('.sec_act').slideUp();
        }
        else {
            $(".foldable .sec_li").css({ "border-top": "1px solid #993816" })
            $('.sec_act').slideDown();
            $('.active').slideUp();
        }
    })


    $(".sech").click(function () {
        $(".sech.active").removeClass("active");
        $(this).addClass("active").siblings().removeClass("active")
        return false;
    })

    $(".sechb").click(function () {
        $(".sechb.active").removeClass("active");
        $(this).addClass("active").siblings().removeClass("active")
        return false;
    })

    $("#all").click(function () {
        $(".paddg").css({ "display": "none" });
        $(".paddg.all").css({ "display": "block" });
        $(".sech").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })
    $("#vase").click(function () {
        $(".paddg").css({ "display": "none" });
        $(".paddg.vase").css({ "display": "block" });
        $(".sech").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })
    $("#clock").click(function () {
        $(".paddg").css({ "display": "none" });
        $(".paddg.clock").css({ "display": "block" });
        $(".sech").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })
    $("#tableware").click(function () {
        $(".paddg").css({ "display": "none" });
        $(".paddg.tableware").css({ "display": "block" });
        $(".sech").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })
    $("#paintings").click(function () {
        $(".paddg").css({ "display": "none" });
        $(".paddg.paintings").css({ "display": "block" });
        $(".sech").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })

    $("#allb").click(function () {
        $(".paddgb").css({ "display": "none" });
        $(".paddgb.allb").css({ "display": "block" });
        $(".sechb").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })
    $("#vaseb").click(function () {
        $(".paddgb").css({ "display": "none" });
        $(".paddgb.vaseb").css({ "display": "block" });
        $(".sechb").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })
    $("#clockb").click(function () {
        $(".paddgb").css({ "display": "none" });
        $(".paddgb.clockb").css({ "display": "block" });
        $(".sechb").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })
    $("#tablewareb").click(function () {
        $(".paddgb").css({ "display": "none" });
        $(".paddgb.tablewareb").css({ "display": "block" });
        $(".sechb").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })
    $("#paintingsb").click(function () {
        $(".paddgb").css({ "display": "none" });
        $(".paddgb.paintingsb").css({ "display": "block" });
        $(".sechb").css({ "overflow": "visible" })
        $(this).css({ "overflow": "hidden" })
    })


$(".secondRadio").click(function(){
    $(".firstRadio").prop( "checked", false );
    $(this).prop( "checked", true );
    $(".radiop").css({"display":"none"})
    $(".latestP").css({"display":"block"})
})
$(".firstRadio").click(function(){
    $(".secondRadio").prop( "checked", false );
    $(this).prop( "checked", true );
    $(".radiop").css({"display":"block"})
    $(".latestP").css({"display":"none"})
})
 var click=true;
$(".click_f_login").click(function(){
if(click){
    $(".activeLogin").fadeIn(270);
    click=false;
}
else{
    $(".activeLogin").fadeOut(1);
    click=true;
} 
})
$(".code").click(function(){
if(click){
    $(".sec_act").fadeIn(270);
    click=false;
}
else{
    $(".sec_act").fadeOut(1);
    click=true;
} 
})

$(".checkB").click(function(){
    if(click){
        $(".largeB_Info").css({"display":"block"})
        click=false;
    }
    else{
        $(".largeB_Info").css({"display":"none"})
        click=true;
    }
  
})
    $("#plus").click(function () {
        var value = $("#number").val();
        value++;
        $("#number").val(value);
    });

    $("#minus").click(function () {
        var value = $("#number").val();
        value--;
        $("#number").val(value);
        if ($("#number").val() <= 1) {

            $("#number").val(1);

        }
    });
   images = document.querySelectorAll('#slider .slider_in')
    var index = 0;
    function reset() {
        for (i = 0; i < images.length; i++) {
            images[i].style.display = "none";
        }

    }
    function startslide() {
        reset();
        images[0].style.display = "block"
        $("#slider .text p").css({ "animation-name": "lightSpeedIn", "animation-duration": "1s" })
        $("#slider .text .matrix").css({ "visibility": "visible", "transform": "translateY(30%)", "transition": "150s", })
        $("#slider .text li:nth-child(1)").css({ "transform": "rotate(0deg)", "transition": "1s", })
        $("#slider .text li:nth-child(2)").css({ "transform": "rotate(0deg)", "transition": "1.02s", })
        $("#slider .text li:nth-child(3)").css({ "transform": "rotate(0deg)", "transition": "1.04s", })
        $("#slider .text li:nth-child(4)").css({ "transform": "rotate(0deg)", "transition": "1.05s", })
        $("#slider .text li:nth-child(5)").css({ "transform": "rotate(0deg)", "transition": "1.07s", })
        $("#slider .text li:nth-child(6)").css({ "transform": "rotate(0deg)", "transition": "1.09s", })
        $("#slider .text li:nth-child(7)").css({ "transform": "rotate(0deg)", "transition": "1.11s", })
        $("#slider .text li:nth-child(8)").css({ "transform": "rotate(0deg)", "transition": "1.13s", })
        $("#slider .text li:nth-child(9)").css({ "transform": "rotate(0deg)", "transition": "1.15s", })
        $("#slider .text li:nth-child(10)").css({ "transform": "rotate(0deg)", "transition": "1.17s", })
        $("#slider .text li:nth-child(11)").css({ "transform": "rotate(0deg)", "transition": "1.19s", })
        $("#slider .text li:nth-child(12)").css({ "transform": "rotate(0deg)", "transition": "1.21s", })
        $("#slider .text li:nth-child(13)").css({ "transform": "rotate(0deg)", "transition": "1.23s", })
        $("#slider .text li:nth-child(14)").css({ "transform": "rotate(0deg)", "transition": "1.25s", })
        $("#slider .text li:nth-child(15)").css({ "transform": "rotate(0deg)", "transition": "1.27s", })
        $("#slider .text li:nth-child(16)").css({ "transform": "rotate(0deg)", "transition": "1.29s", })
        $("#slider .text li:nth-child(17)").css({ "transform": "rotate(0deg)", "transition": "1.31s", })
        $("#slider .text li:nth-child(18)").css({ "transform": "rotate(0deg)", "transition": "1.29s", })
        $("#slider .text li:nth-child(19)").css({ "transform": "rotate(0deg)", "transition": "1.31s", })
       
    }
    setInterval(function () {
        if (index == images.length - 1) {
            index = -1;
        }
        reset();
        images[index + 1].style.display = "block";
        index++;
        $("#slider .text p").css({ "animation-name": "lightSpeedIn", "animation-duration": "1s" })
        $("#slider .text .matrix").css({ "visibility": "visible", "transform": "translateY(30%)", "transition": "15s", })
        $("#slider .text li:nth-child(1)").css({ "transform": "rotate(0deg)", "transition": "1s", })
        $("#slider .text li:nth-child(2)").css({ "transform": "rotate(0deg)", "transition": "1.02s", })
        $("#slider .text li:nth-child(3)").css({ "transform": "rotate(0deg)", "transition": "1.04s", })
        $("#slider .text li:nth-child(4)").css({ "transform": "rotate(0deg)", "transition": "1.05s", })
        $("#slider .text li:nth-child(5)").css({ "transform": "rotate(0deg)", "transition": "1.07s", })
        $("#slider .text li:nth-child(6)").css({ "transform": "rotate(0deg)", "transition": "1.09s", })
        $("#slider .text li:nth-child(7)").css({ "transform": "rotate(0deg)", "transition": "1.11s", })
        $("#slider .text li:nth-child(8)").css({ "transform": "rotate(0deg)", "transition": "1.13s", })
        $("#slider .text li:nth-child(9)").css({ "transform": "rotate(0deg)", "transition": "1.15s", })
        $("#slider .text li:nth-child(10)").css({ "transform": "rotate(0deg)", "transition": "1.17s", })
        $("#slider .text li:nth-child(11)").css({ "transform": "rotate(0deg)", "transition": "1.19s", })
        $("#slider .text li:nth-child(12)").css({ "transform": "rotate(0deg)", "transition": "1.21s", })
        $("#slider .text li:nth-child(13)").css({ "transform": "rotate(0deg)", "transition": "1.23s", })
        $("#slider .text li:nth-child(14)").css({ "transform": "rotate(0deg)", "transition": "1.25s", })
        $("#slider .text li:nth-child(15)").css({ "transform": "rotate(0deg)", "transition": "1.27s", })
        $("#slider .text li:nth-child(16)").css({ "transform": "rotate(0deg)", "transition": "1.29s", })
        $("#slider .text li:nth-child(17)").css({ "transform": "rotate(0deg)", "transition": "1.31s", })
        $("#slider .text li:nth-child(18)").css({ "transform": "rotate(0deg)", "transition": "1.29s", })
        $("#slider .text li:nth-child(19)").css({ "transform": "rotate(0deg)", "transition": "1.31s", })
    }, 8500);
    startslide();
    $(".right_icon").click(function () {
        if (index == images.length - 1) {
            index = -1;
        };
        reset();
        images[(index + 1)].style.display = "block"
        index++;

    });
    $(".left_icon").click(function () {

        if (index == 0) {
            index = images.length;
        }
        reset();
        images[index - 1].style.display = "block"
        index--;

    });



});
var btn = document.getElementsByClassName("click_btn");
var a;
var up = document.getElementsByClassName("up");
var down_i = document.getElementsByClassName("down");
for (a = 0; a < btn.length; a++) {
    btn[a].addEventListener("click", function () {
        var down = this.nextElementSibling;
        if (down.style.display == "block") {
            down.style.display = "none";
            down_i.style.display = "none"
            up.style.display = "block"
        } else {
            down.style.display = "block";
            up.style.display = "block"
            down_i.style.display = "none"
        }
    });
}



