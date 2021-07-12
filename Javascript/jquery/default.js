

$(document).ready(init);


function AddNumber(x, y){
    return x + y;
}

function init (){
    //document.getElementById("container1").innerHTML = "Hallo";
    //let btn = document.getElementById("btn1");
    
    let btn1 = $("#btn1");
    btn1.css("background-color","yellow");
    btn1.css("color","red");
    btn1.click(function (){console.log("clicked!")});

    let inputElementList = $("input","[type='button']");
    console.log(inputElementList);

    let eingabeListe = $(".eingabe");
    console.log(eingabeListe);

    let txb1 = $("#txb1");
    txb1.change(function(){
        console.log("changed!\n");
    });

    txb1.keyup(function () {
        console.log("key up");
    });


}