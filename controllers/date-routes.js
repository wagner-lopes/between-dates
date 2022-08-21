const router = require('express').Router();
const { DateTime } = require("luxon");
const {
    getWeekdays,
    applyDateFormat,
    roundResults,
    getCompleteWeeks
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
        //Use today as default start date AND
        //set hour to zero
        localStartDate = DateTime.now().startOf("day");
    }

    //Getting the end date with zero hour and minus 1 day - End date not included
    localEndDate = DateTime.fromISO(endDate).startOf("day").minus({ day: 1 });

    //Stop if startDate format is invalid
    if (!localStartDate) {
        res.send(`Wrong date format for the start date`);
        return;
    }

    //Stop if endDate format is invalid
    if (!localEndDate) {
        res.send(`Wrong date format for the end date`);
        return;
    }

    //Stops if startDate is greater than endDate
    if (localStartDate >= localEndDate) {
        res.send({ message: "endDate needs to be greater than startDate." });
        return;
    }

    let result = {};

    //weeks
    result.completeWeeks = getCompleteWeeks(localStartDate, localEndDate);
    result.weekdays = getWeekdays(localStartDate, localEndDate);
    result.days = localEndDate.diff(localStartDate, 'days').toObject().days;

    //Round up the results
    result = roundResults(result);

    //Include results in other formats (seconds, minutes, hours, years)
    //if requested
    dateFormat ? result = applyDateFormat(result, dateFormat) : null

    res.send(result)
});

module.exports = router;
