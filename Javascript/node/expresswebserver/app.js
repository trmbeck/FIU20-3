const { response } = require("express");
let express = require("express");
let app = express();
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
    console.log("Handled request from " + req.query.benutzername);
});

app.listen(port);
console.log("Listening on port: " + port);