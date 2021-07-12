// console.log("Hallo Welt");
// let ergebnis = 10 + 15;
// console.log(ergebnis);
function requestHandling(req, res){
    let url_parts = url.parse(req.url,true);
    res.writeHead(200,{'Content-Type': 'text/plain'});
    res.write("Hallo " + url_parts.query.vorname + ", Willkommen!!!");
    res.end();
    console.log("Handled request from " + url_parts.query.vorname);
}

let port = 8888;
let httpServer = require('http');
let url = require('url');
httpServer.createServer(requestHandling).listen(port, 'localhost');
console.log('Server is running at http://localhost:' + port +"/");
