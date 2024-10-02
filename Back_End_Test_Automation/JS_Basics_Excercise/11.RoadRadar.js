function roadRadar(arr) {
    let speedLimit;
    let status;
    let speed = parseInt(arr[0]);
    let area = arr[1];
   
    function printOutput(speed, speedLimit) {
        let status = '';
        let difference = 0;

        if (speed <= speedLimit) {
            console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        }else {
            difference = speed - speedLimit;
            if (difference <= 20) {
                status = 'speeding';
            }else if (difference > 20 && difference <= 40) {
                status = 'excessive speeding';
            }else {
                status = 'reckless driving';
            }
            
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
        }
    }

    switch (area) {
        case 'motorway':
            speedLimit = 130;
            printOutput(speed, speedLimit);
            break;
        case 'interstate':
            speedLimit = 90;
            printOutput(speed, speedLimit);
            break;
        case 'city':
            speedLimit = 50;
            printOutput(speed, speedLimit);
            break;
        case 'residential':
            speedLimit = 20;
            printOutput(speed, speedLimit);
            break;
    }
}

roadRadar(200, 'motorway');
roadRadar(120, 'interstate');
roadRadar(40, 'city');
roadRadar(21, 'residential');