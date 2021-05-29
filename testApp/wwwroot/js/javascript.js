// The function for scrolling smoothly for a button to specific section

$(function() {
    $('a[href*=\\#]:not([href=\\#])').on('click', function() {
        var target = $(this.hash);
        target = target.length ? target : $('[name=' + this.hash.substr(1) +']');
        if (target.length) {
            $('html,body').animate({
                scrollTop: target.offset().top
            }, 1000);
            return false;
        }
    });
});




// The function to scroll the menu from the side
var navLinks = document.getElementById("navlinks");
        function showMenu(){
            navLinks.style.right = "0";
        }
        function hideMenu(){
            navLinks.style.right = "-200px";
           

            
        }
// the button properties that hide and show the content
        $(document).ready(function(){
            $('#btnFadeOut').click(function(){
                $('#sdsu_info').fadeOut()
            });
        });
        $(document).ready(function(){
            $('#btnFadeIn').click(function(){
                $('#sdsu_info').fadeIn()
            });
        });
        $(document).ready(function(){
            $('#btnFadeTog').click(function(){
                $('#sdsu_info').fadeToggle()
            });
        });




        // make buttons to dissapear the content and the make functions for them to reappear
$(function(){
    $('.cs p').css("color","white");
})
$(function(){
    $('.cs p').fadeOut('fast');
});
$(function(){
    $('.compe p').fadeOut('fast');
});
$(function(){
    $('.ee p').css("color","white");
})
$(function(){
    $('.ee p').fadeOut('fast');
});
$(function(){
    $('.be p').fadeOut('fast');
});
$(function(){
    $('.smt p').fadeOut('fast');
});


        $(document).ready(function(){
            $('#csbtn').click(function(){
                var x = $(this).text();
                if(x=="Expand"){
                    $('.cs p ').fadeToggle();
                    $(this).text("Anti-Expand");
                }
                else{
                    $(this).text("Expand");
                     $('.cs p ').fadeToggle();
                }

            });

        });
        $(document).ready(function(){
            $('#compebtn').click(function(){
                var x = $(this).text();
                if(x=="Expand"){
                    $('.compe p ').fadeToggle();
                    $(this).text("Anti-Expand");
                }
                else{
                    $(this).text("Expand");
                     $('.compe p ').fadeToggle();
                }
            });
        });
        $(document).ready(function(){
            $('#eebtn').click(function(){
                var x = $(this).text();
                if(x=="Expand"){
                    $('.ee p ').fadeToggle();
                    $(this).text("Anti-Expand");
                }
                else{
                    $(this).text("Expand");
                     $('.ee p ').fadeToggle();
                }
            });
        });
        $(document).ready(function(){
            $('#bebtn').click(function(){
                var x = $(this).text();
                if(x=="Expand"){
                    $('.be p ').fadeToggle();
                    $(this).text("Anti-Expand");
                }
                else{
                    $(this).text("Expand");
                     $('.be p ').fadeToggle();
                }
            });
        });
        $(document).ready(function(){
            $('#smtbtn').click(function(){
                var x = $(this).text();
                if(x=="Expand"){
                    $('.smt p ').fadeToggle();
                    $(this).text("Anti-Expand");
                }
                else{
                    $(this).text("Expand");
                     $('.smt p ').fadeToggle();
                }
            });
        });
        