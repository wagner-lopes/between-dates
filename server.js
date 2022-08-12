const express = require('express');
const app = express();

//Port used to run the express server
const PORT = process.env.PORT || 3001;

//Enables body, params and queries parsing
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

//Enable the controlers (Sistem routes)
app.use(require('./controllers/date-routes'));

//Starts Express Server
app.listen(PORT, () => console.log(`App running on port ${PORT}`));
