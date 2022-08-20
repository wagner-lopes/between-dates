const router = require('express').Router();
const { DateTime } = require("luxon");
const {
    getWeekdays,
    applyDateFormat,
    roundResults
} = require('../utils/usefulMethods')

router.post('/interval', (req, res) => {
    //Extract parameters from the body of the request
    const { startDate, endDate, dateFormat } = req.body;
    let localStartDate;
    let localEndDate;

    //Check for mandatory paramether
    if (!endDate) {
        res.send({ message: `endDate parameter is mandatory` });
        return;
    }

    //Define localStartDate. Use today as default
    if (startDate) {
        localStartDate = DateTime.fromISO(startDate);
    } else {
        localStartDate = DateTime.now().startOf("day");
    }

    //Getting the end date with zero hour and minus 1 day - End date not included
    localEndDate = DateTime.fromISO(endDate).startOf("day").minus({ day: 1 });

    if (localStartDate >= localEndDate) {
        res.send({ message: "endDate needs to be greater than startDate." });
        return;
    }

    if (!localStartDate) {
        res.send(`Wrong date format for the start date`);
        return;
    }

    if (!localEndDate) {
        res.send(`Wrong date format for the end date`);
        return;
    }

    let result = {};

    //weeks
    result.completeWeeks = localEndDate.diff(localStartDate, 'weeks').toObject().weeks;
    result.weekdays = getWeekdays(localStartDate, localEndDate);
    result.days = localEndDate.diff(localStartDate, 'days').toObject().days;

    //Round up the results
    result = roundResults(result);

    dateFormat ? result = applyDateFormat(result, dateFormat) : null

    res.send(result)
});

module.exports = router;
