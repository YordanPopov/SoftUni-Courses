function solve(input) {
    const baseCamp = 5364;
    const everestPeak = 8848;
    const maxDays = 5;

    let currentHeight = baseCamp;
    let days = 1;

    let index = 0;
    while (input[index] !== 'END') {
        let willRest = input[index++];
        let metersClimbed = Number(input[index++]);

        if (willRest === 'Yes') {
            days++;
            if (days > maxDays) {
                console.log(`Failed!\n${currentHeight}`);
                return;
            }
        }

        currentHeight += metersClimbed;
        if (currentHeight >= everestPeak) {
            console.log(`Goal reached for ${days} days!`);
            return;
        }
    }

    console.log(`Failed!\n${currentHeight}`);
}

solve(["Yes",
    "535",
    "Yes",
    "849",
    "Yes",
    "499",
    "Yes",
    "400",
    "Yes",
    "500"])




