//alert("Datei geladen!!!");

/*
Komentar
2. Komentarzeile
*/

var meineVariable = "Hallo";    //Zeichenfolge
meineVariable = 10;             // Zahlen, Numbers
meineVariable = 10.5;           // Zahlen, Numbers
meineVariable = true;           // boolean

console.log("Ausgabe: ");
console.log(meineVariable);

console.log("\nOperationen:");
console.log(10.5 + 10);         //20.5
console.log("Hallo " + 10);     //Hallo 10
console.log("10" + 10);         //1010
console.log("10" - 10);         //0
console.log("10a" - 10);         // NaN -> Not a Number

var zahl = "slkasdfklj" - 3454;
console.log(isNaN(zahl));
zahl = 1234;
console.log(isNaN(zahl));

var float = parseFloat("10.5");
console.log(float);

var int = parseInt("2.6");
console.log(int);

console.log(Number("2.6"));

console.log(String(345));



let zeichenfolge1 = "Meine Zeichenfolge";
let Zeichenfolge2 = 'Meine Zeichenfolge';

let Zeichenfolge3 = "Hallo 'JavaScript'!";
let zeichenfolge4 = 'Hallo "JavaScript"!';

let zeichenfolge5 = "'Hallo' \"JavaSCript\"!";

console.log(typeof('Hallo'));
console.log(typeof(10.5));
console.log(typeof(true));

// boolean
console.log('Äpfel' != 'Birnen');
console.log(10 <= 9);
console.log(10 > 9);
console.log(10 == 9);

console.log(10 > 9 && 3 < 6);
console.log(10 > 9 || 3 < 6);

console.clear();

//Functions

console.log(Add(100,200));


function Add(x, y){
    let result = x + y;
    x = 1;
    y = 2;
    return result;
}

let a = 5;
let b = 10;
let c = Add(a, b);

console.log("Ergebnis: " + c);
console.log("a: " + a);
console.log("b: " + b);

let myDelegate = Add;
console.log(myDelegate(1,2));

//kein Hoisting!!! -> Reference Error
//console.log(meineUnbenannteFunktion(10,8));

let meineUnbenannteFunktion = function (x, y){
    return x - y;
}

console.log(meineUnbenannteFunktion(10,8));

let promptResult = prompt("zur Info ... !!! Bitte Name eingeben!");
console.log(promptResult);

let confirmResult = confirm("Bestätigen?");
console.log(confirmResult);


if (confirmResult) console.log("Bestätigt!");
else console.log("Nicht bestätigt!");


//if (promptResult == null) promptResult = "Michael";
promptResult = promptResult || "Michael"; // Wenn promptResult null ist, wird "Michael" gespeichert

switch (promptResult){
    case 'Michael':
        alert("Hallo Michael");
    break;
    default:
        alert("Hallo User");
    break;
}

console.log(a == b);   // a = 5, b = 10   --> false
console.log(a == "5"); //               --> true (keine Typprüfung)
console.log(a === "5"); //              --> false (Typprüfung !!!)
console.log( a <<= 3); // 5  shift bitwise -> 0000 0101 << 3 0010 1000
console.log( a >>= "3");

for(let i = 0; i < 10; i++){
    console.log(i);
    if (i = 2) break;
}

let x = 10;
while(x > 0){
    x--;
    console.log(x);
    if (x = 8) break;
}

let confirmed = false;
do{
    confirmed = confirm("Wollen sie wirklich?");
}while(!confirmed)

try{
    undefinedFunction();
    console.log("Made it!");
}catch(ex){
    console.log("Fehler: " + ex.message);
    console.log(ex);
}finally{
    console.log("Finally Block");
}

console.log(Add(3,5,6,true,"Hallo"));
console.log(Add(3))

let meinArray = new Array();
meinArray[0] = 'bla';
meinArray[1] = 'blubb'; meinArray[2] = 10;

let meinArray2 = new Array('Salami', 'Schinken', 'Käse');

let meinArray3 =  ['Pepperoni', 'Zwiebel', 'Olive' , 'Zwiebel'];


for (i = 0; i < meinArray.length; i++) console.log(meinArray[i]);

let ZwiebelIndex = meinArray3.indexOf('Zwiebel');           // 1
let ZwiebelLastIndex = meinArray3.lastIndexOf('Zwiebel');   // 3

meinArray3.push('Sardinen');
console.log(meinArray3.pop());



meinArray3.reverse();
console.log(meinArray3);

meinArray3.sort();
console.log(meinArray3);

meinArray3.reverse();
console.log(meinArray3);


console.log(meinArray3.shift()); // entfernt Element 0 aus dem Array und liefert es zurück

console.log(meinArray3.unshift("Pilze")); //erstellt neues Array mit Value an Element 0
console.log(meinArray3);

console.log(meinArray3.slice(1,3));

console.log(meinArray3.splice(1,2,"Tomate", "Käse", "Meeresfrüchte"));
console.log(meinArray3);