const express = require('express');
const app = express();

//Settings
require('./settings')(app);

//Routes


//Port Number
app.listen(5000);