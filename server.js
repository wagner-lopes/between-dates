const path = require('path');
const express = require('express');
const app = express();
const PORT = process.env.PORT || 3001;

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.get('/', (req, res) => res.send('WORKING!!! :)'));

app.listen(PORT, () => console.log(`App running on port ${PORT}`));
