function solve(input) {
    let totalTickets = 0;
    let studentTickets = 0;
    let standardTickets = 0;
    let kidTickets = 0;
    let index = 0;

    while (input[index] !== 'Finish') {
        let movieName = input[index++];
        let availableSeats = Number(input[index++]);
        let filledSeats = 0;
        let seats = availableSeats;

        while (availableSeats > 0) {
            let ticketType = input[index++];

            if (ticketType === 'student') {
                studentTickets++;
            } else if (ticketType === 'standard') {
                standardTickets++;
            } else if (ticketType === 'kid') {
                kidTickets++;
            } else if (ticketType === 'End') {
                break;
            }

            filledSeats++;
            totalTickets++;
            availableSeats--;
        }

        console.log(`${movieName} - ${(filledSeats / seats * 100).toFixed(2)}% full.`)
    }

    console.log(`Total tickets: ${totalTickets}`);
    console.log(`${(studentTickets / totalTickets * 100).toFixed(2)}% student tickets.`);
    console.log(`${(standardTickets / totalTickets * 100).toFixed(2)}% standard tickets.`);
    console.log(`${(kidTickets / totalTickets * 100).toFixed(2)}% kids tickets.`);
}

solve(["Taxi",
    "10",
    "standard",
    "kid",
    "student",
    "student",
    "standard",
    "standard",
    "End",
    "Scary Movie",
    "6",
    "student",
    "student",
    "student",
    "student",
    "student",
    "student",
    "Finish"]);
