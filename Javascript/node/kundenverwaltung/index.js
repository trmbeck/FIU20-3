const Kunde = require('./model/kunde');
const express = require('express');
const server = express();
const fs = require('fs');
const formidable = require('formidable');
let kundenliste = new Array();

console.log("Initializing ...");
console.log("Loading customers ...");
try{
    kundenJSON = JSON.parse(fs.readFileSync("./model/kundenliste.json", "utf8"));
    kundenJSON.forEach(element => {
        console.log(element);
        console.log(element.nachname);
        kundenliste.push(new Kunde(element.nachname,element.vorname,element.adresse,new Date(element.geburtsdatum)));
    });
    console.log(getKundenlisteJSONstring());
    console.log(kundenliste);
}catch(ex)
{
    console.log("Error reading customer list!\r\nError message: "+ ex.message + "\r\nServer closed!");
    return;
}
console.log("Customers loaded");


server.use(express.static(__dirname + '/public'));

server.get("/kunde", function(req, res){
    res.writeHead(200,{'Content-Type': 'application/json'});
    let kunde = kundenliste.find((x)=>x.getId() == req.query.id);
    console.log(req.query.id);
    console.log(kunde.getJSON());
    res.write(kunde.getJSON());
    res.end();
});

server.get("/kunden", function(req,res){
    res.writeHead(200,{'Content-Type': 'application/json'});
    res.end(getKundenlisteJSONstring());
});

server.post("/createCustomer", function(req,res){
    let form = new formidable.IncomingForm();
    form.parse(req,function(err,fields){
        kundenliste.push(new Kunde(fields.nachname, fields.vorname, fields.adresse,new Date(fields.geburtsdatum)));
        res.redirect('/index.html');
        writeKundenliste();
    });
})

console.log("Starting server ...")
server.listen(80);
console.log("Server running at port 80");

function writeKundenliste(){
    try{
        fs.writeFileSync("./model/kundenliste.json",getKundenlisteJSONstring());
    }catch(ex){
        console.log("Error: " + ex.message);
        return false;
    }
    finally{

    }
    return true;
}

function getKundenlisteJSONstring(){
    let kundenlisteJSONstring = "[";
    kundenliste.forEach((element,index) => {
        if (index != 0) kundenlisteJSONstring += ",";
        console.log(element);
        kundenlisteJSONstring += element.getJSON();
    });
    kundenlisteJSONstring += "]";
    console.log(kundenlisteJSONstring);
    return kundenlisteJSONstring;
}