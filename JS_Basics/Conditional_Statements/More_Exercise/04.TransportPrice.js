function solve(distance, timeOfDay) {
    let isDay = timeOfDay === 'day';

    let taxiPrice = Number.MAX_VALUE;
    let busPrice = Number.MAX_VALUE;
    let trainPrice = Number.MAX_VALUE;

    if (distance < 20) {
        if (isDay) {
            taxiPrice = 0.70 + (distance * 0.79);
        } else {
            taxiPrice = 0.70 + (distance * 0.9);
        }
    }

    if (distance >= 20) {
        busPrice = distance * 0.09;
        if (isDay) {
            taxiPrice = 0.70 + (distance * 0.79);
        } else {
            taxiPrice = 0.70 + (distance * 0.9);
        }
    }

    if (distance >= 100) {
        busPrice = distance * 0.09;
        trainPrice = distance * 0.06;
        if (isDay) {
            taxiPrice = 0.70 + (distance * 0.79);
        } else {
            taxiPrice = 0.70 + (distance * 0.9);
        }
    }

    console.log(Math.min(taxiPrice, busPrice, trainPrice).toFixed(2));
}

solve(180, 'night');