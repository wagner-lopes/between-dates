const router = require('express').Router();

router.get('/', (req, res) => {
    // Here, index.html is rendered
    res.send('WORKING!!! :)');
});

module.exports = router;
