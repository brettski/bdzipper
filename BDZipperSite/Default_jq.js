$(function() {
    var yOff = -20;
    var xOff = 40;
    var html = '<div id="info">';
        html += '<h4>First 512 Characters</h4></div>';
    var hiConfig = {
        sensitivity: 3,
        interval: 200,
        timeout: 0,
        over: function(e) {
                var itext = $(this).text();
                //console.log(itext);
                $('body').append(html).children('#info').hide().fadeIn(500);
                $('<div id="info2" />').load('ReadTextFile.aspx', {filename:itext}, 
                    function() { $(this).appendTo('#info');
                    }
                );
                $('#info').css('top', e.pageY + yOff).css('left', e.pageX + xOff);
              },
        out: function() { $('#info').remove(); }
        }
    $('label').hoverIntent(hiConfig)
    
    $('label').mousemove(function(e) {
        $('#info').css('top', e.pageY + yOff).css('left', e.pageX + xOff);
    });
});
//    $('a').hover(function(e) {
//            $('body').append(html).children('#info').hide().fadeIn(500);
//            $('<div id="info2" />').load('ReadTextFileX.aspx', function() {
//                $(this).appendTo('#info');
//            });
//            $('#info').css('top', e.pageY + yOff).css('left', e.pageX + xOff);

//            //$('#info').load('ReadTextFileX.aspx', function() {
//            //    $(this).appendTo('#info');
//            //});
//    
//        
//    },  function() {
//        $('#info').remove();                
//    });
//    $('a').mousemove(function(e) {
//        $('#info').css('top', e.pageY + yOff).css('left', e.pageX + xOff);
//    });
//});
