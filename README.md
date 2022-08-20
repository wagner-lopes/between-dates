# date-conversion

# Deployed app
[Between Dates](https://between-dates.herokuapp.com)

# Implementation decisions
* The system uses the ISO Dates standart
 * YYYY-MM-DDTHH:MM:SSZ for datetime
 * YYYY-MM-DD for format

* Initial date is optional. In case it's null, use current datetime

* Using luxon as date library because it's based on Moment, which is known to be a powerful javascript date library.
* Considering complete weeks as Monday to Sunday