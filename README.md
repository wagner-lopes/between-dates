# Between Dates 
Between dates is an API andpoint that can be used to calculate how many days, weekdays and complete weeks there are between 2 dates. It also accept extra parameters to have the results converted into seconds, minutes, hours or years.

# Live endpoint
* Endpoint: [https://between-dates.herokuapp.com/between-dates](https://between-dates.herokuapp.com)
* Method: POST

# How to use it
## Calling the API
* Make a POST request to https://between-dates.herokuapp.com/between-dates sending a payload that contains startDate, endDate and format
    * startDate (optional):
        * ISO Date format: YYYY-MM-DDTHH:MM:SSZ or YYYY-MM-DD
        * The start date for the calculations. In case it's not provided, the system will use the current day as the start date.
    * endDate (mandatory): 
        * ISO Date format: YYYY-MM-DDTHH:MM:SSZ or YYYY-MM-DD
        * The end date for the calculations
    * format (optional):
        * Possible values: ***seconds***, ***minutes***, ***hours*** or ***years***
        * Provides extra properties in the response object with the completedWeeks, weekdays and days converted into the selected format.
* To send different timezones, use the ISO datetime format YYYY-MM-DDTHH:MM:SSZ. The ***Z*** at the end defines the timezone.
	* Examples: 
		* ```2024-05-27T10:15:30-12:00```
		* ```2023-07-31T00:00:00+09:30```

## Examples
### Get period without extra formats:
* Request
```
{ 
	"startDate": "2022-08-03", 
	"endDate": "2024-05-27", 
	"format": "" 
}
```
* Response
```
{
	"completeWeeks": 93,
	"weekdays": 472,
	"days": 662
}
```

### Get period with extra formats:
* Request
```
{ 
	"startDate": "2022-08-03", 
	"endDate": "2024-05-27", 
	"format": "seconds" 
}
```
* Response
```
{
	"completeWeeks": 93,
	"weekdays": 472,
	"days": 662,
	"weekdaysInSeconds": "40780800 seconds",
	"completeWeeksInSeconds": "56246400 seconds",
	"daysInSeconds": "57196800 seconds"
}
```

### Start and end date in different timezones
* Request
```
{ 
	"startDate": "2022-08-03T10:15:30-12:30", 
	"endDate": "2024-05-27T10:15:30+12:30", 
	"format": "seconds" 
}
```
* Response
```
{
	"completeWeeks": 92,
	"weekdays": 471,
	"days": 660,
	"weekdaysInSeconds": "40694400 seconds",
	"completeWeeksInSeconds": "55641600 seconds",
	"daysInSeconds": "57024000 seconds"
}
```

# Implementation decisions
* The system only accepts ISO Dates format as paramethers
    * YYYY-MM-DDTHH:MM:SSZ for datetime
    * YYYY-MM-DD for date

* The startDate parameter is optional. In case it's null, the system will use the current date

* The system uses luxon as date library because:
    * It's based on Moment which is known to be a powerful javascript date library.
    * It it well documented
    * After initial analysis it was concluded that it provides all functionalities required by th system

* The system considers complete weeks starts on Mondays and ends on Sundays
* The system only provides 2 decimal places for non integer values

# Technologies used
* **API implementation**: JavaScript, NodeJs, Express and luxon
* **Unit tests**: C# and xUnit

# System requirements
### To run the system:
* [Node.js](https://nodejs.org)

### To run the unit tests:
* [.NET Core](https://dotnet.microsoft.com/en-us/download)

# Installation instructions
### In your terminal:
1. Clone git the repository:
```
git clone https://github.com/wagner-lopes/between-dates.git
```
2. Open the repository folder
```
cd between-dates
```
3. Install the System
```
npm install
```

# Starting the express server
### In your terminal
1. Start the System
```
npm start
```

# References
* [xUnit](https://xunit.net)
* [Get Started with xUnit](https://xunit.net/docs/getting-started/netfx/visual-studio)
* [luxon](https://moment.github.io/luxon) 

# MIT License
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

---

@ 2022 Wagner Lopes