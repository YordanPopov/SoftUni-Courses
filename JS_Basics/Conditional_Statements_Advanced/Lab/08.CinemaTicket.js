function solve(day) {
    let ticketPrice;

    switch (day) {
        case 'Monday':
        case 'Tuesday':
        case 'Friday':
            ticketPrice = 12;
            break;
        case 'Wednesday':
        case 'Thursday':
            ticketPrice = 14;
            break;
        case 'Saturday':
        case 'Sunday':
            ticketPrice = 16;
            break;
    }

    console.log(ticketPrice);
}

solve('Monday');