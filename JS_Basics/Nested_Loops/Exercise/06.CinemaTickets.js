function solve(input) {
    let totalTickets = 0;
    let studentTickets = 0;
    let standardTickets = 0;
    let kidTickets = 0;

    let index = 0;

    while (input[index] !== 'Finish') {
        let movieName = input[index++];
        let availableSeats = Number(input[index++]);
        let seats = availableSeats;
        let filledSeats = 0;

        while (availableSeats > 0) {
            let ticketType = input[index++];

            if (ticketType === 'End') {
                break;
            } else if (ticketType === 'student') {
                studentTickets++;
            } else if (ticketType === 'standard') {
                standardTickets++;
            } else if (ticketType === 'kid') {
                kidTickets++;
            }

            filledSeats++;
            availableSeats--;
            totalTickets++;
        }

        console.log(`${movieName} - ${(filledSeats / seats * 100).toFixed(2)}% full.`);
    }

    console.log(`Total tickets: ${totalTickets}`);
    console.log(`${(studentTickets / totalTickets * 100).toFixed(2)}% student tickets.`);
    console.log(`${(standardTickets / totalTickets * 100).toFixed(2)}% standard tickets.`);
    console.log(`${(kidTickets / totalTickets * 100).toFixed(2)}% kids tickets.`);
}

solve(["The Matrix",
    "20",
    "student",
    "standard",
    "kid",
    "kid",
    "student",
    "student",
    "standard",
    "student",
    "End",
    "The Green Mile",
    "17",
    "student",
    "standard",
    "standard",
    "student",
    "standard",
    "student",
    "End",
    "Amadeus",
    "3",
    "standard",
    "standard",
    "standard",
    "Finish"])
