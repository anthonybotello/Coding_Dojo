const http = require('http');
const fs = require('fs');
const server = http.createServer((request,response) => {
    console.log(`client request URL: ${request.url}`);

    if (request.url === '/'){
        fs.readFile('index.html','utf8',(errors,contents) => {
            response.writeHead(200,{'Content-Type':'text/html'});
            response.write(contents);
            response.end();
        });
    }
    else if (request.url === '/ninjas'){
        fs.readFile('ninjas.html','utf8',(errors,contents) => {
            response.writeHead(200,{'Content-Type':'text/html'});
            response.write(contents);
            response.end();
        });
    }
    else if (request.url === '/dojos/new'){
        fs.readFile('dojos.html','utf8',(errors,contents) => {
            response.writeHead(200,{'Content-Type':'text/html'});
            response.write(contents);
            response.end();
        });
    }
    else{
        response.writeHead(404);
        response.end('Nope.');
    }
});

server.listen(5000);
console.log("Running in localhost at port 5000");