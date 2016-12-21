function openContent(evt, contentName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the link that opened the tab
    document.getElementById(contentName).style.display = "block";
    evt.currentTarget.className += " active";
}


//(function ($) {
//    $.fn.savename = function (componentId) {        
//        var element = $(this);
//        //alert(element.val);
//        $.post("/Components/SaveName", { "componentId": componentId, "name": element.val() }).success(function () {
//            element.closest(".ComponentInfo").prev().html(element.val());
//        });

//    }
//}(jQuery));

(function ($) {
    $.fn.savedescription = function (componentId) {
        $(document).on('focusout', '#' + $(this)[0].id, function () {
            var element = $(this);
            $.post("/Components/SaveDescription", { "componentId": componentId, "description": element.val() }).success(function () {
            });
        });

    }
}(jQuery));


(function ($) {
    $.fn.imageDrop = function (componentId) {
        var element = $(this)[0];
        element.addEventListener('dragover', function handleDragOver(evt) {
            evt.preventDefault();
            evt.dataTransfer.effectAllowed = 'copy';
            evt.dataTransfer.dropEffect = 'copy';
        }, false);
        element.addEventListener('drop', function (evt) {
            evt.preventDefault();
            evt.stopPropagation();
            var file = evt.dataTransfer.files[0];
            var data = new FormData();
            data.append(componentId, file, file.name);

            $.ajax({
                type: "POST",
                url: "/Components/SaveImage?componentId=" + componentId,
                data: data,
                processData: false,
                contentType: false,
                success: function () {
                    var reader = new FileReader();
                    reader.onload = function () {
                        $(element).children("img").attr("src", reader.result);
                    };
                    reader.readAsDataURL(file);
                }

            });
        }, false);
    }
}(jQuery));

//(function ($) {
//    $.fn.videoDrop = function (componentId) {
//        $(this).on("input", function (e) {
//            input = $(this).val();
//            code = youtube_parser(input);
//            if (code) {
//                $.post("/Components/SaveVideoUrl", { "componentId": componentId, "url": input }).success(function () {
//                    var element = "#Video" + componentId + " iframe"
//                    $(element).attr('src', 'https://www.youtube.com/embed/' + code)
//                });               
//            }
//        });
//    }    
//}(jQuery));

(function ($) {
    $.fn.addComponent = function (componentType, enrollmentId, enrollmentType, element) {
        $(this).on("click", function () {
            $.ajax({
                type: "POST",
                dataType: "Html",
                url: '/Components/CreateComponent?componentType=' + componentType + '&enrollmentId=' + enrollmentId + '&enrollmentType=' + enrollmentType,
                success: function (response) {
                    $(element).append(response);
                    $(".accordion").accordion("refresh");
                },
                error: function () {
                    alert("error occured in addComponent plugin");
                }
            });
        });

    }

}(jQuery));

    

function youtube_parser(url) {
    var regExp = /^.*((youtu.be\/)|(v\/)|(\/u\/\w\/)|(embed\/)|(watch\?))\??v?=?([^#\&\?]*).*/;
    var match = url.match(regExp);
    return (match && match[7].length === 11) ? match[7] : false;
}

//$(document).on("focusout", ".ComponentName", function () {
//    //alert($(this)[0].attr("data-id"));
//    $(this)[0].savename($(this)[0].attr("data-id"));
//});


$(document).ready(function () { 
    $('#somevalue').autocomplete({ 
        source: '/Schools/AutoComplete'
    }); 
})

$(document).ready(function () {


    $(".accordion").accordion({
        collapsible: true,
        heightStyle: 'content',
        //header: '> div > h3',
        active: 'none',
        autoHeight: false,
    }).sortable({
        axis: "y",
        handle: "h3",
        stop: function (event, ui) {
            // IE doesn't register the blur when sorting
            // so trigger focusout handlers to remove .ui-state-focus
            ui.item.children("h3").triggerHandler("focusout");

            // Refresh accordion to handle new order
            $(this).accordion("refresh");
        }
    });

    $('.accordion h3').bind('click', function () {
        theOffset = $(this).offset();
        $('body,html').animate({
            scrollTop: theOffset.top - 100
        });
    });



    $(".AddComponent").each(function (i, obj) {
        $(obj).addComponent($(obj).attr("data-componentType"), $(obj).attr("data-enrollmentId"), $(obj).attr("data-enrollmentType"), $(obj).attr("data-targetElement"));
    });

    //$(".ComponentName").each(function (i, obj) {
    //    $(obj).savename($(obj).attr("data-id"));
    //});


    $(document).on("focusout", ".ComponentName", function () {
        var element = $(this);
        $.post("/Components/SaveName", { "componentId": element.attr("data-id"), "name": element.val() }).success(function () {
            element.closest(".ComponentInfo").prev().html(element.val());
        });
    });    

    $(document).on("focusout", ".ComponentDescription", function () {
        $.post("/Components/SaveDescription", { "componentId": $(this).attr("data-id"), "description": $(this).val() }).success(function () {
        });
    });

    $(document).on("dragover", ".ComponentImage", function (evt) {
        evt.source.preventDefault();
        evt.source.dataTransfer.effectAllowed = 'copy';
        evt.source.dataTransfer.dropEffect = 'copy';
    });

    $(document).on("drop", ".ComponentImage", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
        var element = $(this)[0];
        var componentId = $(this).attr("data-id");
        alert(componentId);
        var file = evt.dataTransfer.files[0];
        var data = new FormData();
        data.append(componentId, file, file.name);

        $.ajax({
            type: "POST",
            url: "/Components/SaveImage?componentId=" + componentId,
            data: data,
            processData: false,
            contentType: false,
            success: function () {
                var reader = new FileReader();
                reader.onload = function () {
                    $(element).children("img").attr("src", reader.result);
                };
                reader.readAsDataURL(file);
            }

        });
    });

    //$(".ComponentImage").each(function (i, obj) {
    //    $(obj).imageDrop($(obj).attr("data-id"));
    //});

    $(document).on("input", ".VideoDrop", function (e) {
        input = $(this).val();
        componentId = $(this).attr("data-id");
        code = youtube_parser(input);
        if (code) {
            $.post("/Components/SaveVideoUrl", { "componentId": componentId, "url": input }).success(function () {
                var element = "#Video" + componentId + " iframe"
                $(element).attr('src', 'https://www.youtube.com/embed/' + code)
            });
        }
    });

});