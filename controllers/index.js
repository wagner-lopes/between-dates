const router = require('express').Router();

const datesRoutes = require('./date-routes');

router.use('/', datesRoutes);

module.exports = router;