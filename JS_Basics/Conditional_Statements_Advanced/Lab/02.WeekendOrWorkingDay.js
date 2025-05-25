function solve(dayOfWeek) {
    let output;

    switch (dayOfWeek) {
        case 'Monday':
        case 'Tuesday':
        case 'Wednesday':
        case 'Thursday':
        case 'Friday':
            output = 'Working day';
            break;
        case 'Saturday':
        case 'Sunday':
            output = 'Weekend';
            break;
        default:
            output = 'Error';
            break;
    }

    console.log(output);
}

solve('Sunday');