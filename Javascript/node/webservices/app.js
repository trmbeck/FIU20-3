let express = require('express');
let app = express();
let formidable = require('formidable');
let fs = require('fs'); // fs -> filesystem (integriertes Node-Modul)
let logDateiPfad = "webserver.log";
let logDateiPfad2 = "webserver2.log";
let operationList = new Array();

function Addition(x, y){
    return x + y;
}

//Daten aus webserver2.log laden und ausgeben (asynchron)
fs.readFile(logDateiPfad2, 'utf8',(err,logdaten) => {console.log(logdaten)});

//Daten aus webserver.log laden und ausgeben (synchron)
let dateiinhalt = fs.readFileSync(logDateiPfad,'utf8');
console.log(dateiinhalt);

//Daten aus operationen.txt laden und in Array speichern und dann ausgeben
operationList = JSON.parse(fs.readFileSync("operationen.txt",'utf8'));
console.log(operationList);

app.use(express.static(__dirname + "/public"));

// HTTP-GET - Route /addition?x=3&y=4
app.get('/addition', function(req,res){
    let zahl1 = Number(req.query.x);
    let zahl2 = Number(req.query.y);
    let ergebnis = Addition(zahl1, zahl2);

    res.writeHead(200, {'Content-Type':'application/json'});
    res.end('{ "ergebnis": ' + ergebnis + ' }');

    let meldung = 'Handled addition request for x=' + 
            zahl1.toString() + ' : y=' + 
            zahl2.toString() + '\r\n'

    operationList.push({x:zahl1,y:zahl2,result:ergebnis});

    console.log(meldung);
    
    // in Datei (Webserver.log) speichern synchron
    fs.writeFileSync(logDateiPfad, meldung ,{flag: 'a+'});

    // asynchron
    fs.writeFile(logDateiPfad2, meldung, {flag: 'a'}, err => {
        //was passiert im Fehlerfalle
    });
    
    //als JSON speichern
    fs.writeFile("operationen.txt",JSON.stringify(operationList), err => {});

});

app.listen(8888);


