function calculateHoursToRead(pages, pagesPerHour, days) {
    let totalTimeForReading = pages / pagesPerHour;
    let neededHours = totalTimeForReading / days;

    console.log(neededHours);
}

calculateHoursToRead(212, 20, 2);
calculateHoursToRead(432, 15, 4);