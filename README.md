# Between Dates 
Between dates is an API andpoint that can be used to calculate how many days, weekdays and complete weeks there are between 2 dates.

# Deployed app
* Endpoint: [https://between-dates.herokuapp.com/between-dates](https://between-dates.herokuapp.com)
* Method: POST

# Implementation decisions
* The system uses the ISO Dates standart
 * YYYY-MM-DDTHH:MM:SSZ for datetime
 * YYYY-MM-DD for format

* Initial date is optional. In case it's null, use current datetime

* Using luxon as date library because it's based on Moment, which is known to be a powerful javascript date library.
* Considering complete weeks as Monday to Sunday
* Use 2 decimal places for converting into years