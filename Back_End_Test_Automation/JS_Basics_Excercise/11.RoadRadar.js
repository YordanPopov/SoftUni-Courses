function CheckSpeedLimit(inputArr) {
    let currentSpeed = Number(inputArr[0]);
    let area = inputArr[1];
    let limit;

    let output = (speed, speedLimit) => {
        let difference = speed - speedLimit;
        let status = (difference <= 20) ? 'speeding' :
                     (difference > 20 && difference <= 40) ? 'excessive speeding' :
                     'reckless driving';

        if (speed <= speedLimit) {
            return `Driving ${speed} km/h in a ${speedLimit} zone`;          
        } else {
            return `The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`;
        }
    }

    switch (area) {
        case 'motorway': 
            limit = 130; 
            console.log(output(currentSpeed, limit));
            break;
        case 'interstate': 
            limit = 90;
            console.log(output(currentSpeed, limit));
            break;
        case 'city':
            limit = 50;
            console.log(output(currentSpeed, limit));
            break;
        case 'residential':
            limit = 20;
            console.log(output(currentSpeed, limit));
            break;
    }
}

CheckSpeedLimit([200, 'motorway']);
CheckSpeedLimit([120, 'interstate']);
CheckSpeedLimit([40, 'city']);
CheckSpeedLimit([21, 'residential']);