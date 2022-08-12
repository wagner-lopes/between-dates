const router = require('express').Router();
const { DateTime, Duration } = require("luxon");

router.get('/', (req, res) => {
    res.send('STILL WORKING!!! :)');
});

router.post('/interval', (req, res) => {
    //Extract parameters from the body of the request
    const { startDate, endDate, dateFormat } = req.body;
    let localStartDate;
    let localEndDate;

    //Check for mandatory paramether
    if (!endDate) {
        res.send(`endDate parameter is mandatory`);
        return;
    }
    //Define
    if (startDate) {
        localStartDate = DateTime.fromISO(startDate);
    } else {
        localStartDate = DateTime.now();
    }

    localEndDate = DateTime.fromISO(endDate);

    if (!localStartDate) {
        res.send(`Wrong date format for the start date`);
        return;
    }

    if (!localEndDate) {
        res.send(`Wrong date format for the end date`);
        return;
    }

    let result;

    switch (dateFormat) {
        case ('seconds'):
            result = localEndDate.diff(localStartDate, 'seconds');
            break;
        case ('minutes'):
            result = localEndDate.diff(localStartDate, 'minutes');
            break;
        case ('hours'):
            result = localEndDate.diff(localStartDate, 'hours');
            break;
        case ('weeks'):
            result = localEndDate.diff(localStartDate, 'weeks');
            break;
        case ('years'):
            result = localEndDate.diff(localStartDate, 'years');
            break;
        default:
            result = localEndDate.diff(localStartDate, 'days');
    }

    res.send(result.toObject())
});

module.exports = router;
