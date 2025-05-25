function solve(hour, day) {
    let output;

    switch (day) {
        case 'Monday':
        case 'Tuesday':
        case 'Wednesday':
        case 'Thursday':
        case 'Friday':
        case 'Saturday':
            if (hour >= 10 && hour <= 18) {
                output = 'open';
            } else {
                output = 'closed';
            }
            break;
        case 'Sunday':
            output = 'closed';
    }

    console.log(output);
}

solve(11, 'Monday');