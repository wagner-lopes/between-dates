const router = require('express').Router();
const { DateTime } = require("luxon");

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

function applyDateFormat(result, format) {
    let multiplier;
    switch (format) {
        case "seconds":
            multiplier = 24 * 60 * 60;
            break;
        case "minutes":
            multiplier = 24 * 60;
            break;
        case "hours":
            multiplier = 24;
            break;
        case "years":
            return formatInYears(result);
            break;
        default:
            return result;
    }

    return applyMultiplier(result, format, multiplier);
}

function formatInYears(result) {
    result.weekdays = `${result.weekdays / 365} years`;
    result.completeWeeks = `${result.completeWeeks / (365 / 7)} years`;
    result.days = `${result.days / 365} years`;

    return result;
}

function applyMultiplier(result, format, multiplier) {
    let capitalisedFormat = format.charAt(0).toUpperCase() + format.slice(1);
    result[`weekdaysIn${capitalisedFormat}`] = `${result.weekdays * multiplier} ${format}`;
    result[`completeWeeksIn${capitalisedFormat}`] = `${result.completeWeeks * 7 * multiplier} ${format}`;
    result[`daysIn${capitalisedFormat}`] = `${result.days * multiplier} ${format}`;

    return result;
}

function roundResults(result) {
    //Get the integer part of the result
    result.completeWeeks = Math.floor(result.completeWeeks);
    result.days = Math.floor(result.days);
    result.weekdays = Math.floor(result.weekdays);

    return result;
}

function getWeekdays(startDate, endDate) {
    let weekdays = 0;
    while (startDate < endDate) {
        startDate = startDate.plus({ days: 1 });
        if (startDate.weekday < 6) weekdays++;
    }

    return weekdays;
}

module.exports = router;
