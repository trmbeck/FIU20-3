let websocket;
let wsURI = "ws://echo.websocket.org/";

$(document).ready(function(){
    Ausgeben("Document ready");
    if (checkSupported()){
        Verbinden();
        $('#btnSenden').click(Senden);
    }
});


function checkSupported(){
    if (window.WebSocket){
        Ausgeben("Websocket supported")
        return true;
    }else{
        $('#btnSenden').attr('disabled', 'disabled');
        Ausgeben("Websocket NOT supported")
        return false;
    }
}


function Ausgeben(text){
    let divOutput = $('#divOutput');
    divOutput.html(divOutput.html() + '<br />' + text);
}

function Verbinden(){
    websocket = new WebSocket(wsURI);
    websocket.onopen = function(evt){ onOpen(evt);}
    websocket.onclose = function(evt){ onClose(evt);}
    websocket.onerror = function(evt){ onError(evt)};
    websocket.onmessage = function(evt){ onMessage(evt)};
}

function Senden(){
    if(websocket.readyState != websocket.OPEN){
        Ausgeben("Verbindung nicht geöffnet: " + $('#txbNachricht').val());
        return;
    }
    Ausgeben($('#txbNachricht').val());
    websocket.send($('#txbNachricht').val());
}

function onOpen(evt){
    Ausgeben("VERBUNDEN");
}

function onClose(evt){
    Ausgeben("Verbindung aufgehoben");
}

function onError(evt){
    Ausgeben("FEHLER: " + evt.data);
}

function onMessage(evt){
    Ausgeben("Antwort: " + evt.data);
}