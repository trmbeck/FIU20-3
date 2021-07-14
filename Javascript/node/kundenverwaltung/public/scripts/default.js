$(document).ready(function(){
    $('#btnload').click(laden);
    $('#btnshow').click(anzeigen);
})

function laden(){
    let id = $('#txbkunde').val();
    $.getJSON("/kunde",{'id':id},function(kunde){
        $('#kunden').html(kunde.nachname + ", " + kunde.vorname + " - " + kunde.adresse + " " + kunde.geburtsdatum);
    });
}

function anzeigen(){
    let innerhtml = "";
    $.getJSON("/kunden",function(kunden){
        kunden.forEach(kunde => {
            innerhtml += kunde.nachname + ", " + kunde.vorname + " - " + kunde.adresse + " " + kunde.geburtsdatum + "<br/>";
        });
        $('#kunden').html(innerhtml);
    });
}