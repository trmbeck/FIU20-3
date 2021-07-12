$(document).ready(function(){
    $("#divId img").on("mouseover",function(){
        // $(this).css({
        //     'cursor':'hand',
        //     'border-Color': 'red'
        // });
        $(this).css("cursor","pointer");
        $(this).css("border-color","red");
        
    });

    $("#divId img").mouseout(function(){
        $(this).css({
            "cursor":"default",
            "border-color":"gray"
        });
    })

    $("#divId img").click(function (){
        let mainImage = $("#mainImage");
        let imageSRC = $(this).attr("src")

        mainImage.attr("src", imageSRC);

    })
});