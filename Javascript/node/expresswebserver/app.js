const { response } = require("express");
let express = require("express");
let app = express();
let formidable = require('formidable');

let port = 8888;

app.use(express.static(__dirname + "/public"));

//HTTP-GET
app.get('/', function (request, response){
    response.send("keine HTML-Datei angegeben");
});

app.get('/SubmitBenutzername',function(req,res){
    res.writeHead(200, {'Content-Type':'text/html'});
    res.write("Hello " + req.query.benutzername + "!");
    res.end(" Have a great day!");
    console.log("Handled GET request from " + req.query.benutzername);
});


//HTTP-POST Handling
app.post('/PostBenutzername',function(req,res){
    let form = new formidable.IncomingForm();
    form.parse(req, function(err, fields){
        res.writeHead(200, {'Content-Type': 'text/html'});
        res.write("Hello " + fields.benutzername + "!<br>");
        res.end("Have a POST great day!");
        console.log("Handled POST request from " + fields.benutzername);
    }); 
});

app.listen(port);
console.log("Listening on port: " + port);