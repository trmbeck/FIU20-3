$(document).ready(function(){
    $('#btnAdd').on('click', RemoteAddition);
    $('#btnAddAsync').on('click', RemoteAdditionAsync);
    $('#btnAddJQuery').on('click', RemoteAdditionJQuery);
    $('#btnAddJSON').on('click', RemoteAdditionGetJSON);
});

function RemoteAddition(){
    console.log("btn clicked!");
    let x = document.getElementById('x').value;
    let y = document.getElementById('y').value;
    let query = "/addition?x="+x+"&y="+y;

    //XMLHttpRequest - Object
    let xmlhttp = new XMLHttpRequest();
    xmlhttp.open("GET",query,false); // method,url,async
    xmlhttp.send();

    let jsonObject = JSON.parse(xmlhttp.response);

    document.getElementById("result").innerHTML = jsonObject.ergebnis;
}

//AJAX
function RemoteAdditionAsync(){
    let x = document.getElementById('x').value;
    let y = document.getElementById('y').value;
    let query = "/addition?x="+x+"&y="+y;

    let xmlhttp = new XMLHttpRequest();

    // XMLHttpRequestObjekt - ReadyStates
    // 0 - Uninitialized -> die Open-Methode wurde noch nicht aufgerufen
    // 1 - Loading -> die Send-Methode wurde noch nicht aufgerufen
    // 2 - Loaded -> die Send-Methode wurde aufgerufen
    // 3 - Interactive -> Der Content wird heruntergeladen
    // 4 - Completed

    xmlhttp.onreadystatechange = function (){
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200){
            let jsonObject = JSON.parse(xmlhttp.response);
            document.getElementById("result").innerHTML = jsonObject.ergebnis;
        }
        console.log("ReadyState: " + xmlhttp.readyState);
    }

    xmlhttp.open("GET", query, true);
    xmlhttp.send();

}

//AJAX über jQuery
function RemoteAdditionJQuery(){
    console.log("jQuery");
    let x = $('#x').val();
    let y = $('#y').val();
    let request = { "x": x, "y": y };

    $.ajax({
        url:'/addition',
        type: 'GET',
        data: request,
        dataType: 'json',
        success: function (response){
            $('#result').html(response.ergebnis);
        }
    })
}

function RemoteAdditionGetJSON(){
    console.log("GetJSON");
    let x = $('#x').val();
    let y = $('#y').val();
    let request = { "x": x, "y": y };

    $.getJSON('/addition', request, function(response){
        $('#result').html(response.ergebnis);
    });
}