let element = document.getElementById("0815");
element.innerHTML = "Hallo FIU 20/3";

// let Tabelle = document.getElementById("table1");
// console.log(Tabelle);

let TdElemente = document.getElementsByTagName("td");
console.log(TdElemente);

let Textbox = document.getElementsByName("vorname");
Textbox.value = "Vorname eintragen";


let button = document.getElementById("btn");
button.addEventListener("click",welcome,false); 
// 1. parameter: Eventname
// 2. parameter: Funktion
// 3. parameter: Event Capturing(true)/Event Bubbling(false)


function welcome(eventArgs){
    let vorname = document.getElementById("txbVorname").value;
    alert("Willkommen " + vorname + "!");
    eventArgs.stopPropagation(); // Weiterleiten des Events unterbinden
}

function checkName(){
    let nachname = document.getElementById("txbNachname").value;
    if (nachname == "") document.getElementById("txbNachname").setAttribute("style","background-color: red");
    else document.getElementById("txbNachname").setAttribute("style", "background-color: green");
}

