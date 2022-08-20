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

function getCompleteWeeks(startDate, endDate) {
    //Considering Sunday as the last day of the week
    //Get first Sunday
    const firstDayOfWeek = getFirstDayOfCompleteWeek(startDate);
    //Get last Sunday
    const lastDayOfWeek = getLastDayOfCompleteWeek(endDate);
    const completeWeeks = lastDayOfWeek.diff(firstDayOfWeek, 'weeks').toObject().weeks;
    return completeWeeks;
}

function getFirstDayOfCompleteWeek(startDate) {
    const daysToAdd = 7 - startDate.weekday;
    const newStartDate = startDate.plus({ days: daysToAdd });
    return newStartDate;
}

function getLastDayOfCompleteWeek(endDate) {
    const daysToSubtract = endDate.weekday;
    const newEndDate = endDate.minus({ days: daysToSubtract });
    return newEndDate;
}

module.exports = {
    getWeekdays,
    applyDateFormat,
    roundResults,
    getCompleteWeeks
}