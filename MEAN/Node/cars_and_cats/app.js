const http = require('http');
const fs = require('fs');
const server = http.createServer((request,response) => {
    console.log(`client request URL: ${request.url}`);

    if (request.url === '/cars'){
        fs.readFile('cars.html','utf8',(errors,contents) => {
            response.writeHead(200,{'Content-Type':'text/html'});
            response.write(contents);
            response.end();
        });
    }
    else if(request.url === '/images/1967.jpg'){
    // notice we won't include the utf8 encoding
        fs.readFile('./images/1967.jpg', function(errors, contents){
            response.writeHead(200, {'Content-type': 'image/jpg'});
            response.write(contents);
            response.end();
        });
    }
    else if(request.url === '/images/1968.jpg'){
    // notice we won't include the utf8 encoding
        fs.readFile('./images/1968.jpg', function(errors, contents){
            response.writeHead(200, {'Content-type': 'image/jpg'});
            response.write(contents);
            response.end();
        });
    }
    else if(request.url === '/images/1969.jpg'){
    // notice we won't include the utf8 encoding
        fs.readFile('./images/1969.jpg', function(errors, contents){
            response.writeHead(200, {'Content-type': 'image/jpg'});
            response.write(contents);
            response.end();
        });
    }
    else if (request.url === '/cats'){
        fs.readFile('cats.html','utf8',(errors,contents) => {
            response.writeHead(200,{'Content-Type':'text/html'});
            response.write(contents);
            response.end();
        });
    }
    else if(request.url === '/images/lion.jpg'){
        // notice we won't include the utf8 encoding
        fs.readFile('./images/lion.jpg', function(errors, contents){
            response.writeHead(200, {'Content-type': 'image/jpg'});
            response.write(contents);
            response.end();
        });
    }
    else if(request.url === '/images/tiger.jpg'){
        // notice we won't include the utf8 encoding
        fs.readFile('./images/tiger.jpg', function(errors, contents){
            response.writeHead(200, {'Content-type': 'image/jpg'});
            response.write(contents);
            response.end();
        });
    }
    else if(request.url === '/images/burr.jpg'){
        // notice we won't include the utf8 encoding
        fs.readFile('./images/burr.jpg', function(errors, contents){
            response.writeHead(200, {'Content-type': 'image/jpg'});
            response.write(contents);
            response.end();
        });
    }
    else if (request.url === '/cars/new'){
        fs.readFile('newcar.html','utf8',(errors,contents) => {
            response.writeHead(200,{'Content-Type':'text/html'});
            response.write(contents);
            response.end();
        });
    }
});

server.listen(5000);
console.log("Running in localhost at port 5000");